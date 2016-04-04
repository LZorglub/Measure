namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Kayser, a unit of wavenumber specified in the centimetre–gram–second system of units (CGS)
    /// </summary>
    public class Kayser : ProductMetricBaseUnit {

        /// <summary>
        /// Initiliaze a new instance of <see cref="Kayser"/>
        /// </summary>
		public Kayser()
			: base((MetricBaseUnit)Measure.Units.System.CGS.CENTIMETRE.Inverse()) {
		}
	}
}
