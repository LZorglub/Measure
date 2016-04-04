namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the density unit (kg.m3)
    /// </summary>
	public class Density : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Density"/>
        /// </summary>
        public Density()
			: base(Afk.Measure.Units.System.SI.GRAM, new Volume()) {
		}
	}
}
