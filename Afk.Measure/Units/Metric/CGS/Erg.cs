using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Erg : ProductMetricBaseUnit {

		public Erg()
			: base(new Dyne(), Measure.Units.System.CGS.CENTIMETRE) {
			_symbol = "erg";
			_exponent = 1;
		}
	}
}
