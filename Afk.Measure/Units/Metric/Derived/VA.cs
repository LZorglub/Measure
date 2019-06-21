using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Le voltampère (abrégé en VA) est une unité de mesure de la puissance électrique apparente. 
    /// </summary>
    public class VA : ProductMetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="VA"/>
        /// </summary>
        public VA() : base(new Volt(), Afk.Measure.Units.System.SI.AMPERE)
        {
            this.Exponent = 1;
            _symbol = "VA";
        }

        /// <summary>
        /// Gets the inverted unit
        /// </summary>
        /// <returns></returns>
        public override Unit Inverse()
        {
            var unit = (VA)base.Inverse();
            unit._symbol = "VA" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }

        /// <summary>
        /// Returns unit raised to the specified power.
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        public override Unit Power(int pow)
        {
            var unit = (VA)base.Power(pow);
            unit._symbol = "VA" + ((unit.Exponent != 1) ? unit.Exponent.ToString() : "");
            return unit;
        }
    }
}
