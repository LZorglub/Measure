using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of luminosity
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the candela.</remarks>
	public class LuminousIntensity<T> : Quantity<T> {

		public LuminousIntensity() {
			this._unit = Units.System.SI.CANDELA;
		}

		public LuminousIntensity(T value) : this() {
			this._value = value;
		}

		public static implicit operator LuminousIntensity<T>(T value) {
			return new LuminousIntensity<T>(value);
		}
	}
}
