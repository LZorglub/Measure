using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.System;
using Afk.Measure.Units.Metric.SI;

namespace Afk.Measure.Units.Metric.Derived {
	public class Tesla : ProductMetricBaseUnit {
		public Tesla()
			: base(new ProductMetricBaseUnit(new Volt(), Afk.Measure.Units.System.SI.SECOND), (MetricBaseUnit)new Area().Inverse()) {
			_exponent = 1;
			_symbol = "T";
		}
	}
}
