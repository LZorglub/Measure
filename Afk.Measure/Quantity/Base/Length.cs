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
	public class Length<T> : BaseQuantity<T> {

		public Length() {
			this._unit = Units.System.SI.METER;
		}

		public Length(T value) : this() {
			this._value = value;
		}

		public static implicit operator Length<T>(T value) {
			return new Length<T>(value);
		}
	}
}
