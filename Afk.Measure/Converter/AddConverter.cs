using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents the additional <see cref="UnitConverter"/>
	/// </summary>
	public sealed class AddConverter : UnitConverter {
		private double _offset;

		/// <summary>
		/// Initialize a new instance of <see cref="AddConverter"/>
		/// </summary>
		/// <param name="value"><see cref="Double"/> to be added.</param>
		public AddConverter(double value) {
			if (value == 0d)
				throw new ArgumentException("IDENTITY not allowed");
			_offset = value;
		}

		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns>Reverse <see cref="UnitConverter"/> of current instance</returns>
		/// </remarks>
		public override UnitConverter Inverse() {
			return new AddConverter(-_offset);
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns>The concatenation of <b>value</b> and current instance</returns>
		public override UnitConverter Concat(UnitConverter value) {
			if (value is AddConverter) {
				double offset = _offset + ((AddConverter)value)._offset;
				return (offset == 0d) ? UnitConverter.IDENTITY : new AddConverter(offset);
			}
			else {
				return base.Concat(value);
			}
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="AddConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>The sum of <b>T</b> and current instance.</returns>
		public override T Convert<T>(T value) {
			Measure.Operation.Number<T, double> expr = new Measure.Operation.Number<T, double>(value);
			return (expr + _offset).Value;
		}

		/// <summary>
		/// Gets the linearity of <see cref="AddConverter"/>
		/// </summary>
		/// <remarks>The <see cref="AddConverter"/> is not linear.</remarks>
		public override bool IsLinear {
			get { return false; }
		}

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>If <b>pow</b> is equal to 1 return current instance; otherwise, raise an exception.</returns>
		public override UnitConverter Power(int pow) {
			if (pow == 1) return this;

			throw new NotImplementedException();
		}
	}
}
