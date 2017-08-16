using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity acceleration (m.s-2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Acceleration<T> : Quantity<T> {
        /// <summary>
        /// Initiliaze a new instance of <see cref="Acceleration{T}"/>
        /// </summary>
		public Acceleration() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Velocity() / new Units.Metric.SI.Second();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Acceleration{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public Acceleration(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Acceleration{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Acceleration<T>(T value) {
			return new Acceleration<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Acceleration{T}"/> to <see cref="Acceleration{T}"/> of <see cref="double"/>
        /// </summary>
        /// <param name="value"><see cref="Acceleration{T}"/> to convert</param>
        /// <returns><see cref="Acceleration{T}"/> of <see cref="double"/></returns>
        public static implicit operator Acceleration<double>(Acceleration<T> value)
        {
            Acceleration<double> qty = new Acceleration<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Acceleration{T}"/> to <see cref="Acceleration{T}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="Acceleration{T}"/> to convert</param>
        /// <returns><see cref="Acceleration{T}"/> of <see cref="decimal"/></returns>
        public static implicit operator Acceleration<decimal>(Acceleration<T> value)
        {
            Acceleration<decimal> qty = new Acceleration<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Acceleration{T}"/> to <see cref="Acceleration{T}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="Acceleration{T}"/> to convert</param>
        /// <returns><see cref="Acceleration{T}"/> of <see cref="long"/></returns>
        public static implicit operator Acceleration<long>(Acceleration<T> value)
        {
            Acceleration<long> qty = new Acceleration<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Acceleration{T}"/> to <see cref="Acceleration{T}"/> of <see cref="float"/>
        /// </summary>
        /// <param name="value"><see cref="Acceleration{T}"/> to convert</param>
        /// <returns><see cref="Acceleration{T}"/> of <see cref="float"/></returns>
        public static implicit operator Acceleration<float>(Acceleration<T> value)
        {
            Acceleration<float> qty = new Acceleration<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
