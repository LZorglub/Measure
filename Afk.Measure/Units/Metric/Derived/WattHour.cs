namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Le kilowatt-heure est une unité de mesure d'énergie correspondant à l'énergie consommée par un appareil de 1 000 watts (1 kW) de puissance pendant une durée d'une heure.
    /// </summary>
    /// <remarks>On n'hérite pas de <see cref="Joule"/> pour que le contexte d'unité se rappelle de <see cref="Watt"/>
    /// 1 watt-heure (W·h) = 3 600 J 
    /// 1 W·h = J·s-1·h = N·m·s-1·h = kg·m2·s-3·h = 3600 kg·m2·s-2
    /// </remarks>
    public class WattHour : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="WattHour"/>
        /// </summary>
        public WattHour() :  base (new Watt(), new Hour()) {
			_exponent = 1;
			_symbol = "Wh";
		}
	}
}
