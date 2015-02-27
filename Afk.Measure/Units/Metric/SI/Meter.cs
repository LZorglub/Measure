using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
	public class Meter : MetricBaseUnit {

		public Meter() : base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "m";
		}

	}
}
