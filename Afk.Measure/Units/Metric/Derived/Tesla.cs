namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Tesla unit (T)
    /// </summary>
	public class Tesla : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Tesla"/>
        /// </summary>
        public Tesla()
			: base(new ProductMetricBaseUnit(new Volt(), Afk.Measure.Units.System.SI.SECOND), (MetricBaseUnit)new Area().Inverse()) {
            this.Exponent = 1;
			_symbol = "T";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Tesla)base.Inverse();
            unit._symbol = "T" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Tesla)base.Power(pow);
            unit._symbol = "T" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
