using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the Hertz unit (Hz)
    /// </summary>
	public class Hertz : ProductMetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Hertz"/>
        /// </summary>
		public Hertz()
			: base((Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
			_symbol = "Hz";
			_exponent = 1;
		}
	}
}
