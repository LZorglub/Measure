using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Coulomb : ProductMetricBaseUnit {

		public Coulomb()
			: base((Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND, (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE) {
			_exponent = 1;
			_symbol = "C";
		}
	}
}
