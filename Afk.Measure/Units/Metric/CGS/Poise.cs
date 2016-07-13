namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Poise, a unit of dynamic viscosity in the centimetre–gram–second system of units (CGS)
    /// </summary>
    public class Poise : ProductMetricBaseUnit {

        /// <summary>
        /// Initliaze a new instance of <see cref="Poise"/>
        /// </summary>
		public Poise()
			: base(Measure.Units.System.CGS.GRAM,
			(MetricBaseUnit)new ProductMetricBaseUnit(Measure.Units.System.CGS.CENTIMETRE, Measure.Units.System.SI.SECOND).Inverse()) {
			_symbol = "P";
            this.Exponent = 1;
		}
	}
}
