using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of electric current
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the ampere.</remarks>
	public class ElectricCurrent<T> : Quantity<T> {

		public ElectricCurrent() {
			this._unit = Units.System.SI.AMPERE;
		}

		public ElectricCurrent(T value) : this() {
			this._value = value;
		}

		public static implicit operator ElectricCurrent<T>(T value) {
			return new ElectricCurrent<T>(value);
		}
	}
}
