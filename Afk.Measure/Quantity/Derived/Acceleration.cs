using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Derived {
	public class Acceleration<T> : Quantity<T> {
		public Acceleration() {
			this._unit = new Afk.Measure.Units.Metric.Derived.Velocity() / new Units.Metric.SI.Second();
		}

		public Acceleration(T value) : this() {
			this._value = value;
		}

		public static implicit operator Acceleration<T>(T value) {
			return new Acceleration<T>(value);
		}
	}
}
