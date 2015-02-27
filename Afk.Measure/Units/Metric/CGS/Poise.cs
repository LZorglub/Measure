using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Poise : ProductMetricBaseUnit {

		public Poise()
			: base(Measure.Units.System.CGS.GRAM,
			(MetricBaseUnit)new ProductMetricBaseUnit(Measure.Units.System.CGS.CENTIMETRE, Measure.Units.System.SI.SECOND).Inverse()) {
			_symbol = "P";
			_exponent = 1;
		}
	}
}
