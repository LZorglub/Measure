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

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Farad)base.Inverse();
            unit._symbol = "F" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Farad)base.Power(pow);
            unit._symbol = "F" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
