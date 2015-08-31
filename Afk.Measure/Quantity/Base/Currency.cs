using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Quantity.Base {
	/// <summary>
	/// Represents a quantity of currency
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>The base unit of this quantity is the euro.</remarks>
	public class Currency<T> : BaseQuantity<T> {
		public Currency() {
			this._unit = new Units.Currency.Euro();
		}

		public Currency(T value)
			: this() {
			this._value = value;
		}

		public static implicit operator Currency<T>(T value) {
			return new Currency<T>(value);
		}
	}
}
