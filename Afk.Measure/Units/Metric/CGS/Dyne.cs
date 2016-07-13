namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Dyne, a unit of force specified in the centimetre–gram–second system of units (CGS)
    /// </summary>
	public class Dyne : ProductMetricBaseUnit {

        /// <summary>
        /// Initialize a new instance of <see cref="Dyne"/>
        /// </summary>
		public Dyne()
			: base(Afk.Measure.Units.System.CGS.GRAM, 
			(MetricBaseUnit)new ProductMetricBaseUnit(new CentimetrePerSecond(),(MetricBaseUnit)Measure.Units.System.SI.SECOND.Inverse())) {
			_symbol = "dyn";
            this.Exponent = 1;
		}
	}
}
