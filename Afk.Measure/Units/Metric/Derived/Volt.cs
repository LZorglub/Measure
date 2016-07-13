namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the volt unit (V)
    /// </summary>
	public class Volt : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Volt"/>
        /// </summary>
        public Volt()
			: base(new Watt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE.Inverse()) {
            this.Exponent = 1;
			_symbol = "V";
		}
	}
}

