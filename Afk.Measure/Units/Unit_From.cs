using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using Afk.Measure.Units.Metric.SI;
using Afk.Measure.Units.Metric;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents an unit
	/// </summary>
	public partial class Unit {
		// This file contains all unit static method

		private static List<Unit> _wellKnownUnits;

		private static object _synchronizedObject = new object();
		private static Regex regUnit = new Regex(@"^(?<Unit>([a-zA-Z]{0,2}°)?[a-zA-Z ]*)(\^?(?<Exponent>[-+]?\d+))?$", RegexOptions.Compiled);

		internal struct HashUnit {
			public int Id;
			public Type UnitType;
		}

		/// <summary>
		/// Obtain for specific dimension a list of <see cref="Unit"/>
		/// </summary>
		private static Dictionary<Dimension, List<HashUnit>> _dimensionToUnits;

		/// <summary>
		/// Gets the list of <see cref="Unit"/> know by the assembly
		/// </summary>
		public static Unit[] WellKnownUnits {
			get {
				lock (_synchronizedObject) {
					if (_wellKnownUnits == null)
						LoadUnits();
					return _wellKnownUnits.ToArray();
				}
			}
		}

		/// <summary>
		/// Gets the list of <see cref="Unit"/> for a specified <see cref="Dimension"/>
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of units</param>
		/// <returns>List of <b>HashUnit</b> which contains the type of <see cref="Unit"/> know in the specified <see cref="Dimension"/></returns>
		internal static List<HashUnit> GetUnitsListFromDimension(Dimension dimension) {
			lock (_synchronizedObject) {
				if (_dimensionToUnits == null)
					LoadUnits();
				if (_dimensionToUnits.ContainsKey(dimension)) {
					return _dimensionToUnits[dimension];
				}
				else
					return null;
			}
		}

		/// <summary>
		/// Load <see cref="Unit"/> from current assembly.
		/// </summary>
		private static void LoadUnits() {
			IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().
				Where(e => !e.IsAbstract && e.IsSubclassOf(typeof(Unit)) && e != typeof(ProductMetricBaseUnit) && e != typeof(ProductUnit) && e != typeof(PrefixUnit));

			_wellKnownUnits = new List<Unit>();
			_dimensionToUnits = new Dictionary<Dimension, List<HashUnit>>();

			// Select new instance of Unit with a right symbol
			IEnumerable<Unit> unites = types.Select(e => (Unit)Activator.CreateInstance(e)).Where(e => !string.IsNullOrEmpty(e.Symbol));

			// Only unit with exponent 1 are selected.
			_wellKnownUnits.AddRange(unites.Where(e => e.Exponent == 1));

			// Dictionary of units by dimension contain only dimension different from dimensionless
			foreach (Unit u in unites) {
				if (!u.Dimension.Equals(Dimension.None)) {
					HashUnit hu = new HashUnit();
					hu.Id = u.GetUICode();
					hu.UnitType = u.GetType();

					if (!_dimensionToUnits.ContainsKey(u.Dimension))
						_dimensionToUnits.Add(u.Dimension, new List<HashUnit>());
					_dimensionToUnits[u.Dimension].Add(hu);
				}
			}
		}

		/// <summary>
		/// Converts the string representation of a unit to its <see cref="Unit"/> equivalent.
		/// </summary>
		/// <param name="symbol"><see cref="String"/> containing a unit to convert.</param>
		/// <returns><see cref="Unit"/> value equivalent to the string contained in <b>symbol</b>.</returns>
		/// <exception cref="UnitException">The <b>symbol</b> can not be parse in <see cref="Unit"/></exception>
		public static Unit Parse(string symbol) {
			return Parse(symbol, false);
		}

		/// <summary>
		/// Converts the string representation of a unit to its <see cref="Unit"/> equivalent.
		/// </summary>
		/// <param name="symbol"><see cref="String"/> containing a unit to convert.</param>
		/// <param name="ignoreCase">Indicator which specify if method if case-sensitive or not.</param>
		/// <returns><see cref="Unit"/> value equivalent to the string contained in <b>symbol</b>.</returns>
		/// <exception cref="UnitException">The <b>symbol</b> can not be parse in <see cref="Unit"/></exception>
		public static Unit Parse(string symbol, bool ignoreCase) {
			Unit result = null;

			symbol = symbol.Trim();

			try {
				string[] div = symbol.Split(new char[] { '/' }, 2);
				if (div.Length == 2) {
					Unit unitA = Parse(div[0], ignoreCase);
					BaseUnit unitB = (BaseUnit)Parse(div[1], ignoreCase);
					if (unitA is PrefixUnit) {
						unitB = ProductUnitBuilder.GetProductInstance(((PrefixUnit)unitA).BaseUnit, (BaseUnit)unitB.Inverse());
						if (unitB is Measure.Units.MetricBaseUnit)
							return new PrefixUnit(((PrefixUnit)unitA).Prefixe, (MetricBaseUnit)unitB);
						throw new UnitException("Unable to cast " + unitB.Symbol + " to " + ((PrefixUnit)unitA).Prefixe.Symbol + unitB.Symbol);
					}
					else
						return ProductUnitBuilder.GetProductInstance((BaseUnit)unitA, (BaseUnit)unitB.Inverse());
				}
				else {
					Measure.Units.Metric.Prefixes.SIPrefixe p = null;

					// L'espace n'est pas considéré comme un séparateur valable, certaines unités sont composées d'espace
					// luid ounce = fl oz
					string[] unites = symbol.Split(new char[] { ProductUnitBuilder.SEPARATOR, '.' });

					for (int index = 0; index < unites.Length; index++) {
						Match match = regUnit.Match(unites[index]);
						if (match.Success) {
							string baseUnit = match.Groups["Unit"].Value;
							int exponent = (string.IsNullOrEmpty(match.Groups["Exponent"].Value)) ? 1 : Convert.ToInt32(match.Groups["Exponent"].Value);

							if (index == 0 && string.Compare(baseUnit, "g", ignoreCase) == 0) {
								// Cas particulier du gram
								BaseUnit instance = new Units.Metric.SI.Gram();
								if (exponent < 0) instance = (BaseUnit)instance.Inverse();

								BaseUnit product = null;
								for (int k = 0; k < Math.Abs(exponent); k++) {
									if (product == null)
										product = instance;
									else {
										product = ProductUnitBuilder.GetProductInstance(product, instance);
									}
								}
								result = (result == null) ? product : ProductUnitBuilder.GetProductInstance((BaseUnit)result, product);
								p = Measure.Units.Metric.Prefixes.SIPrefixe.None;
							}
							else {
								Unit knownUnit = WellKnownUnits.FirstOrDefault(e => string.Compare(e.Symbol, baseUnit, ignoreCase) == 0);
								if (knownUnit != null) {
									if (exponent < 0) knownUnit = knownUnit.Inverse();

									Unit product = null;
									for (int k = 0; k < Math.Abs(exponent); k++) {
										if (product == null)
											product = knownUnit;
										else {
											product = ProductUnitBuilder.GetProductInstance((BaseUnit)product, (BaseUnit)knownUnit);
										}
									}
									result = (result == null) ? product : ProductUnitBuilder.GetProductInstance((BaseUnit)result, (BaseUnit)product);
								}
								else if (p == null) {
									// On s'occupe d'abord des préfixes sur deux caractères
									// dam doit être compris deka meter et non deci atto meter
									if (baseUnit.Length > 2) {
										p = Measure.Units.Metric.Prefixes.SIPrefixe.Parse(baseUnit.Substring(0, 2), ignoreCase);

										if (p != null) {
											try {
												var unit = Parse(unites[index].Substring(2), ignoreCase);
												result = (result == null) ? unit : ProductUnitBuilder.GetProductInstance((BaseUnit)unit, (BaseUnit)result);
											}
											catch {
												p = null;
											}
										}
									}

									if (p == null) {
										p = Measure.Units.Metric.Prefixes.SIPrefixe.Parse(baseUnit.Substring(0, 1), ignoreCase);

										if (p != null) {
											var unit = Parse(unites[index].Substring(1), ignoreCase);
											result = (result == null) ? unit : ProductUnitBuilder.GetProductInstance((BaseUnit)unit, (BaseUnit)result);
										}
									}

									if (p == null)
										throw new UnitException("Unable to cast " + unites[index] + " to unit");
								}
								else {
									throw new UnitException("Unable to cast " + unites[index] + " to unit");
								}
							}
						}
						else {
							throw new UnitException("Unable to cast " + unites[index] + " to unit");
						}
					}

					if (p != null)
						if (result is PrefixUnit && ((PrefixUnit)result).Prefixe == Measure.Units.Metric.Prefixes.SIPrefixe.None) {
							result = new PrefixUnit(p, ((PrefixUnit)result).BaseUnit);
						}
						else if (result is MetricBaseUnit) {
							if (result is IMetricUnitOffset && (
								p != Measure.Units.Metric.Prefixes.SIPrefixe.None && ((IMetricUnitOffset)result).Prefixe != Measure.Units.Metric.Prefixes.SIPrefixe.None)
								) {
								throw new UnitException("Unable to cast " + result.Symbol + " to " + p.Symbol + result.Symbol);
							}
							result = new PrefixUnit(p, (MetricBaseUnit)result);
						}
						else
							throw new UnitException("Unable to cast " + result.Symbol + " to " + p.Symbol + result.Symbol);
				}
			}
			catch (Exception e) {
				throw new UnitException("Unable to cast " + symbol + " to unit", e);
			}

			return result;
		}

		/// <summary>
		/// Converts the string representation of a unit to its <see cref="Unit"/> equivalent. A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="unit">A string containing a unit to convert.</param>
		/// <param name="result">When this method returns, contains the <see cref="Unit"/> value equivalent to the string contained in <b>unit</b>, if the conversion succeeded, or null if the conversion failed.</param>
		/// <returns><b>true</b> if <b>unit</b> was converted successfully; otherwise, <b>false</b>.</returns>
		public static bool TryParse(string unit, out Unit result) {
			return TryParse(unit, false, out result);
		}

		/// <summary>
		/// Converts the string representation of a unit to its <see cref="Unit"/> equivalent. A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="unit">A string containing a unit to convert. </param>
		/// <param name="ignoreCase">Indicator which specify if method if case-sensitive or not.</param>
		/// <param name="result">When this method returns, contains the <see cref="Unit"/> value equivalent to the string contained in <b>unit</b>, if the conversion succeeded, or null if the conversion failed.</param>
		/// <returns><b>true</b> if <b>unit</b> was converted successfully; otherwise, <b>false</b>.</returns>
		public static bool TryParse(string unit, bool ignoreCase, out Unit result) {
			result = null;

			try {
				result = Parse(unit, ignoreCase);
				return true;
			}
			catch {
				return false;
			}
		}
	}
}
