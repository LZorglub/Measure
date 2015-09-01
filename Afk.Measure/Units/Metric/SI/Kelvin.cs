using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the Kelvin unit (K)
    /// </summary>
	public class Kelvin : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Kelvin"/>
        /// </summary>
        public Kelvin()
			: base(new Dimension(0, 0, 1, 0, 0, 0, 0)) {
			_symbol = "K";
		}
	}
}
