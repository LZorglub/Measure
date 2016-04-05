using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of amount of mass
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the gram (kg).</remarks>
	public class Mass<T> : Quantity<T> {

        /// <summary>
        /// Initialize a new instance of <see cref="Mass"/>
        /// </summary>
		public Mass() {
			this._unit = Units.System.SI.GRAM;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Mass"/>
        /// </summary>
        /// <param name="value"></param>
		public Mass(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Mass<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Mass<T>(T value) {
			return new Mass<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Mass<T>"/> to <see cref="Mass<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Mass<T>"/> to convert</param>
        /// <returns><see cref="Mass<double>"/></returns>
        public static implicit operator Mass<double>(Mass<T> value)
        {
            Mass<double> qty = new Mass<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Mass<T>"/> to <see cref="Mass<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Mass<T>"/> to convert</param>
        /// <returns><see cref="Mass<decimal>"/></returns>
        public static implicit operator Mass<decimal>(Mass<T> value)
        {
            Mass<decimal> qty = new Mass<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Mass<T>"/> to <see cref="Mass<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Mass<T>"/> to convert</param>
        /// <returns><see cref="Mass<long>"/></returns>
        public static implicit operator Mass<long>(Mass<T> value)
        {
            Mass<long> qty = new Mass<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Mass<T>"/> to <see cref="Mass<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Mass<T>"/> to convert</param>
        /// <returns><see cref="Mass<float>"/></returns>
        public static implicit operator Mass<float>(Mass<T> value)
        {
            Mass<float> qty = new Mass<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
