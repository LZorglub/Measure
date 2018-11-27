using System;

namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Ohm unit ()
    /// </summary>
	public class Ohm : ProductMetricBaseUnit
    {

        private readonly string omegaSymbol = new String(new char[] { '\u03A9', '\u03A9', '\u03A9' }, 2, 1);

        /// <summary>
        /// Initialize a new instance of <see cref="Ohm"/>
        /// </summary>
		public Ohm()
            : base(new Volt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE.Inverse())
        {
            this.Exponent = 1;
            // Omega symbol
            _symbol = omegaSymbol;
        }

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Ohm)base.Inverse();
            unit._symbol = omegaSymbol + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Ohm)base.Power(pow);
            unit._symbol = omegaSymbol + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
