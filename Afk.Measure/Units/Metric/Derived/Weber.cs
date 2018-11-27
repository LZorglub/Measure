namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Weber unit (Wb)
    /// </summary>
	public class Weber : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Weber"/>
        /// </summary>
        public Weber()
			: base(new Volt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND) {
            this.Exponent = 1;
			_symbol = "Wb";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Weber)base.Inverse();
            unit._symbol = "Wb" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Weber)base.Power(pow);
            unit._symbol = "Wb" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
