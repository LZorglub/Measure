using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
	public class Candela : MetricBaseUnit {

		public Candela()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "cd";
		}
	}
}
