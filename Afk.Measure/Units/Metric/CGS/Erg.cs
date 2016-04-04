namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Erg, a unit of energy and work (equal to 10−7 joules) specified in the centimetre–gram–second system of units (CGS)
    /// </summary>
	public class Erg : ProductMetricBaseUnit {

        /// <summary>
        /// Initiliaze a new instance of <see cref="Erg"/>
        /// </summary>
		public Erg()
			: base(new Dyne(), Measure.Units.System.CGS.CENTIMETRE) {
			_symbol = "erg";
			_exponent = 1;
		}
	}
}
