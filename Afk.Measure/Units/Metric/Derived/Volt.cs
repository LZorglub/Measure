using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the volt unit (V)
    /// </summary>
	public class Volt : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Volt"/>
        /// </summary>
        public Volt()
			: base(new Watt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE.Inverse()) {
			_exponent = 1;
			_symbol = "V";
		}
	}
}

