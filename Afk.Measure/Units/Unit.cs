using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.Metric;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents an unit
	/// </summary>
	public abstract partial class Unit : ICloneable{

		/// <summary>
		/// Dimension define the group of unit
		/// </summary>
		protected Dimension _dimension;

		protected int _exponent;
		protected string _symbol;
		protected bool _isInverted;
		protected Converter.UnitConverter _baseConverter;
		internal ExpandedUnit _expandedUnit;

		#region Properties
		/// <summary>
		/// Gets the unit symbol
		/// </summary>
		public virtual string Symbol {
			get {
				if (_exponent != 1)
					return string.Format("{0}{1}", _symbol , _exponent);

				return _symbol; 
			}
		}

		/// <summary>
		/// Gets the unit symbol without exponent
		/// </summary>
		internal string BaseSymbol {
			get { return _symbol; }
		}

		/// <summary>
		/// Returns a value indicating whether the unit is inverted or not
		/// </summary>
		internal bool IsInverted {
			get { return _isInverted; }
		}

		/// <summary>
		/// Gets the unit exponent
		/// </summary>
		public int Exponent {
			get { return _exponent; }
		}

		/// <summary>
		/// Gets the dimension unit
		/// </summary>
		public Dimension Dimension { get { return _dimension; } }

		/// <summary>
		/// Gets the converter unit
		/// </summary>
		public Converter.UnitConverter BaseConverter {
			get { return _baseConverter; }
		}
		#endregion

		/// <summary>
		/// Initialize a new instance of <see cref="Unit"/>
		/// </summary>
		public Unit() {
			_dimension = new Dimension();
			_isInverted = false;

			_exponent = 1;
			_baseConverter = Converter.UnitConverter.IDENTITY;
			_expandedUnit = new ExpandedUnit(new Unit[] { this }, new int[] { _exponent });
		}

		/// <summary>
		/// Initialize a new instance of <see cref="Unit"/>
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of unit</param>
		public Unit(Dimension dimension)
			: this() {
			_dimension = dimension;
		}

		/// <summary>
		/// Converts the value of the current <see cref="Unit"/> object to its equivalent string representation
		/// </summary>
		/// <returns>A string represenUtation of the value of the current <see cref="Unit"/> object</returns>
		public override string ToString() {
			return this.GetType().Name + " " + this.Symbol;
		}

		/// <summary>
		/// Gets the inverted unit
		/// </summary>
		/// <returns><see cref="Unit"/> inverted</returns>
		public virtual Unit Inverse() {
			Unit i = (Unit)this.Clone();
			i._exponent = -i.Exponent;
			i._dimension = i._dimension.Inverse();
			i._baseConverter = i._baseConverter.Inverse();
			i._isInverted = !i._isInverted;
			i._expandedUnit = i._expandedUnit.Inverse();
			return i;
		}

		/// <summary>
		/// Gets the unit raise to power <b>pow</b>
		/// </summary>
		/// <param name="pow"></param>
		/// <returns></returns>
		public virtual Unit Power(int pow) {
			if (pow == 0) throw new NotImplementedException("Zero power is not implemented");
			Unit i = (pow < 0) ? this.Inverse() : (Unit)this.Clone();

			int value = Math.Abs(pow);
			i._exponent = i.Exponent * value;
			i._dimension = i._dimension * value;
			i._baseConverter = (i._baseConverter.IsLinear) ? i._baseConverter.Power(value) : Afk.Measure.Converter.UnitConverter.NULL;
			i._expandedUnit = i._expandedUnit.Power(value);
			return i;
		}

		/// <summary>
		/// Gets expanded unit which compose the current <see cref="Unit"/>
		/// </summary>
		/// <returns><see cref="ExpandedUnit"/> of current <see cref="Unit"/></returns>
		internal virtual ExpandedUnit GetExpandedUnits() {
			return _expandedUnit;
		}

		/// <summary>
		/// Returns the hash code for this instance
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public int GetUICode() {
			if (string.IsNullOrEmpty(_symbol)) {
				return string.Empty.GetHashCode(); 
			}
			return _symbol.GetHashCode();
		}

		#region ICloneable Membres
		/// <summary>
		/// Creates a new object that is a copy of the current instance
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone() {
			return this.MemberwiseClone();
		}
		#endregion

        public static Afk.Measure.Quantity.Quantity<double> operator *(double value, Unit unit)
        {
            var qty = Dimension.QuantityFrom<double>(unit.Dimension);
            qty.Value = value;
            qty.Unit = unit;
            return qty;
        }

	}
}
