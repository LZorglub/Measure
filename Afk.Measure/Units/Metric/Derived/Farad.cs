namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Farad unit (F)
    /// </summary>
	public class Farad : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Farad"/>
        /// </summary>
        public Farad()
			: base(new Coulomb(), (MetricBaseUnit)new Volt().Inverse()) {
            this.Exponent = 1;
			_symbol = "F";
		}
	}
}
