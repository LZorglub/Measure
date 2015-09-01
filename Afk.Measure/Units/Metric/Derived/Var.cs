using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	/// <summary>
	/// Represents the Reactive power measured in "Volt-amperes reactive" (var)
	/// </summary>
	public class Var : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Var"/>
        /// </summary>
        public Var()
			: base(new Volt(), Afk.Measure.Units.System.SI.AMPERE) {
			_exponent = 1;
			_symbol = "var";
		}
	}
}

