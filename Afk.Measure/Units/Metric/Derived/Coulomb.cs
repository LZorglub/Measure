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

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Coulomb)base.Inverse();
            unit._symbol = "C" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Coulomb)base.Power(pow);
            unit._symbol = "C" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
