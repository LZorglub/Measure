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
	public class Time<T, V> : BaseQuantity<T> where V : Measure.Units.Metric.SI.Second, new() {

		public Time() {
			this._unit = new V();
		}

		public Time(T value) : this() {
			this._value = value;
		}

		public static implicit operator Time<T, V>(T value) {
			return new Time<T, V>(value);
		}
	}

	/// <summary>
	/// Represents a quantity of amount of time
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the second.</remarks>
	public class Time<T> : Time<T, Measure.Units.Metric.SI.Second> {

		public static implicit operator Time<T>(T value) {
			Time<T> qty = new Time<T>();
			qty._value = value;
			return qty;
		}
	}
}
