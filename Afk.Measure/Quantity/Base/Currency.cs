using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of currency
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the euro.</remarks>
	public class Currency<T> : Quantity<T> {
        /// <summary>
        /// Initiliaze a new instance of <see cref="Currency"/>
        /// </summary>
		public Currency() {
			this._unit = new Units.Currency.Euro();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Currency"/>
        /// </summary>
        /// <param name="value"></param>
		public Currency(T value)
			: this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Currency<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Currency<T>(T value) {
			return new Currency<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Currency<T>"/> to <see cref="Currency<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Currency<T>"/> to convert</param>
        /// <returns><see cref="Currency<double>"/></returns>
        public static implicit operator Currency<double>(Currency<T> value)
        {
            Currency<double> qty = new Currency<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Currency<T>"/> to <see cref="Currency<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Currency<T>"/> to convert</param>
        /// <returns><see cref="Currency<decimal>"/></returns>
        public static implicit operator Currency<decimal>(Currency<T> value)
        {
            Currency<decimal> qty = new Currency<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Currency<T>"/> to <see cref="Currency<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Currency<T>"/> to convert</param>
        /// <returns><see cref="Currency<long>"/></returns>
        public static implicit operator Currency<long>(Currency<T> value)
        {
            Currency<long> qty = new Currency<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Currency<T>"/> to <see cref="Currency<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Currency<T>"/> to convert</param>
        /// <returns><see cref="Currency<float>"/></returns>
        public static implicit operator Currency<float>(Currency<T> value)
        {
            Currency<float> qty = new Currency<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion
    }
}
