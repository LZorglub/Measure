using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the second unit (s)
    /// </summary>
	public class Second : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Second"/>
        /// </summary>
		public Second()
			: base(new Dimension(0, 1, 0, 0, 0, 0, 0)) {
			_symbol = "s";
		}
	}
}
