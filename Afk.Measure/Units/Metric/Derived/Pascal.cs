namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Pascal unit (Pa)
    /// </summary>
	public class Pascal : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Pascal"/>
        /// </summary>
        public Pascal()
			: base(new Newton(), (MetricBaseUnit)new Area().Inverse()) {
            this.Exponent = 1;
			_symbol = "Pa";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Pascal)base.Inverse();
            unit._symbol = "Pa" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Pascal)base.Power(pow);
            unit._symbol = "Pa" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

