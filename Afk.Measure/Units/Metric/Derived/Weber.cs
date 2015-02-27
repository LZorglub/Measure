using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Weber : ProductMetricBaseUnit {

		public Weber()
			: base(new Volt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND) {
			_exponent = 1;
			_symbol = "Wb";
		}
	}
}
