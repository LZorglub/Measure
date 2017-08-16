using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents the identity converter.
	/// </summary>
	/// <remarks>The identity converter preserves the <b>value</b> when convert is applied.</remarks>
	internal sealed class Identity : UnitConverter {
		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns><see cref="Identity"/> itself.</returns>
		public override UnitConverter Inverse() {
			return this;
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns><b>value</b> itself.</returns>
		public override UnitConverter Concat(UnitConverter value) {
			return value;
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="UnitConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>The same instance of <b>value</b></returns>
		public override T Convert<T>(T value) {
			return value;
		}

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>The <see cref="Identity"/> himself.</returns>
		public override UnitConverter Power(int pow) {
			return this;
		}
	}
}
