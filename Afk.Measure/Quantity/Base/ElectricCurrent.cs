﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of electric current
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the ampere.</remarks>
	public class ElectricCurrent<T> : Quantity<T> {

        /// <summary>
        /// Initiliaze a new instance of <see cref="ElectricCurrent{T}"/>
        /// </summary>
		public ElectricCurrent() {
			this._unit = Units.System.SI.AMPERE;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="ElectricCurrent{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public ElectricCurrent(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="ElectricCurrent{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator ElectricCurrent<T>(T value) {
			return new ElectricCurrent<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="ElectricCurrent{T}"/> to <see cref="ElectricCurrent{T}"/> of <see cref="double"/>
        /// </summary>
        /// <param name="value"><see cref="ElectricCurrent{T}"/> to convert</param>
        /// <returns><see cref="ElectricCurrent{T}"/> of <see cref="double"/></returns>
        public static implicit operator ElectricCurrent<double>(ElectricCurrent<T> value)
        {
            ElectricCurrent<double> qty = new ElectricCurrent<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="ElectricCurrent{T}"/> to <see cref="ElectricCurrent{T}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="ElectricCurrent{T}"/> to convert</param>
        /// <returns><see cref="ElectricCurrent{T}"/> of <see cref="decimal"/></returns>
        public static implicit operator ElectricCurrent<decimal>(ElectricCurrent<T> value)
        {
            ElectricCurrent<decimal> qty = new ElectricCurrent<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="ElectricCurrent{T}"/> to <see cref="ElectricCurrent{T}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="ElectricCurrent{T}"/> to convert</param>
        /// <returns><see cref="ElectricCurrent{T}"/> of <see cref="long"/></returns>
        public static implicit operator ElectricCurrent<long>(ElectricCurrent<T> value)
        {
            ElectricCurrent<long> qty = new ElectricCurrent<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="ElectricCurrent{T}"/> to <see cref="ElectricCurrent{T}"/> of <see cref="float"/>
        /// </summary>
        /// <param name="value"><see cref="ElectricCurrent{T}"/> to convert</param>
        /// <returns><see cref="ElectricCurrent{T}"/> of <see cref="float"/></returns>
        public static implicit operator ElectricCurrent<float>(ElectricCurrent<T> value)
        {
            ElectricCurrent<float> qty = new ElectricCurrent<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion
    }
}
