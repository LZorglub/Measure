using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity of speed (m/s)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Speed <T> : Quantity<T> {
        /// <summary>
        /// Initialize a new instance of <see cref="Speed"/>
        /// </summary>
		public Speed() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Velocity();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Speed"/>
        /// </summary>
        /// <param name="value"></param>
		public Speed(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Speed<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Speed<T>(T value) {
			return new Speed<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Speed<T>"/> to <see cref="Speed<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Speed<T>"/> to convert</param>
        /// <returns><see cref="Speed<double>"/></returns>
        public static implicit operator Speed<double>(Speed<T> value)
        {
            Speed<double> qty = new Speed<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Speed<T>"/> to <see cref="Speed<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Speed<T>"/> to convert</param>
        /// <returns><see cref="Speed<decimal>"/></returns>
        public static implicit operator Speed<decimal>(Speed<T> value)
        {
            Speed<decimal> qty = new Speed<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Speed<T>"/> to <see cref="Speed<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Speed<T>"/> to convert</param>
        /// <returns><see cref="Speed<long>"/></returns>
        public static implicit operator Speed<long>(Speed<T> value)
        {
            Speed<long> qty = new Speed<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Speed<T>"/> to <see cref="Speed<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Speed<T>"/> to convert</param>
        /// <returns><see cref="Speed<float>"/></returns>
        public static implicit operator Speed<float>(Speed<T> value)
        {
            Speed<float> qty = new Speed<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
