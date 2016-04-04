namespace Afk.Measure.Units.Metric.CGS
{
    /// <summary>
    /// Represents the Gram, a unit of mass specified in the centimetre–gram–second system of units (CGS)
    /// </summary>
	public class Gram : MetricBaseUnit {
        /// <summary>
        /// Initiliaze a new instance of <see cref="Gram"/>
        /// </summary>
		public Gram()
			: base(new Dimension(0, 0, 0, 1, 0, 0, 0)) {
			_symbol = "g";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(10).Power(-3);
		}
	}
}
