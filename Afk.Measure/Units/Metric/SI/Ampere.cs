﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
    /// <summary>
    /// Represents the Ampere unit (A)
    /// </summary>
	public class Ampere : MetricBaseUnit {

        /// <summary>
        /// Initialize a new instance of <see cref="Ampere"/>
        /// </summary>
		public Ampere()
			: base(new Dimension(0, 0, 0, 0, 1, 0, 0)) {
			_symbol = "A";
		}

	}
}
