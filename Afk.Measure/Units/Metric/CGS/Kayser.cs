using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Kayser : ProductMetricBaseUnit {

		public Kayser()
			: base((MetricBaseUnit)Measure.Units.System.CGS.CENTIMETRE.Inverse()) {
		}
	}
}
