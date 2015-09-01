using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
    /// <summary>
    /// Represents the Ohm unit ()
    /// </summary>
	public class Ohm : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Ohm"/>
        /// </summary>
		public Ohm()
			: base(new Volt(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.AMPERE.Inverse()) {
			_exponent = 1;
			// Omega symbol
			_symbol = new String(new char[] { '\u03A9', '\u03A9', '\u03A9' }, 2, 1); 
		}
	}
}
