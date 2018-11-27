namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Le watt (symbole W) est une unité dérivée du système international pour la puissance. Un watt est la puissance d'un système énergétique dans lequel une énergie de 1 joule est transférée uniformément pendant 1 seconde[1].
    /// </summary>
    /// <remarks>
    /// Un watt est égal à un joule par seconde, ou un newton mètre par seconde ou encore un kilogramme mètre carré par seconde au cube :
    /// W = J·s-1 = N·m·s-1 = kg·m2·s-3
    /// </remarks>
    public class Watt : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Watt"/>
        /// </summary>
        public Watt()
			: base(new Joule(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
            this.Exponent = 1;
			_symbol = "W";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Watt)base.Inverse();
            unit._symbol = "W" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Watt)base.Power(pow);
            unit._symbol = "W" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

