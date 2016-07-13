namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Bayre, a centimetre-gram-second (CGS) unit of pressure
    /// </summary>
	public class Barye : ProductMetricBaseUnit {

        /// <summary>
        /// Initialize a new instance of <see cref="Barye"/>
        /// </summary>
		public Barye()
			: base(new Poise(), (MetricBaseUnit)Measure.Units.System.SI.SECOND.Inverse()) {
			_symbol = "Ba";
            this.Exponent = 1;
        }
	}
}
