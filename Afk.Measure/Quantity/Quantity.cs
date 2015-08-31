using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;

namespace Afk.Measure.Quantity {
	/// <summary>
	/// Represents a quantity
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Quantity<T> : BaseQuantity<T> {

        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        public Quantity() : base() {
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Quantity(T value, Unit unit) : this() {
			this._value = value;
			this._unit = unit;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Quantity"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Quantity(T value, string unit) : this(value, Unit.Parse(unit)) {
		}
    }
}
