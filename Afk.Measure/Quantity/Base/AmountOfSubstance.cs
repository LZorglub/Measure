using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of amount of substance
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the mole.</remarks>
	public class AmountOfSubstance<T> : Quantity<T> {

        /// <summary>
        /// Initialize a new instance of <see cref="AmountOfSubstance{T}"/>
        /// </summary>
		public AmountOfSubstance() {
			this._unit = Units.System.SI.MOLE;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="AmountOfSubstance{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public AmountOfSubstance(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="AmountOfSubstance{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator AmountOfSubstance<T>(T value) {
			return new AmountOfSubstance<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="AmountOfSubstance{T}"/> to AmountOfSubstance of double type
        /// </summary>
        /// <param name="value"><see cref="AmountOfSubstance{T}"/> to convert</param>
        /// <returns><see cref="AmountOfSubstance{T}"/> of double type</returns>
        public static implicit operator AmountOfSubstance<double>(AmountOfSubstance<T> value)
        {
            AmountOfSubstance<double> qty = new AmountOfSubstance<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="AmountOfSubstance{T}"/> to <see cref="AmountOfSubstance{T}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="AmountOfSubstance{T}"/> to convert</param>
        /// <returns><see cref="AmountOfSubstance{T}"/> of <see cref="decimal"/></returns>
        public static implicit operator AmountOfSubstance<decimal>(AmountOfSubstance<T> value)
        {
            AmountOfSubstance<decimal> qty = new AmountOfSubstance<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="AmountOfSubstance{T}"/> to <see cref="AmountOfSubstance{T}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="AmountOfSubstance{T}"/> to convert</param>
        /// <returns><see cref="AmountOfSubstance{T}"/> of <see cref="long"/></returns>
        public static implicit operator AmountOfSubstance<long>(AmountOfSubstance<T> value)
        {
            AmountOfSubstance<long> qty = new AmountOfSubstance<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="AmountOfSubstance{T}"/> to AmountOfSubstance of type float
        /// </summary>
        /// <param name="value"><see cref="AmountOfSubstance{T}"/> to convert</param>
        /// <returns><see cref="AmountOfSubstance{T}"/> of float type</returns>
        public static implicit operator AmountOfSubstance<float>(AmountOfSubstance<T> value)
        {
            AmountOfSubstance<float> qty = new AmountOfSubstance<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion
    }
}
