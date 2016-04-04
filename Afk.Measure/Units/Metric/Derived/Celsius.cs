namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the celsius unit (°C)
    /// </summary>
	public class Celsius : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Celsius"/>
        /// </summary>
		public Celsius()
			: base(new Dimension(0, 0, 1, 0, 0, 0, 0)) {
			_symbol = "°C";
			_baseConverter = new Afk.Measure.Converter.AddConverter(273.15);
		}

	}
}
