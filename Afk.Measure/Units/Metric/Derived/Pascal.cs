using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the Pascal unit (Pa)
    /// </summary>
	public class Pascal : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Pascal"/>
        /// </summary>
        public Pascal()
			: base(new Newton(), (MetricBaseUnit)new Area().Inverse()) {
			_exponent = 1;
			_symbol = "Pa";
		}
	}
}

