using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the mole unit (mol)
    /// </summary>
	public class Mole : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Mole"/>
        /// </summary>
        public Mole()
			: base(new Dimension(0,0,0,0,0,1,0)) {
			_symbol = "mol";
		}

	}
}
