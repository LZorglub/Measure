using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;

namespace Afk.Measure.Quantity {
	/// <summary>
	/// Represents a derived quantity
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DerivedQuantity<T> : Quantity<T> {

		/// <summary>
		/// Initialize a new instance of <see cref="DerivedQuantity"/>
		/// </summary>
		public DerivedQuantity() : base() {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="DerivedQuantity"/>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="unit"></param>
		public DerivedQuantity(T value, Unit unit) : this() {
			this._value = value;
			this._unit = unit;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="DerivedQuantity"/>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="unit"></param>
		public DerivedQuantity(T value, string unit) : this(value, Unit.Parse(unit)) {
		}

	}
}
