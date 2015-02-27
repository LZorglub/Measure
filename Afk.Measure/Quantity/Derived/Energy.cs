using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Energy<T> : Quantity<T> {
		public Energy() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Joule();
		}

		public Energy(T value) : this() {
			this._value = value;
		}

		public static implicit operator Energy <T>(T value) {
			return new Energy<T>(value);
		}
	}
}
