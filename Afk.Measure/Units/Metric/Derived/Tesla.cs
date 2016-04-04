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
			_exponent = 1;
			_symbol = "T";
		}
	}
}
