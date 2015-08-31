using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Force<T> : BaseQuantity<T> {
		public Force() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Newton();
		}

		public Force(T value) : this() {
			this._value = value;
		}

		public static implicit operator Force<T>(T value) {
			return new Force<T>(value);
		}
	}
}