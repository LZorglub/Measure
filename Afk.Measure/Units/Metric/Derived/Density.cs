using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Density : ProductMetricBaseUnit {
		public Density()
			: base(Afk.Measure.Units.System.SI.GRAM, new Volume()) {
		}
	}
}
