using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Gram : MetricBaseUnit {
		public Gram()
			: base(new Dimension(0, 0, 0, 1, 0, 0, 0)) {
			_symbol = "g";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(10).Power(-3);
		}
	}
}
