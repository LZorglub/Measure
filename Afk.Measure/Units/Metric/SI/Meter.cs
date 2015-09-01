using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the meter unit (m)
    /// </summary>
	public class Meter : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Meter"/>
        /// </summary>
        public Meter() : base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "m";
		}

	}
}
