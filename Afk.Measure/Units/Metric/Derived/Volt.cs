namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the volt unit (V)
    /// </summary>
	public class Volt : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Volt"/>
        /// </summary>
        public Volt()
			: base(new Watt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE.Inverse()) {
            this.Exponent = 1;
			_symbol = "V";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Volt)base.Inverse();
            unit._symbol = "V" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Volt)base.Power(pow);
            unit._symbol = "V" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

