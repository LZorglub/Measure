using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the area unit (m2)
    /// </summary>
	public class Area : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Area"/>
        /// </summary>
        public Area()
			: base(Afk.Measure.Units.System.SI.METER, Afk.Measure.Units.System.SI.METER) {
		}

	}
}
