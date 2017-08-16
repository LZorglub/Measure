using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Converter
{
    /// <summary>
    /// Represents the multiplier <see cref="UnitConverter"/>
    /// </summary>
    public sealed class MultiplyConverter : UnitConverter
    {
        private double _factor;

        /// <summary>
        /// Initialize a new instance of <see cref="MultiplyConverter"/>
        /// </summary>
        /// <param name="value"><see cref="Double"/> to be multiplied.</param>
        public MultiplyConverter(double value)
        {
            if (value == 1d)
                throw new ArgumentException("IDENTITY not allowed");
            _factor = value;
        }

        /// <summary>
        /// Get the <see cref="Double"/> of current instance
        /// </summary>
        public double Factor { get { return _factor; } }

        /// <summary>
        /// Get the reverse <see cref="UnitConverter"/> of current instance
        /// </summary>
        /// <returns>Reverse <see cref="UnitConverter"/> of current instance</returns>
        public override UnitConverter Inverse()
        {
            return new MultiplyConverter(1d / _factor);
        }

        /// <summary>
        /// Concatenates two instance of <see cref="UnitConverter"/>
        /// </summary>
        /// <param name="value">The <see cref="UnitConverter"/> to concat.</param>
        /// <returns>The concatenation of <b>value</b> and current instance</returns>
        public override UnitConverter Concat(UnitConverter value)
        {
            if (value is MultiplyConverter)
            {
                return from(_factor * ((MultiplyConverter)value)._factor);
            }
            else if (value is RationalConverter)
            {
                double factor = _factor
                        * ((RationalConverter)value).Numerator
                        / ((RationalConverter)value).Divisor;
                return from(factor);
            }
            else
                return base.Concat(value);
        }

        /// <summary>
        /// Converts the value to its equivalent representation using the current <see cref="MultiplyConverter"/>
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="value">A <b>T</b> value</param>
        /// <returns>The multiplication of <b>T</b> and current instance.</returns>
        public override T Convert<T>(T value)
        {
            Measure.Operation.Number<T, double> expr = new Measure.Operation.Number<T, double>(value);
            return (expr * Factor).Value;
        }

        /// <summary>
        /// Factorizes the <b>value</b> in <see cref="UnitConverter"/>
        /// </summary>
        /// <param name="value"><see cref="Double"/></param>
        /// <returns>If <b>value</b> equals 1 return <see cref="Identity"/>; otherwise <see cref="MultiplyConverter"/></returns>
        private static UnitConverter from(double value)
        {
            if (value == 1d)
            {
                return UnitConverter.IDENTITY;
            }
            return new MultiplyConverter(value);
        }

        /// <summary>
        /// Returns <see cref="UnitConverter"/> raised to the specified power
        /// </summary>
        /// <param name="pow">A number that specifies a power.</param>
        /// <returns>The <see cref="UnitConverter"/> raised to the power <b>pow</b>.</returns>
        public override UnitConverter Power(int pow)
        {
            return new MultiplyConverter(System.Math.Pow(Factor, pow));
        }
    }
}
