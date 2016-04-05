using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of temperature
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the kelvin.</remarks>
	public class Temperature<T> : Quantity<T> {

        /// <summary>
        /// Initialize a new instance of <see cref="Temperature"/>
        /// </summary>
		public Temperature() {
			this._unit = Units.System.SI.KELVIN;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Temperature"/>
        /// </summary>
        /// <param name="value"></param>
		public Temperature(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Temperature<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Temperature<T>(T value) {
			return new Temperature<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Temperature<T>"/> to <see cref="Temperature<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Temperature<T>"/> to convert</param>
        /// <returns><see cref="Temperature<double>"/></returns>
        public static implicit operator Temperature<double>(Temperature<T> value)
        {
            Temperature<double> qty = new Temperature<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Temperature<T>"/> to <see cref="Temperature<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Temperature<T>"/> to convert</param>
        /// <returns><see cref="Temperature<decimal>"/></returns>
        public static implicit operator Temperature<decimal>(Temperature<T> value)
        {
            Temperature<decimal> qty = new Temperature<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Temperature<T>"/> to <see cref="Temperature<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Temperature<T>"/> to convert</param>
        /// <returns><see cref="Temperature<long>"/></returns>
        public static implicit operator Temperature<long>(Temperature<T> value)
        {
            Temperature<long> qty = new Temperature<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Temperature<T>"/> to <see cref="Temperature<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Temperature<T>"/> to convert</param>
        /// <returns><see cref="Temperature<float>"/></returns>
        public static implicit operator Temperature<float>(Temperature<T> value)
        {
            Temperature<float> qty = new Temperature<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
