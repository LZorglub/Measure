﻿namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the acceleration unit (m/s2)
    /// </summary>
	public class Acceleration : ProductMetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Acceleration"/>
        /// </summary>
        public Acceleration()
			: base(new Velocity(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
		}
	}
}

