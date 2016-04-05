using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity of Power (Watt)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Power<T> : Quantity<T> {
        /// <summary>
        /// Initialize a new instance of <see cref="Power"/>
        /// </summary>
		public Power() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Watt();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Power"/>
        /// </summary>
        /// <param name="value"></param>
		public Power(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Power<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Power<T>(T value) {
			return new Power<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Power<T>"/> to <see cref="Power<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Power<T>"/> to convert</param>
        /// <returns><see cref="Power<double>"/></returns>
        public static implicit operator Power<double>(Power<T> value)
        {
            Power<double> qty = new Power<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Power<T>"/> to <see cref="Power<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Power<T>"/> to convert</param>
        /// <returns><see cref="Power<decimal>"/></returns>
        public static implicit operator Power<decimal>(Power<T> value)
        {
            Power<decimal> qty = new Power<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Power<T>"/> to <see cref="Power<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Power<T>"/> to convert</param>
        /// <returns><see cref="Power<long>"/></returns>
        public static implicit operator Power<long>(Power<T> value)
        {
            Power<long> qty = new Power<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Power<T>"/> to <see cref="Power<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Power<T>"/> to convert</param>
        /// <returns><see cref="Power<float>"/></returns>
        public static implicit operator Power<float>(Power<T> value)
        {
            Power<float> qty = new Power<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
