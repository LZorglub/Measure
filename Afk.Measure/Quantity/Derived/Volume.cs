using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Volume<T> : BaseQuantity<T> {
		public Volume() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Volume();
		}

		public Volume(T value) : this() {
			this._value = value;
		}

		public static implicit operator Volume<T>(T value) {
			return new Volume<T>(value);
		}
	}
}
