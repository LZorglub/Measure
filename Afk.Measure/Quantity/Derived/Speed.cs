using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Speed <T> : Quantity<T> {
		public Speed() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Velocity();
		}

		public Speed(T value) : this() {
			this._value = value;
		}

		public static implicit operator Speed<T>(T value) {
			return new Speed<T>(value);
		}
	}
}
