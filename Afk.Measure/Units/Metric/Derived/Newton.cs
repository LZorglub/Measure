namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Newton unit (N)
    /// </summary>
	public class Newton : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Newton"/>
        /// </summary>
        public Newton()
			: base(new Acceleration(), Afk.Measure.Units.System.SI.GRAM) {
            this.Exponent = 1;
			_symbol = "N";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Newton)base.Inverse();
            unit._symbol = "N" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Newton)base.Power(pow);
            unit._symbol = "N" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

