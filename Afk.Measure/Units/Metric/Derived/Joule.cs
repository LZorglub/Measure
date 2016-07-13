namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Joule unit (J)
    /// </summary>
	public class Joule : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Joule"/>
        /// </summary>
        public Joule()
			: base(new Newton(), Afk.Measure.Units.System.SI.METER) {
            this.Exponent = 1;
			_symbol = "J";
		}
	}
}

