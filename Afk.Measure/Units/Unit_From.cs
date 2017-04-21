using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using Afk.Measure.Units.Metric.SI;
using Afk.Measure.Units.Metric;
using static Afk.Measure.Units.UnitAssembly;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents an unit
	/// </summary>
	public partial class Unit {
		// This file contains all unit static method

		private static object _synchronizedObject = new object();
		private static Regex regUnit = new Regex(@"^(?<Unit>([a-zA-Z]{0,2}°)?[a-zA-Z$¥ ]*)(\^?(?<Exponent>[-+]?\d+))?$", RegexOptions.Compiled);
        private static Dictionary<string, UnitAssembly> unitAssembly;

        /// <summary>
        /// Initialize a new instance of <see cref="Unit"/>
        /// </summary>
        static Unit()
        {
            UnitAssembly current = new UnitAssembly(Assembly.GetExecutingAssembly());
            unitAssembly = new Dictionary<string, UnitAssembly>();
            unitAssembly.Add(current.AssemblyFullName, current);
        }

		/// <summary>
		/// Gets the list of <see cref="Unit"/> know by the assembly
		/// </summary>
		public static Unit[] WellKnownUnits {
			get {
				lock (_synchronizedObject) {
                    return unitAssembly.SelectMany(e => e.Value.WellKnownUnits).ToArray();
				}
			}
		}

		/// <summary>
		/// Gets the list of <see cref="Unit"/> for a specified <see cref="Dimension"/>
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of units</param>
		/// <returns>List of <b>HashUnit</b> which contains the type of <see cref="Unit"/> know in the specified <see cref="Dimension"/></returns>
		internal static IEnumerable<HashUnit> GetUnitsListFromDimension(Dimension dimension) {
			lock (_synchronizedObject) {
                return unitAssembly.Select(e => e.Value.GetUnitsFrom(dimension)).Where(e => e != null).SelectMany(e => e);
            }
		}

        /// <summary>
        /// Loads <see cref="Unit"/> contains in the assembly
        /// </summary>
        /// <param name="assembly"></param>
        public static void LoadAssembly(Assembly assembly)
        {
            lock (_synchronizedObject)
            {
                if (!unitAssembly.ContainsKey(assembly.FullName))
                {
                    UnitAssembly current = new UnitAssembly(assembly);
                    unitAssembly.Add(current.AssemblyFullName, current);
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
            Unit[] knownUnits = WellKnownUnits;

            if (string.IsNullOrEmpty(symbol)) return BaseUnit.UNITONE;

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
					// fluid ounce = fl oz
					string[] unites = symbol.Split(ProductUnitBuilder.SEPARATORS);

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
								Unit knownUnit = knownUnits.FirstOrDefault(e => string.Compare(e.LocalizableSymbol, baseUnit, ignoreCase) == 0);
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

        /// <summary>
        /// Explicit conversion from string to unit
        /// </summary>
        /// <param name="symbol"></param>
        public static explicit operator Unit(string symbol)
        {
            return Unit.Parse(symbol);
        }
	}
}
