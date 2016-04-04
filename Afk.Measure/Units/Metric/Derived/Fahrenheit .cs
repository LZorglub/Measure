namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Fahrenheit unit (°F)
    /// </summary>
	public class Fahrenheit : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Fahrenheit"/>
        /// </summary>
        public Fahrenheit()
			: base(new Dimension(0, 0, 1, 0, 0, 0, 0)) {
			_symbol = "°F";
			// K = (°F + 459.67) * 5/9
			_baseConverter = new Afk.Measure.Converter.RationalConverter(5, 9).Concat(new Afk.Measure.Converter.AddConverter(459.67));
		}
	}
}
