namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Coulomb unit (A.s)
    /// </summary>
	public class Coulomb : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Coulomb"/>
        /// </summary>
        public Coulomb()
			: base((Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE) {
            this.Exponent = 1;
			_symbol = "C";
		}
	}
}
