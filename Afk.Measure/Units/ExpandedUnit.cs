using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Converter;
using System.Collections;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents the base unit list which compose a <see cref="Unit"/>.
	/// </summary>
	/// <remarks>Each complex unit must retain the base unit.
	/// For sample the Wh which dimension is m2s-2kg1 (same like Joule) must retain that its contain a hour 
	/// component m2s-3h1kg1. Without that the converter will be wrong.
	/// </remarks>
	internal class ExpandedUnit : IEnumerable<KeyValuePair<Unit, int>> {
		private Unit[] _units;
		private int[] _power;
		private string _symbol;
		private UnitConverter _baseConverter;
		private Dimension _dimension;
		private int _exponent;

		private const char SEPARATOR = (char)183;

		private object _synchronizedObject;

		/// <summary>
		/// Initialize a new instance of <see cref="ExpandedUnit"/>
		/// </summary>
		/// <param name="units">Array of elementary unit which compose the main unit.</param>
		/// <param name="power">Array of power for each elementary unit.</param>
		internal ExpandedUnit(Unit[] units, int[] power) {
			if (units == null) throw new ArgumentNullException("units");
			if (power == null) throw new ArgumentNullException("power");

			if (units.Length != power.Length) throw new ArgumentException("units size not equal power size");

			if (power.Contains(0)) throw new ArgumentException("power null not allowed");

			_units = units; _power = power; _synchronizedObject = new object();

			// Calculate dimension
			_dimension = Dimension.None;
			for (int index = 0; index < _units.Length; index++) {
				_dimension = _dimension + (_units[index].Dimension * _power[index]);
			}

			// Main exponent is the first power.
			_exponent = (_power.Length > 0) ? _power[0] : 1;
		}

		/// <summary>
		/// Gets the symbol of <see cref="ExpandedUnit"/>
		/// </summary>
		public string Symbol {
			get {
				lock (_synchronizedObject) {
					if (_symbol == null) {
						#region Build product symbol
						StringBuilder builderSymbol = new StringBuilder();

						for (int index = 0; index < _units.Length; index++) {
							if (index > 0)
								builderSymbol.Append(SEPARATOR);
							builderSymbol.Append(_units[index].BaseSymbol);
							if (_power[index] != 1) {
								builderSymbol.Append(_power[index]);
							}
						}
						_symbol = builderSymbol.ToString();
						#endregion
					}
				}
				return _symbol;
			}
		}

		/// <summary>
		/// Gets the <see cref="UnitConverter"/> of <see cref="ExpandedUnit"/>
		/// </summary>
		public UnitConverter BaseConverter {
			get {
				lock (_synchronizedObject) {
					if (_baseConverter == null) {
						#region Création du converteur
						bool notSet = true; _baseConverter = UnitConverter.IDENTITY;
						for (int index = 0; index < _units.Length; index++) {
							Measure.Converter.UnitConverter unitConverter = (_power[index] > 0) ? _units[index].BaseConverter : ((_units[index].BaseConverter.IsLinear) ? _units[index].BaseConverter.Inverse() : Measure.Converter.UnitConverter.NULL);
							for (int c = 0; c < Math.Abs(_power[index]); c++) {
								if (notSet ||
									(_baseConverter.IsLinear && unitConverter.IsLinear))
									_baseConverter = _baseConverter.Concat(unitConverter);
								else
									_baseConverter = Measure.Converter.UnitConverter.NULL;
								notSet = false;
							}
						}
						#endregion
					}
				}

				return _baseConverter;
			}
		}

		/// <summary>
		/// Gets the <see cref="Dimension"/> of <see cref="ExpandedUnit"/>
		/// </summary>
		public Dimension Dimension {
			get { return _dimension; }
		}

		/// <summary>
		/// Gets the exponent of <see cref="ExpandedUnit"/>
		/// </summary>
		public int Exponent {
			get { return _exponent; }
		}

		/// <summary>
		/// Gets the inverted of <see cref="ExpandedUnit"/>
		/// </summary>
		/// <returns><see cref="ExpandedUnit"/> inverted.</returns>
		public ExpandedUnit Inverse() {
			return new ExpandedUnit(_units, _power.Select(e => e * -1).ToArray());
		}

		/// <summary>
		/// Gets the powered <see cref="ExpandedUnit"/>
		/// </summary>
		/// <param name="pow">Power to raise.</param>
		/// <returns><see cref="ExpandedUnit"/> powered by <b>pow</b>.</returns>
		public ExpandedUnit Power(int pow) {
			if (pow == 0) throw new NotImplementedException("Zero power is not implemented");
			return new ExpandedUnit(_units, _power.Select(e => e * pow).ToArray());
		}

		/// <summary>
		/// Get the sum of two <see cref="ExpandedUnit"/>
		/// </summary>
		/// <param name="unitA">First <see cref="ExpandedUnit"/></param>
		/// <param name="unitB">Second <see cref="ExpandedUnit"/></param>
		/// <returns><see cref="ExpandedUnit"/> equivalent to the sum of <b>eUnitA</b> and <b>eUnitB</b></returns>
		/// <remarks>We keep each elementary unit to build the final <see cref="ExpandedUnit"/>
		/// s*h != s2 but s*h = s1*h1
		/// The negate unit are lost, for sample m.s/h = m1
		/// </remarks>
		public static ExpandedUnit operator +(ExpandedUnit unitA, ExpandedUnit unitB) {
			if (unitA == null) throw new ArgumentNullException(nameof(unitA));
			if (unitB == null) throw new ArgumentNullException(nameof(unitB));

			List<Unit> eResult = new List<Unit>();
			List<int> ePower = new List<int>();

			// We keep the order of unit A
			for(int i=0; i < unitA._units.Length; i++) {
				int uiCode = unitA._units[i].GetUICode();
				int power = unitA._power[i];

				// The same unit are merge
				for(int j=0; j < unitB._units.Length; j++) {
					if (unitB._units[j].GetUICode() == uiCode)
						power += unitB._power[j];
				}

				if (power != 0) {
					eResult.Add(unitA._units[i]); ePower.Add(power);
				}
			}

			// We add unit of B not present in unit A
			for (int i = 0; i < unitB._units.Length; i++) {
				int uiCode = unitB._units[i].GetUICode();

				if (unitA._units.Where(e => e.GetUICode() == uiCode).Count() == 0) {
					bool append = false;
					// We keep the order of unit by dimension 
					// For sample m.s * kg.h = m.s.h.kg
					for (int k = 0; !append && k < eResult.Count - 1; k++) {
						if (eResult[k].Dimension.Equals(unitB._units[i].Dimension)) {
							eResult.Insert(k + 1, unitB._units[i]);
							ePower.Insert(k + 1, unitB._power[i]);
							append = true;
						}
					}
					if (!append) {
						eResult.Add(unitB._units[i]); ePower.Add(unitB._power[i]);
					}
				}
			}

			// Dimension of new ExpandedUnit
			Dimension dimension = Dimension.None;
			for (int index = 0; index < eResult.Count; index++) {
				dimension = dimension + (eResult[index].Dimension * ePower[index]);
			}

			// Remove the units which not cross the final dimension (for sample h.s-1 is not present in final dimension)
			List<Unit> unites = new List<Unit>();
			List<int> exponents = new List<int>();
			for (int index = 0; index < eResult.Count; index++) {
				if (eResult[index].Dimension.Cross(dimension)) {
					unites.Add(eResult[index]); exponents.Add(ePower[index]);
				}
			}

			return new ExpandedUnit(unites.ToArray(), exponents.ToArray());
		}

		#region IEnumerable<KeyValuePair<Unit,int>> Membres
		/// <summary>
		/// Returns an enumerator that iterates through a collection of Unit/Exponent
		/// </summary>
		/// <returns>An IEnumerator object that can be used to iterate through the collection of Unit/power</returns>
		public IEnumerator<KeyValuePair<Unit, int>> GetEnumerator() {
			return new ExpandedUnitEnumerator(this);
		}

		#endregion

		#region IEnumerable Membres

		/// <summary>
		/// Returns an enumerator that iterates through a collection of Unit/Exponent
		/// </summary>
		/// <returns>An IEnumerator object that can be used to iterate through the collection of Unit/power</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return new ExpandedUnitEnumerator(this);
		}

		#endregion

		/// <summary>
		/// Supports a simple iteration over a Unit/power collection
		/// </summary>
		internal class ExpandedUnitEnumerator : IEnumerator<KeyValuePair<Unit, int>> {

			private ExpandedUnit _owner;
			private int index;

			/// <summary>
			/// Initialize a new instance of <see cref="ExpandedUnitEnumerator"/>
			/// </summary>
			/// <param name="owner">The <see cref="ExpandedUnit"/> owner of this enumerator.</param>
			public ExpandedUnitEnumerator(ExpandedUnit owner) {
				if (owner == null) throw new ArgumentNullException("owner");
				_owner = owner;
				index = -1;
			}

			#region IEnumerator<KeyValuePair<Unit,int>> Membres
			/// <summary>
			/// Gets the current element in the collection. 
			/// </summary>
			public KeyValuePair<Unit, int> Current {
				get { return new KeyValuePair<Unit,int>(_owner._units[index], _owner._power[index]); }
			}

			#endregion

			#region IDisposable Membres
			/// <summary>
			/// Dispose the object.
			/// </summary>
			public void Dispose() {
				
			}

			#endregion

			#region IEnumerator Membres
			/// <summary>
			/// Gets the current element in the collection. 
			/// </summary>
			object IEnumerator.Current {
				get { return this.Current; }
			}

			/// <summary>
			/// Advances the enumerator to the next element of the collection. 
			/// </summary>
			/// <returns></returns>
			public bool MoveNext() {
				if (index < _owner._units.Length - 1) {
					index++;
					return true;
				}

				return false;
			}

			/// <summary>
			/// Sets the enumerator to its initial position, which is before the first element in the collection. 
			/// </summary>
			public void Reset() {
				index = -1;
			}

			#endregion
		}

	}

	/// <summary>
	/// Defines methods to support the comparison of <see cref="Unit"/> for equality.
	/// </summary>
	internal class ExpandedUnitComparer : IEqualityComparer<KeyValuePair<Unit, int>> {
		#region IEqualityComparer<KeyValuePair<Unit,int>> Membres

		/// <summary>
		/// Determines whether the specified objects are equal.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>true if the specified objects are equal; otherwise, false.</returns>
		public bool Equals(KeyValuePair<Unit, int> x, KeyValuePair<Unit, int> y) {
            // Becarefull to test the UI code and not the Hash code
			return (x.Value == y.Value && x.Key.GetUICode() == y.Key.GetUICode());
		}

		/// <summary>
		/// Returns a hash code for the specified object.
		/// </summary>
		/// <param name="obj">The Object for which a hash code is to be returned</param>
		/// <returns>A hash code for the specified object.</returns>
		public int GetHashCode(KeyValuePair<Unit, int> obj) {
			return obj.GetHashCode();
		}

		#endregion
	}
}
