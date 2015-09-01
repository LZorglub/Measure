using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
    /// <summary>
    /// Represents a quantity of energy (Joule)
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class Energy<T> : BaseQuantity<T> {
        /// <summary>
        /// Initialize a new isntance of <see cref="Energy"/>
        /// </summary>
		public Energy() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Joule();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Energy"/>
        /// </summary>
        /// <param name="value"></param>
		public Energy(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Energy<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Energy <T>(T value) {
			return new Energy<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Energy<T>"/> to <see cref="Energy<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Energy<T>"/> to convert</param>
        /// <returns><see cref="Energy<double>"/></returns>
        public static implicit operator Energy<double>(Energy<T> value)
        {
            Energy<double> qty = new Energy<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Energy<T>"/> to <see cref="Energy<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Energy<T>"/> to convert</param>
        /// <returns><see cref="Energy<decimal>"/></returns>
        public static implicit operator Energy<decimal>(Energy<T> value)
        {
            Energy<decimal> qty = new Energy<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Energy<T>"/> to <see cref="Energy<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Energy<T>"/> to convert</param>
        /// <returns><see cref="Energy<long>"/></returns>
        public static implicit operator Energy<long>(Energy<T> value)
        {
            Energy<long> qty = new Energy<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Energy<T>"/> to <see cref="Energy<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Energy<T>"/> to convert</param>
        /// <returns><see cref="Energy<float>"/></returns>
        public static implicit operator Energy<float>(Energy<T> value)
        {
            Energy<float> qty = new Energy<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
