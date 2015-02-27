using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Celsius : MetricBaseUnit {
		public Celsius()
			: base(new Dimension(0, 0, 1, 0, 0, 0, 0)) {
			_symbol = "°C";
			_baseConverter = new Afk.Measure.Converter.AddConverter(273.15);
		}

	}
}
