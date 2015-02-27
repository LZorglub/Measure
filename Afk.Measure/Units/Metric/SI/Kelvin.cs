﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
	public class Kelvin : MetricBaseUnit {
		public Kelvin()
			: base(new Dimension(0, 0, 1, 0, 0, 0, 0)) {
			_symbol = "K";
		}
	}
}
