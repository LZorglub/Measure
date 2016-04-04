namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the centimeter per second, a centimetre-gram-second (CGS) unit of velocity
    /// </summary>
    public class CentimetrePerSecond : ProductMetricBaseUnit {

        /// <summary>
        /// Initialize a new instance of <see cref="CentimetrePerSecond"/>
        /// </summary>
		public CentimetrePerSecond()
			: base(Measure.Units.System.CGS.CENTIMETRE, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
		}
	}
}
