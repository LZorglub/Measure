using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.CGS {
	public class CentimetrePerSecond : ProductMetricBaseUnit {

		public CentimetrePerSecond()
			: base(Measure.Units.System.CGS.CENTIMETRE, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
		}
	}
}
