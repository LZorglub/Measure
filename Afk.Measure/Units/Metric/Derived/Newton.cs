using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the Newton unit (N)
    /// </summary>
	public class Newton : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Newton"/>
        /// </summary>
        public Newton()
			: base(new Acceleration(), Afk.Measure.Units.System.SI.GRAM) {
			_exponent = 1;
			_symbol = "N";
		}
	}
}

