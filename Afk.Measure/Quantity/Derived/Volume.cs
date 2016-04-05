using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity of volume (m3)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Volume<T> : Quantity<T> {
        /// <summary>
        /// Initialize a new instance of <see cref="Volume"/>
        /// </summary>
		public Volume() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Volume();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Volume"/>
        /// </summary>
        /// <param name="value"></param>
		public Volume(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Volume<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Volume<T>(T value) {
			return new Volume<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Volume<T>"/> to <see cref="Volume<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Volume<T>"/> to convert</param>
        /// <returns><see cref="Volume<double>"/></returns>
        public static implicit operator Volume<double>(Volume<T> value)
        {
            Volume<double> qty = new Volume<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Volume<T>"/> to <see cref="Volume<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Volume<T>"/> to convert</param>
        /// <returns><see cref="Volume<decimal>"/></returns>
        public static implicit operator Volume<decimal>(Volume<T> value)
        {
            Volume<decimal> qty = new Volume<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Volume<T>"/> to <see cref="Volume<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Volume<T>"/> to convert</param>
        /// <returns><see cref="Volume<long>"/></returns>
        public static implicit operator Volume<long>(Volume<T> value)
        {
            Volume<long> qty = new Volume<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Volume<T>"/> to <see cref="Volume<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Volume<T>"/> to convert</param>
        /// <returns><see cref="Volume<float>"/></returns>
        public static implicit operator Volume<float>(Volume<T> value)
        {
            Volume<float> qty = new Volume<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
