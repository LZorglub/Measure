using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Dyne : ProductMetricBaseUnit {

		public Dyne()
			: base(Afk.Measure.Units.System.CGS.GRAM, 
			(MetricBaseUnit)new ProductMetricBaseUnit(new CentimetrePerSecond(),(MetricBaseUnit)Measure.Units.System.SI.SECOND.Inverse())) {
			_symbol = "dyn";
			_exponent = 1;
		}
	}
}
