using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Barye : ProductMetricBaseUnit {

		public Barye()
			: base(new Poise(), (MetricBaseUnit)Measure.Units.System.SI.SECOND.Inverse()) {
			_symbol = "Ba";
			_exponent = 1;
		}
	}
}
