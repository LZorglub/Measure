using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of temperature
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the kelvin.</remarks>
	public class Temperature<T> : Quantity<T> {

		public Temperature() {
			this._unit = Units.System.SI.KELVIN;
		}

		public Temperature(T value) : this() {
			this._value = value;
		}

		public static implicit operator Temperature<T>(T value) {
			return new Temperature<T>(value);
		}
	}
}
