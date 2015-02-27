using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter {
	/// <summary>
	/// Represents the rational <see cref="UnitConverter"/>
	/// </summary>
	public sealed class RationalConverter : UnitConverter {
		private long _numerator;
		private long _divisor;

		/// <summary>
		/// Initialize a new instance of <see cref="RationalConverter"/>
		/// </summary>
		/// <param name="numerator">Numerator of rational operation</param>
		/// <param name="divisor">Divisor of rational operation</param>
		public RationalConverter(long numerator, long divisor) {
			if (divisor == 0)
				throw new ArgumentException("Zero divisor not allowed");
			if (divisor == numerator)
				throw new ArgumentException("IDENTITY not allowed");
			_numerator = numerator; _divisor = divisor;
		}

		/// <summary>
		/// Gets the numerator of current instance
		/// </summary>
		public long Numerator {
			get { return _numerator; }
		}

		/// <summary>
		/// Gets the divisor of current instance
		/// </summary>
		public long Divisor {
			get { return _divisor; }
		}

		/// <summary>
		/// Get the reverse <see cref="UnitConverter"/> of current instance
		/// </summary>
		/// <returns>Reverse <see cref="UnitConverter"/> of current instance</returns>
		/// </remarks>
		public override UnitConverter Inverse() {
			return (_divisor < 0) ? new RationalConverter(-_divisor, -_numerator) : new RationalConverter(_divisor, _numerator);
		}

		/// <summary>
		/// Concatenates two instance of <see cref="UnitConverter"/>
		/// </summary>
		/// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
		/// <returns>The concatenation of <b>value</b> and current instance</returns>
		public override UnitConverter Concat(UnitConverter value) {
			if (value is RationalConverter) {
				RationalConverter _conv = (RationalConverter)value;
				long _num = this._numerator * _conv._numerator;
				long _div = this._divisor * _conv._divisor;
				long gcd = this.gcd(_num, _div);

				if ((_num / gcd == 1) && (_div / gcd == 1)) {
					return UnitConverter.IDENTITY;
				}
				return new RationalConverter(_num, _div);
			}
			else if (value is MultiplyConverter) {
				return value.Concat(this);
			}
			else
				return base.Concat(value);
		}

		/// <summary>
		/// Get the gcd of two numbers
		/// </summary>
		/// <param name="m"></param>
		/// <param name="n"></param>
		/// <returns>Gcd of <b>m</b> and <b>n</b></returns>
		private long gcd(long m, long n) {
			if (n == 0L) {
				return m;
			}
			else {
				return gcd(n, m % n);
			}
		}

		/// <summary>
		/// Converts the value to its equivalent representation using the current <see cref="MultiplyConverter"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="value">A <b>T</b> value</param>
		/// <returns>The division of <b>T</b> and current instance.</returns>
		public override T Convert<T>(T value) {
			Measure.Operation.Number<T, double> expr = new Measure.Operation.Number<T, double>(value);
			return (expr * _numerator / _divisor).Value;
		}

		/// <summary>
		/// Returns <see cref="UnitConverter"/> raised to the specified power
		/// </summary>
		/// <param name="pow">A number that specifies a power.</param>
		/// <returns>The <see cref="UnitConverter"/> raised to the power <b>pow</b>.</returns>
		public override UnitConverter Power(int pow) {
			return new RationalConverter((long)System.Math.Pow(Numerator, pow), (long)System.Math.Pow(Divisor, pow));
		}
	}
}
