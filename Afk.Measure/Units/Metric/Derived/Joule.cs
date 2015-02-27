using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Joule : ProductMetricBaseUnit {

		public Joule()
			: base(new Newton(), Afk.Measure.Units.System.SI.METER) {
			_exponent = 1;
			_symbol = "J";
		}
	}
}

