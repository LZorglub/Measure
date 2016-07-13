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
	}
}

