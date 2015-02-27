using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents exception raised by unit
	/// </summary>
	public class UnitException : Exception {

		/// <summary>
		/// Initialize a new instance of <see cref="UnitException"/>
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public UnitException(string message)
			: base(message) {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="UnitException"/>
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public UnitException(string message, Exception innerException)
			: base(message, innerException) {
		}
	}
}
