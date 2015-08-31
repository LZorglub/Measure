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

        /// <summary>
        /// Conversion implicit d'une valeur T en <see cref="Quantity"/> d'unité <see cref="BaseUnit.UNITONE"/>
        /// </summary>
        /// <param name="value">Valeur de la quantité</param>
        /// <returns><see cref="Quantity"/> représentant la valeur spécifiée.</returns>
        public static implicit operator Quantity<T>(T value)
        {
            Quantity<T> qty = new Quantity<T>();
            qty._value = value;
            qty._unit = BaseUnit.UNITONE;
            return qty;
        }

        #region Explicit conversion. Conversions are explicit to avoid conversion conflict when convert inherited class
        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<double>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<double>"/></returns>
        public static explicit operator Quantity<double>(Quantity<T> value)
        {
            Quantity<double> qty = new Quantity<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<decimal>"/></returns>
        public static explicit operator Quantity<decimal>(Quantity<T> value)
        {
            Quantity<decimal> qty = new Quantity<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<long>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<long>"/></returns>
		public static explicit operator Quantity<long>(Quantity<T> value)
        {
            Quantity<long> qty = new Quantity<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Explicit conversion from <see cref="Quantity<T>"/> to <see cref="Quantity<float>"/>
        /// </summary>
        /// <param name="value"><see cref="Quantity<T>"/> to convert</param>
        /// <returns><see cref="Quantity<float>"/></returns>
		public static explicit operator Quantity<float>(Quantity<T> value)
        {
            Quantity<float> qty = new Quantity<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion
    }
}
