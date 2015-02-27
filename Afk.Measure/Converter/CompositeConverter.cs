using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents a composite converter provide by concatenation of primitive converter.
	/// </summary>
	internal sealed class CompositeConverter : UnitConverter {
		private UnitConverter _first;
		private UnitConverter _second;

		/// <summary>
		/// Initialize a new instance of <see cref="CompositeConverter"/>
		/// </summary>
		/// <param name="first">First <see cref="UnitConverter"/> to applied.</param>
		/// <param name="second">Second <see cref="UnitConverter"/> to applied.</param>
		internal CompositeConverter(UnitConverter first, UnitConverter second) {
			_first = first; _second = second;
		}

		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns>Reverse <see cref="UnitConverter"/> of current instance</returns>
		/// </remarks>
		public override UnitConverter Inverse() {
			return new CompositeConverter(_second.Inverse(), _first.Inverse());
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="UnitConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>The <b>T</b> representation of value after using current instance.</returns>
		public override T Convert<T>(T value) {
			return _second.Convert<T>(_first.Convert<T>(value));
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns>The concatenation of <b>value</b> and current instance</returns>
		public override UnitConverter Concat(UnitConverter value) {
			if (value is CompositeConverter) {
				if (_first.Concat(((CompositeConverter)value)._second) == UnitConverter.IDENTITY)
					return _second.Concat(((CompositeConverter)value)._first);
			}

			return base.Concat(value);
		}

		/// <summary>
		/// Gets the linearity of <see cref="UnitConverter"/>
		/// </summary>
		/// <remarks>
		/// A <see cref="CompositeConverter"/> is linear if
		/// First <see cref="UnitConverter"/> is linear and second <see cref="UnitConverter"/> is linear.
		/// </remarks>
		public override bool IsLinear {
			get {
				return _first.IsLinear && _second.IsLinear;
			}
		}

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>The <see cref="UnitConverter"/> raised to the power <b>pow</b>.</returns>
		/// <remarks>The new <see cref="CompositeConverter"/> can have no sense if current instance is not linear</remarks>
		public override UnitConverter Power(int pow) {
			return new CompositeConverter(_first.Power(pow), _second.Power(pow));
		}
	}
}
