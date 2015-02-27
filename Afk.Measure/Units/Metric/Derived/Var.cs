using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	/// <summary>
	/// Reactive power is measured in "Volt-amperes reactive"
	/// </summary>
	public class Var : ProductMetricBaseUnit {

		public Var()
			: base(new Volt(), Afk.Measure.Units.System.SI.AMPERE) {
			_exponent = 1;
			_symbol = "var";
		}
	}
}

