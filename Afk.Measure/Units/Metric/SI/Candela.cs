using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the Candela unit (cd)
    /// </summary>
	public class Candela : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Candela"/>
        /// </summary>
        public Candela()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "cd";
		}
	}
}
