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
			_exponent = 1;
			_symbol = "Wb";
		}
	}
}
