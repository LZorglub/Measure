using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents the null converter.
	/// </summary>
	/// <remarks>The null converter is unable to perform conversion.</remarks>
	internal sealed class NullConverter : UnitConverter {

		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns><see cref="NullConverter"/> himself.</returns>
		public override UnitConverter Inverse() {
			return this;
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns><see cref="NullConverter"/> itself.</returns>
		public override UnitConverter Concat(UnitConverter value) {
			return this;
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="UnitConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>This method raise always an exception</returns>
		public override T Convert<T>(T value) {
			throw new Exception("Unable to convert unit");
		}

		/// <summary>
		/// Gets the linearity of <see cref="UnitConverter"/>
		/// </summary>
		/// <remarks>The <see cref="NullConverter"/> is not linear</remarks>
		public override bool IsLinear {
			get { return false; }
		}

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>The <see cref="NullConverter"/> himself.</returns>
		public override UnitConverter Power(int pow) {
			return this;
		}
	}
}
