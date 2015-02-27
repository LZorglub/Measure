using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of amount of substance
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the mole.</remarks>
	public class AmountOfSubstance<T> : Quantity<T> {

		public AmountOfSubstance() {
			this._unit = Units.System.SI.MOLE;
		}

		public AmountOfSubstance(T value) : this() {
			this._value = value;
		}

		public static implicit operator AmountOfSubstance<T>(T value) {
			return new AmountOfSubstance<T>(value);
		}
	}
}
