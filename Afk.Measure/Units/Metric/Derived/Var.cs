namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the Reactive power measured in "Volt-amperes reactive" (var)
    /// </summary>
    public class Var : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Var"/>
        /// </summary>
        public Var()
			: base(new Volt(), Afk.Measure.Units.System.SI.AMPERE) {
            this.Exponent = 1;
			_symbol = "var";
		}

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (Var)base.Inverse();
            unit._symbol = "var" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (Var)base.Power(pow);
            unit._symbol = "var" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}

