namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the volume unit (m3)
    /// </summary>
	public class Volume : ProductMetricBaseUnit{
        /// <summary>
        /// Initialize a new instance of <see cref="Volume"/>
        /// </summary>
        public Volume()
			: base(new Area(), Afk.Measure.Units.System.SI.METER) {
		}
	}

	/// <summary>
	/// Represents the liter unit (l)
	/// </summary>
	/// <remarks>
	/// This class can not inherited from <see cref="Volume"/>.
	/// A volume is equal to dm * dm * dm. If Liter inherited from Volume, the extended units will be the meter
	/// which cause a unit conversion issue when they will be used..
	/// Case : l * (m.°C) = m4.°C we prefer l * (m.°C) = l.m.°C
	/// </remarks>
	public class Litre : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Litre"/>
        /// </summary>
        public Litre()
			: base(new Dimension(3, 0, 0, 0, 0, 0, 0)) {
            this.Exponent = 1;
			_symbol = "l";
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000);
		}
	}
}
