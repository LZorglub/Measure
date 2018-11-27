namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Joule unit (J)
    /// </summary>
    /// <remarks>
    /// 1 J = 1 kg.m2.s-2
    /// </remarks>
	public class Joule : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Joule"/>
        /// </summary>
        public Joule()
			: base(new Newton(), Afk.Measure.Units.System.SI.METER) {
            this.Exponent = 1;
			_symbol = "J";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Joule)base.Inverse();
            unit._symbol = "J" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Joule)base.Power(pow);
            unit._symbol = "J" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

