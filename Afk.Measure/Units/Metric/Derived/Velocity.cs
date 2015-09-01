using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the velocity unit
    /// </summary>
	public class Velocity : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Velocity"/>
        /// </summary>
        public Velocity()
			: base(Afk.Measure.Units.System.SI.METER, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
		}
	}
}
