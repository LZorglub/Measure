using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity of Force (Newton)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Force<T> : Quantity<T> {
        /// <summary>
        /// Initialize a new instance of <see cref="Force"/>
        /// </summary>
		public Force() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Newton();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Force"/>
        /// </summary>
        /// <param name="value"></param>
		public Force(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Force<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Force<T>(T value) {
			return new Force<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Force<T>"/> to <see cref="Force<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Force<T>"/> to convert</param>
        /// <returns><see cref="Force<double>"/></returns>
        public static implicit operator Force<double>(Force<T> value)
        {
            Force<double> qty = new Force<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Force<T>"/> to <see cref="Force<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Force<T>"/> to convert</param>
        /// <returns><see cref="Force<decimal>"/></returns>
        public static implicit operator Force<decimal>(Force<T> value)
        {
            Force<decimal> qty = new Force<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Force<T>"/> to <see cref="Force<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Force<T>"/> to convert</param>
        /// <returns><see cref="Force<long>"/></returns>
        public static implicit operator Force<long>(Force<T> value)
        {
            Force<long> qty = new Force<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Force<T>"/> to <see cref="Force<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Force<T>"/> to convert</param>
        /// <returns><see cref="Force<float>"/></returns>
        public static implicit operator Force<float>(Force<T> value)
        {
            Force<float> qty = new Force<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}