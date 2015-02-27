using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Velocity : ProductMetricBaseUnit {

		public Velocity()
			: base(Afk.Measure.Units.System.SI.METER, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
		}
	}
}
