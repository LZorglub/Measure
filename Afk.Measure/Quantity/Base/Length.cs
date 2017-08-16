using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of length
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the meter.</remarks>
	public class Length<T> : Quantity<T> {

        /// <summary>
        /// Initiliaze a new instance of <see cref="Length{T}"/>
        /// </summary>
		public Length() {
			this._unit = Units.System.SI.METER;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Length{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public Length(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Length{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Length<T>(T value) {
			return new Length<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Length{T}"/> to <see cref="Length{T}"/> of <see cref="double"/>
        /// </summary>
        /// <param name="value"><see cref="Length{T}"/> to convert</param>
        /// <returns><see cref="Length{T}"/> of <see cref="double"/></returns>
        public static implicit operator Length<double>(Length<T> value)
        {
            Length<double> qty = new Length<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Length{T}"/> to <see cref="Length{T}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="Length{T}"/> to convert</param>
        /// <returns><see cref="Length{T}"/> of <see cref="decimal"/></returns>
        public static implicit operator Length<decimal>(Length<T> value)
        {
            Length<decimal> qty = new Length<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Length{T}"/> to <see cref="Length{T}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="Length{T}"/> to convert</param>
        /// <returns><see cref="Length{T}"/> of <see cref="long"/></returns>
        public static implicit operator Length<long>(Length<T> value)
        {
            Length<long> qty = new Length<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Length{T}"/> to <see cref="Length{T}"/> of <see cref="float"/>
        /// </summary>
        /// <param name="value"><see cref="Length{T}"/> to convert</param>
        /// <returns><see cref="Length{T}"/> of <see cref="float"/></returns>
        public static implicit operator Length<float>(Length<T> value)
        {
            Length<float> qty = new Length<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
