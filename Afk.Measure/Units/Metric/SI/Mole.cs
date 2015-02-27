using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
	public class Mole : MetricBaseUnit {
		public Mole()
			: base(new Dimension(0,0,0,0,0,1,0)) {
			_symbol = "mol";
		}

	}
}
