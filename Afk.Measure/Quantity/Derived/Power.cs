using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Power<T> : BaseQuantity<T> {
		public Power() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Watt();
		}

		public Power(T value) : this() {
			this._value = value;
		}

		public static implicit operator Power<T>(T value) {
			return new Power<T>(value);
		}
	}
}
