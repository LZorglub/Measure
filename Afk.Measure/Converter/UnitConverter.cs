using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents a converter of value
	/// </summary>
	public abstract class UnitConverter {

		/// <summary>
		/// Get the identity converter. 
		/// </summary>
		/// <remarks><b>value</b> * IDENTITY = <b>value</b></remarks>
		public static UnitConverter IDENTITY;

		/// <summary>
		/// Get the null converter
		/// </summary>
		/// <remarks>A null converter raise an exception when attempt to convert <b>value</b></remarks>
		public static UnitConverter NULL;

		/// <summary>
		/// Initialize a new instance of <see cref="UnitConverter"/>
		/// </summary>
		static UnitConverter() {
			IDENTITY = new Identity();
			NULL = new NullConverter();
		}

		/// <summary>
		/// Initialize a new instance of <see cref="UnitConverter"/>
		/// </summary>
		protected UnitConverter() {
		}

		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns>Reverse <see cref="UnitConverter"/> of current instance</returns>
		/// </remarks>
		public abstract UnitConverter Inverse();

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>The <see cref="UnitConverter"/> raised to the power <b>pow</b>.</returns>
		public abstract UnitConverter Power(int pow);

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object
		/// </summary>
		/// <param name="value">The object to compare to this instance</param>
		/// <returns>true if <b>value</b> is an instance of <see cref="UnitConverter"/> and equals the value of this instance; otherwise, false.</returns>
		public override bool Equals(object value) {
			if (!(value is UnitConverter)) return false;
			return this.Concat(((UnitConverter)value).Inverse()) == IDENTITY;
		}

		/// <summary>
		/// Returns the hash code for this instance
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode() {
			return base.GetHashCode();
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns>The concatenation of <b>value</b> and current instance</returns>
		public virtual UnitConverter Concat(UnitConverter value) {
			if (value == IDENTITY)
				return this;
			else if (value == NULL)
				return NULL;

			return new CompositeConverter(value, this);
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="UnitConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>The <b>T</b> representation of value after using current instance.</returns>
		public abstract T Convert<T>(T value);

		/// <summary>
		/// Gets the linearity of <see cref="UnitConverter"/>
		/// </summary>
		/// <remarks>
		/// A converter is linear if
		/// convert(x+y) = convert(x) + convert(y) and
		/// convert(x*y) = x * convert(y)
		/// </remarks>
		public virtual bool IsLinear {
			get { return true; }
		}
	}
}
