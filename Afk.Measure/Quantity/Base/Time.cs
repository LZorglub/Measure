using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of amount of time
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="V"></typeparam>
	/// <remarks>The base unit of this quantity is the <b>V</b> unit.</remarks>
	public class Time<T, V> : Quantity<T> where V : Measure.Units.Metric.SI.Second, new() {

        /// <summary>
        /// Initialize a new instance of <see cref="Time{T,V}"/>
        /// </summary>
		public Time() {
			this._unit = new V();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Time{T,V}"/>
        /// </summary>
        /// <param name="value"></param>
		public Time(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="Time{T,V}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Time<T, V>(T value) {
			return new Time<T, V>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Time{T,V}"/> to <see cref="Time{T, V}"/> of <see cref="double"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T,V}"/> to convert</param>
        /// <returns><see cref="Time{T, V}"/> of <see cref="double"/></returns>
        public static implicit operator Time<double, V>(Time<T, V> value)
        {
            Time<double, V> qty = new Time<double, V>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T,V}"/> to <see cref="Time{T, V}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T,V}"/> to convert</param>
        /// <returns><see cref="Time{T, V}"/> of <see cref="decimal"/></returns>
        public static implicit operator Time<decimal, V>(Time<T, V> value)
        {
            Time<decimal, V> qty = new Time<decimal, V>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T,V}"/> to <see cref="Time{T, V}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T,V}"/> to convert</param>
        /// <returns><see cref="Time{T, V}"/> of <see cref="long"/></returns>
        public static implicit operator Time<long, V>(Time<T, V> value)
        {
            Time<long, V> qty = new Time<long, V>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T,V}"/> to <see cref="Time{T, V}"/> of <see cref="float"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T,V}"/> to convert</param>
        /// <returns><see cref="Time{T, V}"/> of <see cref="float"/></returns>
        public static implicit operator Time<float, V>(Time<T, V> value)
        {
            Time<float, V> qty = new Time<float, V>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }

    /// <summary>
    /// Represents a quantity of amount of time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>The base unit of this quantity is the second.</remarks>
    public class Time<T> : Time<T, Measure.Units.Metric.SI.Second> {

        /// <summary>
        /// Implicit conversion from T to <see cref="Time{T}"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator Time<T>(T value) {
			Time<T> qty = new Time<T>();
			qty._value = value;
			return qty;
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="Time{T}"/> to <see cref="Time{T}"/> of <see cref="double"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T}"/> to convert</param>
        /// <returns><see cref="Time{T}"/> of <see cref="double"/></returns>
        public static implicit operator Time<double>(Time<T> value)
        {
            Time<double> qty = new Time<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T}"/> to <see cref="Time{T}"/> of <see cref="decimal"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T}"/> to convert</param>
        /// <returns><see cref="Time{T}"/> of <see cref="decimal"/></returns>
        public static implicit operator Time<decimal>(Time<T> value)
        {
            Time<decimal> qty = new Time<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T}"/> to <see cref="Time{T}"/> of <see cref="long"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T}"/> to convert</param>
        /// <returns><see cref="Time{T}"/> of <see cref="long"/></returns>
        public static implicit operator Time<long>(Time<T> value)
        {
            Time<long> qty = new Time<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="Time{T}"/> to <see cref="Time{T}"/> of <see cref="float"/>
        /// </summary>
        /// <param name="value"><see cref="Time{T}"/> to convert</param>
        /// <returns><see cref="Time{T}"/> of <see cref="float"/></returns>
        public static implicit operator Time<float>(Time<T> value)
        {
            Time<float> qty = new Time<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
