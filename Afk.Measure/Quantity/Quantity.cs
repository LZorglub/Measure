using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Operation;
using Afk.Measure.Converter;
using Afk.Measure.Units.Metric;

namespace Afk.Measure.Quantity {
	/// <summary>
	/// Represents a base quantity.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>A quantity is composed of a unit part and a value part. A quantity has no dimension, unit give the dimension.</remarks>
	public class Quantity<T> : ICloneable {
		protected T _value;
		protected Unit _unit;

        #region ctor
        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        public Quantity() : base() {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Quantity(T value, Unit unit) {
            this._value = value;
            this._unit = unit;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Quantity(T value, string unit) : this(value, Unit.Parse(unit)) {
        }
        #endregion

        /// <summary>
        /// Gets the quantity value
        /// </summary>
        public T Value { get { return _value; } internal set { _value = value; } }

		/// <summary>
		/// Get the <see cref="Unit"/>
		/// </summary>
		public Unit Unit { get { return _unit; } internal set { _unit = value; } }

        #region Sum and difference
        /// <summary>
        /// Gets the sum of two <see cref="Quantity"/>
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns><see cref="Quantity"/> equivalent to the additon of <b>left</b> and <b>right</b></returns>
        public static Quantity<T> operator +(Quantity<T> left, Quantity<T> right) {
			if (left.Unit != null && right.Unit != null && !left.Unit.Dimension.Equals(right.Unit.Dimension)) {
				throw new DimensionException();
			}

			if (left.Unit == null || right.Unit == null)
				throw new DimensionException();

			// The two operand have the same dimension
			Quantity<T> qty = (Quantity<T>)left.Clone();

			if (left.Unit != null && right.Unit != null) {
				Number<T, T> n1 = new Number<T, T>(left.Value);

				Number<T, T> n2 = new Number<T, T>(right.ConvertTo(left.Unit).Value);
				qty._value = (n1 + n2).Value;

				qty.Unit = (Unit)left.Unit.Clone();
			}
			else {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.Value);
				qty._value = (n1 + n2).Value;
			}

			return qty;
		}

        /// <summary>
        /// Gets the difference of two <see cref="Quantity"/>
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns><see cref="Quantity"/> equivalent to the difference of <b>left</b> and <b>right</b></returns>
        public static Quantity<T> operator -(Quantity<T> left, Quantity<T> right) {
			if (left.Unit != null && right.Unit != null && !left.Unit.Dimension.Equals(right.Unit.Dimension)) {
				throw new DimensionException();
			}

			if (left.Unit == null || right.Unit == null)
				throw new DimensionException();

			// Les deux opérandes sont de même dimension on peut les sommer
			Quantity<T> qty = (Quantity<T>)left.Clone();

			if (left.Unit != null && right.Unit != null) {
				Number<T, T> n1 = new Number<T, T>(left.Value);

				Number<T, T> n2 = new Number<T, T>(right.ConvertTo(left.Unit).Value);
				qty._value = (n1 - n2).Value;

				qty.Unit = (Unit)left.Unit.Clone();
			}
			else {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.Value);
				qty._value = (n1 - n2).Value;
			}

			return qty;
		}
        #endregion

        /// <summary>
        /// Gets the product of two <see cref="Quantity"/>
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns><see cref="Quantity"/> equivalent to the product of <b>left</b> and <b>right</b></returns>
        public static Quantity<T> operator *(Quantity<T> first, Quantity<T> second) {
			return DoOp(first, second, false);
		}

        /// <summary>
        /// Gets the division of two <see cref="Quantity"/>
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns><see cref="Quantity"/> equivalent to the division of <b>left</b> and <b>right</b></returns>
        public static Quantity<T> operator /(Quantity<T> first, Quantity<T> second) {
			return DoOp(first, second, true);
		}

		#region Comparator operator
		/// <summary>
		/// Compare two quantity
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <param name="func"><see cref="Func"/> to compare elements</param>
		/// <returns>true if the compare is true; otherwise false</returns>
		private static bool Compare(Quantity<T> left, Quantity<T> right, Func<Number<T, T>, Number<T, T>, bool> func) {
			if (left.Unit != null && right.Unit != null && !left.Unit.Dimension.Equals(right.Unit.Dimension)) {
				throw new DimensionException();
			}

			if ((left.Unit == null && right.Unit != null) || (left.Unit != null && right.Unit == null))
				throw new DimensionException();

			if (left.Unit != null && right.Unit != null) {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.ConvertTo(left.Unit).Value);
				return func(n1, n2);
			}
			else {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.Value);
				return func(n1, n2);
			}
		}

		public static bool operator <(Quantity<T> left, Quantity<T> right) {
			return Compare(left, right, (x, y) => x < y);
		}

		public static bool operator <=(Quantity<T> left, Quantity<T> right) {
			return Compare(left, right, (x, y) => x <= y);
		}

		public static bool operator >(Quantity<T> left, Quantity<T> right) {
			return Compare(left, right, (x, y) => x > y);
		}

		public static bool operator >=(Quantity<T> left, Quantity<T> right) {
			return Compare(left, right, (x, y) => x >= y);
		}

		public static bool operator ==(Quantity<T> left, Quantity<T> right) {
			if (Object.ReferenceEquals(left, null) || Object.ReferenceEquals(right, null))
				return Object.ReferenceEquals(left, null) && Object.ReferenceEquals(right, null);

			if (left.Unit != null && right.Unit != null && !left.Unit.Dimension.Equals(right.Unit.Dimension)) {
				return false;
			}

			if ((left.Unit == null && right.Unit != null) || (left.Unit != null && right.Unit == null))
				return false;

			if (left.Unit != null && right.Unit != null) {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.ConvertTo(left.Unit).Value);
				return n1 == n2;
			}
			else {
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.Value);
				return n1 == n2;
			}
		}

		public static bool operator !=(Quantity<T> left, Quantity<T> right) {
			return !(left == right);
		}
		#endregion

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object
		/// </summary>
		/// <param name="value">The object to compare to this instance</param>
		/// <returns>true if <b>value</b> is an instance of <see cref="Dimension"/> and equals the value of this instance; otherwise, false.</returns>
		public override bool Equals(object obj) {
			return base.Equals(obj);
		}

		/// <summary>
		/// Returns the hash code for this instance
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode() {
			return base.GetHashCode();
		}

        /// <summary>
        /// Effectue le produit/quotient de deux <see cref="Quantity"/>
        /// </summary>
        /// <param name="left">Opérande gauche</param>
        /// <param name="right">Opérande droite</param>
        /// <param name="div"><see cref="Boolean"/> indiquant s'il s'agit d'un quotient</param>
        /// <returns><see cref="Quantity"/> représentant le produit/quotient des <see cref="Quantity"/> spécifiées.</returns>
        private static Quantity<T> DoOp(Quantity<T> left, Quantity<T> right, bool div) {
			if (left.Unit != null && right.Unit != null) {
				BaseUnit bu1 = (left.Unit is PrefixUnit) ? ((PrefixUnit)left.Unit).BaseUnit : left.Unit as BaseUnit;
				BaseUnit bu2 = (right.Unit is PrefixUnit) ? ((PrefixUnit)right.Unit).BaseUnit : right.Unit as BaseUnit;
				BaseUnit pu = bu1 * ((div) ? (BaseUnit)bu2.Inverse() : bu2);

				Quantity<T> qty = Dimension.QuantityFrom<T>(pu.Dimension);
				if (qty == null) {
					qty = new Quantity<T>();
					qty.Unit = pu;
				}
				else {
					// On modifie l'unité car pu peut contient surement un contexte différent
					// que celui d'origine
					qty.Unit = pu;
				}

				// 1er : les dimensions ne s'intersectent pas, on effectue juste l'opération
				if (!bu1.Dimension.Cross(bu2.Dimension)) {
					Number<T, T> n1 = new Number<T, T>((left.Unit is PrefixUnit) ? ((PrefixUnit)left.Unit).PrefixConverter.Convert<T>(left.Value) : left.Value);
					Number<T, T> n2 = new Number<T, T>((right.Unit is PrefixUnit) ? ((PrefixUnit)right.Unit).PrefixConverter.Convert<T>(right.Value) : right.Value);
					qty._value = (div) ? ((n1 / n2).Value) : ((n1 * n2).Value);
				}
				else {
					// 2eme : Intersection des dimensions
					UnitConverter converter1 = left.Unit.BaseConverter;
					UnitConverter converter2 = right.Unit.BaseConverter;
					UnitConverter converter3 = qty.Unit.BaseConverter;

					if (converter1 == UnitConverter.NULL || converter2 == UnitConverter.NULL || converter3 == UnitConverter.NULL) {
						// Si on ne peut pas exprimer les quantités dans leur unité de base on essaye
						// de trouver un converter compatible entre chaque unité.
						// m.°C ne peut pas être convertit en m.K car on ne sait pas quelle quantité
						// répartir, 5m * 2°C = 10 m.°C = 283.15m.K ou 5m * 2°C = 5m * 275.15K = 1375.15m.K
						// Par contre m.°C * °C peut être calculé sans passer par les conversions de base
						UnitConverter[] converters = FindBestConverter(left.Unit, right.Unit, qty.Unit);

						Number<T, T> n1 = new Number<T, T>(converters[0].Convert<T>(left.Value));
						Number<T, T> n2 = new Number<T, T>(converters[1].Convert<T>(right.Value));
						qty._value = (div) ? ((n1 / n2).Value) : ((n1 * n2).Value);
					}
					else {
						Number<T, T> n1 = new Number<T, T>(left.Unit.BaseConverter.Convert<T>(left.Value));
						Number<T, T> n2 = new Number<T, T>(right.Unit.BaseConverter.Convert<T>(right.Value));
						qty._value = (div) ? ((n1 / n2).Value) : ((n1 * n2).Value);

						// Expression dans l'unité résultante
						if (qty.Unit != null && qty.Unit != BaseUnit.UNITONE) {
							qty._value = qty.Unit.BaseConverter.Inverse().Convert<T>(qty._value);
						}
					}
				}

				// Expression dans le metrique du premier opérande
				if (qty.Unit != null && qty.Unit != BaseUnit.UNITONE) {
					if (left.Unit is PrefixUnit && qty.Unit is Measure.Units.MetricBaseUnit) {
						Measure.Units.Metric.Prefixes.SIPrefixe p = ((PrefixUnit)left.Unit).Prefixe;
						if (p.Exponent != Measure.Units.Metric.Prefixes.ExponentPrefixes.None ||
							(qty.Unit is IMetricUnitOffset && ((IMetricUnitOffset)qty.Unit).Prefixe.Exponent != p.Exponent)) {
							return qty.ConvertTo(new PrefixUnit(p, (Measure.Units.MetricBaseUnit)qty.Unit));
						}
					}
				}

				return qty;
			}
			else {
				Quantity<T> qty = (Quantity<T>)left.Clone();
				Number<T, T> n1 = new Number<T, T>(left.Value);
				Number<T, T> n2 = new Number<T, T>(right.Value);
				qty._value = (div) ? ((n1 / n2).Value) : ((n1 * n2).Value);
				if (qty.Unit == null && right.Unit != null) qty.Unit = (Unit)right.Unit.Clone();
				return qty;
			}
		}

		/// <summary>
		/// Gets the best converter for <b>unitA</b> and <b>unitB</b> to <b>unitF</b>
		/// </summary>
		/// <param name="unitA"></param>
		/// <param name="unitB"></param>
		/// <param name="unitF"></param>
		/// <returns>Array of two converters for <b>unitA</b> and <b>unitB</b></returns>
		private static UnitConverter[] FindBestConverter(Unit unitA, Unit unitB, Unit unitF) {
			int index = 0;

			// Gets the elementary unit of each unit
			var uA = unitA.GetExpandedUnits();
			var uB = unitB.GetExpandedUnits();
			var uF = unitF.GetExpandedUnits();

			// Gets the dimension of final unit
			int[] dims = unitF.Dimension.ToArray().ToArray<int>();
			UnitConverter[] uConverterA = new UnitConverter[dims.Length];
			UnitConverter[] uConverterB = new UnitConverter[dims.Length];

			// Gets the units on a specific dimension
			IEnumerable<KeyValuePair<Unit, int>> uABase = uA.Where(e => e.Key.Dimension.ToArray()[index] != 0);
			IEnumerable<KeyValuePair<Unit, int>> uBBase = uB.Where(e => e.Key.Dimension.ToArray()[index] != 0);
			IEnumerable<KeyValuePair<Unit, int>> uFBase = uF.Where(e => e.Key.Dimension.ToArray()[index] != 0);

			// Specify if there are one converter not linear in the specific dimension
			IEnumerable<KeyValuePair<Unit, int>> uANotLinear = uABase.Where(e => !e.Key.BaseConverter.IsLinear);
			IEnumerable<KeyValuePair<Unit, int>> uBNotLinear = uBBase.Where(e => !e.Key.BaseConverter.IsLinear);

			for (index = 0; index < dims.Length; index++) {
				// Count the basic unit on this dimension
				int uABaseCount = uABase.Count();
				int uBBaseCount = uBBase.Count();
				int uFBaseCount = uFBase.Count();

				// Basic unit only in A or B are keeping
				if (uABaseCount != 0 && uBBaseCount == 0) {
					uConverterA[index] = UnitConverter.IDENTITY;
				}
				else if (uABaseCount == 0 && uBBaseCount != 0) {
					uConverterB[index] = UnitConverter.IDENTITY;
				}
				else if (uABaseCount != 0 && uBBaseCount != 0 && uFBaseCount == 0) {
					// Les unités s'annulent, on convertit si elles ne sont pas identiques
					// Pour savoir si elles ne sont pas identiques, on recherche si une unité de base dans uA n'existe pas dans uB
					if (uABaseCount != uBBaseCount || uABase.Where(e => !uBBase.Contains(e, new ExpandedUnitComparer())).Count() != 0) {
						// Les unités linéaires utilisent leur converter de base
						if (uANotLinear.Count() == 0 && uBNotLinear.Count() == 0) {
							// Sample s°C / hour
							uConverterA[index] = UnitConverter.IDENTITY;
							uConverterB[index] = UnitConverter.IDENTITY;
							foreach (KeyValuePair<Unit, int> rA in uABase)
								uConverterA[index] = uConverterA[index].Concat(rA.Key.BaseConverter.Power(rA.Value));
							foreach (KeyValuePair<Unit, int> rB in uBBase)
								uConverterB[index] = uConverterB[index].Concat(rB.Key.BaseConverter.Power(rB.Value));
						}
						else {
							// Sample m°C / K
							// Un des convertisseurs n'est pas linéaire, on essaye de trouver
							// quelle unité peut être exprimée dans l'autre.
							// Une unité non linéaire ne pourra être convertie que si son exposant est 1
							bool bestA = (uA.Count() == 1 && uA.ElementAt(0).Value == 1); // Si true comme les unités s'annulent on a Sum(uB) = -1
							bool bestB = (uB.Count() == 1 && uA.ElementAt(0).Value == 1); // Si true comme les unités s'annulent on a Sum(uA) = -1

							if (bestA && !bestB) {
								// L'unité A peut être convertie en B
								uConverterA[index] = uBBase.ElementAt(0).Key.BaseConverter.Inverse().Concat(uABase.ElementAt(0).Key.BaseConverter);
							}
							else if (!bestA && bestB) {
								uConverterB[index] = uABase.ElementAt(0).Key.BaseConverter.Inverse().Concat(uBBase.ElementAt(0).Key.BaseConverter);
							}
							else {
								uConverterA[index] = UnitConverter.NULL;
								uConverterB[index] = UnitConverter.NULL;
							}
						}
					}
					else {
						// Sample m°C / °C
					}
				}
				else if (uABaseCount != 0 && uBBaseCount != 0 && uFBaseCount != 0) {
					// Aucune conversion n'est nécessaire puisque le produit d'unité préserve les unités de base
					uConverterA[index] = UnitConverter.IDENTITY;
					uConverterB[index] = UnitConverter.IDENTITY;
				}
			}

			// Le converter final est la concaténation des différents converteurs d'unités de base
			UnitConverter[] converter = new UnitConverter[] { MergeConverter(uConverterA), MergeConverter(uConverterB) };
			converter = converter.Select(e => (e == null) ? UnitConverter.IDENTITY : e).ToArray();

			// Conversion des préfixes
			if (unitA is PrefixUnit) {
				converter[0] = ((PrefixUnit)unitA).PrefixConverter.Concat(converter[0]);
			}
			if (unitB is PrefixUnit) {
				converter[1] = ((PrefixUnit)unitB).PrefixConverter.Concat(converter[1]);
			}

			return converter;
		}

		/// <summary>
		/// Merge a array of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="converters">Array of <see cref="UnitConverter"/></param>
		/// <returns>A <see cref="UnitConverter"/> equivalent to the sum of each ocnverter in <b>converters</b></returns>
		private static UnitConverter MergeConverter(UnitConverter[] converters) {
			UnitConverter converter = null;
			foreach (UnitConverter baseConverter in converters.Where(e => e != null)) {
				if (converter == null)
					converter = baseConverter;
				else if (baseConverter.IsLinear && converter.IsLinear)
					converter = converter.Concat(baseConverter);
				else
					converter = UnitConverter.NULL;
			}
			return converter;
		}

		#region ICloneable Membres
		/// <summary>
		/// Creates a new object that is a copy of the current instance
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone() {
			object clone = this.MemberwiseClone();
			if (this.Unit != null) {
				((Quantity<T>)clone)._unit = (Unit)this.Unit.Clone();
			}
			return clone;
		}

        #endregion

        /// <summary>
        /// Convert a quantity in the specified <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"><see cref="Unit"/></param>
        /// <returns><see cref="Quantity"/> in specified unit</returns>
        public Quantity<T> ConvertTo(Unit unit) {
			// Unit must be same dimension
			if (this.Unit != null && !this.Unit.Dimension.Equals(unit.Dimension)) {
				throw new DimensionException();
			}

			Quantity<T> qty = (Quantity<T>)this.Clone();
			if (this.Unit == null) {
				qty.Unit = (Unit)unit.Clone();
				qty.Value = this.Value;
				return qty;
			}
			qty.Unit = (Unit)unit.Clone();

			if (this.Unit.BaseConverter == UnitConverter.NULL || unit.BaseConverter == UnitConverter.NULL) {
				// If one unit can not be convert as a basic unit, we check if convert is possible by checking that each
				// necessary expanded unit converter is linear.
				// s.°C can not be convert into s.K because we don't know the quantity of °C to dispatch
				// Sample : 5s * 2°C = 10 s.°C = 283.15s.K or 5s * 2°C = 5s * 275.15K = 1375.15s.K
				// But s.°C can be convert in en h.°C
				var uA = this.Unit.GetExpandedUnits();
				var uB = unit.GetExpandedUnits();

				// Don't keep the unit with the same exponent
				IEnumerable<KeyValuePair<Unit, int>> uAR = uA.Where(e => !uB.Contains(e, new ExpandedUnitComparer()));
				IEnumerable<KeyValuePair<Unit, int>> uBR = uB.Where(e => !uA.Contains(e, new ExpandedUnitComparer()));

				// If among the selected unit one is not linear the conversion is not able
				var uNotLinear = from e in uAR.Concat(uBR) where !e.Key.BaseConverter.IsLinear select e;
				if (uNotLinear.Count() > 0) {
					throw new Exception("Unable to convert " + this.Unit.Symbol + " to " + unit.Symbol);
				}

				// Build the final converter = unitA converter (source) * Inverse unitB converter (dest)
				UnitConverter finalConverter = UnitConverter.IDENTITY;
				foreach (var rU in uAR) {
					Measure.Converter.UnitConverter unitConverter = (rU.Value > 0) ? rU.Key.BaseConverter : rU.Key.BaseConverter.Inverse();
					for (int c = 0; c < System.Math.Abs(rU.Value); c++) {
						finalConverter = finalConverter.Concat(unitConverter);
					}
				}

				foreach (var rU in uBR) {
					Measure.Converter.UnitConverter unitConverter = (rU.Value > 0) ? rU.Key.BaseConverter.Inverse() : rU.Key.BaseConverter;
					for (int c = 0; c < System.Math.Abs(rU.Value); c++) {
						finalConverter = finalConverter.Concat(unitConverter);
					}
				}

				// If finalConverter is null, conversion is not able
				if (finalConverter == UnitConverter.NULL) {
					throw new Exception("Unable to convert " + this.Unit.Symbol + " to " + unit.Symbol);
				}

				T valeur = (finalConverter == UnitConverter.IDENTITY) ? this.Value : finalConverter.Convert<T>(this.Value);
				// Convert the prefix if needed
				valeur = (this.Unit is PrefixUnit) ? ((PrefixUnit)this.Unit).PrefixConverter.Convert<T>(valeur) : valeur;
				qty.Value = (unit is PrefixUnit) ? ((PrefixUnit)unit).PrefixConverter.Inverse().Convert<T>(valeur) : valeur;
			}
			else {
				// Converter are valid, convert by using baseconverter
				T valeur = this.Unit.BaseConverter.Convert<T>(this.Value);
				qty.Value = unit.BaseConverter.Inverse().Convert<T>(valeur);
			}

			return qty;
		}

        /// <summary>
        /// Convert a quantity in the specified <see cref="TUnit"/>
        /// </summary>
        /// <typeparam name="TUnit">Type of unit</typeparam>
        /// <returns><see cref="Quantity"/> in specified unit</returns>
        public Quantity<T> ConvertTo<TUnit>() where TUnit : Unit, new()
        {
            return ConvertTo(new TUnit());
        }

        /// <summary>
        /// Convert a quantity in the specified <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"><see cref="Unit"/></param>
        /// <returns><see cref="Quantity"/> in specified unit</returns>
        public Quantity<T> ConvertTo(string unit)
        {
            if (string.IsNullOrEmpty(unit)) throw new ArgumentException(nameof(unit));
            return ConvertTo(Unit.Parse(unit));
        }

        /// <summary>
        /// Implicit conversion from <typeparamref name="T"/> to <see cref="Quantity"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Quantity<T>(T value)
        {
            Quantity<T> qty = new Quantity<T>(value, BaseUnit.UNITONE);
            return qty;
        }

        #region Explicit conversion : This set of conversion are explicit otherwise we will have an error with implicit conversion in inherited class
        /// <summary>
        /// Conversion explicit d'une quantité en son type T
        /// </summary>
        /// <param name="value"><see cref="Quantity"/> à convertir</param>
        /// <returns>T représentant la quantité</returns>
        /// <remarks>En fonction du métrique de l'unité, un facteur est appliqué à T.</remarks>
        public static explicit operator T(Quantity<T> value) {
			if (value == null) return default(T);

			if (value.Unit != null && value.Unit is PrefixUnit) {
				return ((PrefixUnit)value.Unit).PrefixConverter.Convert<T>(value.Value);
			}

			return value.Value;
		}

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<int>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<int>"/></returns>
        public static explicit operator Quantity<int>(Quantity<T> value)
        {
            Quantity<int> qty = new Quantity<int>();
            qty._value = Convert.ToInt32(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<double>"/></returns>
        public static explicit operator Quantity<double>(Quantity<T> value)
        {
            Quantity<double> qty = new Quantity<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<decimal>"/></returns>
        public static explicit operator Quantity<decimal>(Quantity<T> value)
        {
            Quantity<decimal> qty = new Quantity<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<long>"/></returns>
		public static explicit operator Quantity<long>(Quantity<T> value)
        {
            Quantity<long> qty = new Quantity<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<float>"/></returns>
		public static explicit operator Quantity<float>(Quantity<T> value)
        {
            Quantity<float> qty = new Quantity<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

        /// <summary>
        /// Converts the value of the current <see cref="Quantity"/> object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current <see cref="Quantity"/> object</returns>
        public override string ToString() {
			return string.Format("{0} {1} {2}", this.GetType().Name, _value, _unit);
		}
    }

}
