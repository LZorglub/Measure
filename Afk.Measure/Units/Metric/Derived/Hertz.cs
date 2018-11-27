namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Hertz unit (Hz)
    /// </summary>
	public class Hertz : ProductMetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Hertz"/>
        /// </summary>
		public Hertz()
			: base((Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
			_symbol = "Hz";
            this.Exponent = 1;
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Hertz)base.Inverse();
            unit._symbol = "Hz" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Hertz)base.Power(pow);
            unit._symbol = "Hz" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
