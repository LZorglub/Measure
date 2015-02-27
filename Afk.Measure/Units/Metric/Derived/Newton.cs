using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Newton : ProductMetricBaseUnit {

		public Newton()
			: base(new Acceleration(), Afk.Measure.Units.System.SI.GRAM) {
			_exponent = 1;
			_symbol = "N";
		}
	}
}

