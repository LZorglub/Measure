using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of amount of mass
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the gram (kg).</remarks>
	public class Mass<T> : BaseQuantity<T> {

		public Mass() {
			this._unit = Units.System.SI.GRAM;
		}

		public Mass(T value) : this() {
			this._value = value;
		}

		public static implicit operator Mass<T>(T value) {
			return new Mass<T>(value);
		}
	}
}
