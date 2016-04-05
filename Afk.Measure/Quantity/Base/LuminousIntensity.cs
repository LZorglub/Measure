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

        /// <summary>
        /// Initialize a new instance of <see cref="LuminousIntensity"/>
        /// </summary>
		public LuminousIntensity() {
			this._unit = Units.System.SI.CANDELA;
		}

        /// <summary>
        /// Initialize a new instance of <see cref="LuminousIntensity"/>
        /// </summary>
        /// <param name="value"></param>
		public LuminousIntensity(T value) : this() {
			this._value = value;
		}

        /// <summary>
        /// Implicit conversion from T to <see cref="LuminousIntensity<T>"/>
        /// </summary>
        /// <param name="value"></param>
		public static implicit operator LuminousIntensity<T>(T value) {
			return new LuminousIntensity<T>(value);
		}

        #region Implicit conversion
        /// <summary>
        /// Implicit conversion from <see cref="LuminousIntensity<T>"/> to <see cref="LuminousIntensity<double>"/>
        /// </summary>
        /// <param name="value"><see cref="LuminousIntensity<T>"/> to convert</param>
        /// <returns><see cref="LuminousIntensity<double>"/></returns>
        public static implicit operator LuminousIntensity<double>(LuminousIntensity<T> value)
        {
            LuminousIntensity<double> qty = new LuminousIntensity<double>();
            qty._value = Convert.ToDouble(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="LuminousIntensity<T>"/> to <see cref="LuminousIntensity<decimal>"/>
        /// </summary>
        /// <param name="value"><see cref="LuminousIntensity<T>"/> to convert</param>
        /// <returns><see cref="LuminousIntensity<decimal>"/></returns>
        public static implicit operator LuminousIntensity<decimal>(LuminousIntensity<T> value)
        {
            LuminousIntensity<decimal> qty = new LuminousIntensity<decimal>();
            qty._value = Convert.ToDecimal(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="LuminousIntensity<T>"/> to <see cref="LuminousIntensity<long>"/>
        /// </summary>
        /// <param name="value"><see cref="LuminousIntensity<T>"/> to convert</param>
        /// <returns><see cref="LuminousIntensity<long>"/></returns>
        public static implicit operator LuminousIntensity<long>(LuminousIntensity<T> value)
        {
            LuminousIntensity<long> qty = new LuminousIntensity<long>();
            qty._value = Convert.ToInt64(value.Value);
            qty._unit = value.Unit;
            return qty;
        }

        /// <summary>
        /// Implicit conversion from <see cref="LuminousIntensity<T>"/> to <see cref="LuminousIntensity<float>"/>
        /// </summary>
        /// <param name="value"><see cref="LuminousIntensity<T>"/> to convert</param>
        /// <returns><see cref="LuminousIntensity<float>"/></returns>
        public static implicit operator LuminousIntensity<float>(LuminousIntensity<T> value)
        {
            LuminousIntensity<float> qty = new LuminousIntensity<float>();
            qty._value = Convert.ToSingle(value.Value);
            qty._unit = value.Unit;
            return qty;
        }
        #endregion

    }
}
