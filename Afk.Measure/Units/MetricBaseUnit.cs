using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units{
	/// <summary>
	/// Represents a unit of the metric system.
	/// </summary>
	/// <remarks><see cref="MetricBaseUnit"/> are the only <see cref="Unit"/> which can have a prefix.</remarks>
	public abstract class MetricBaseUnit : BaseUnit {

		/// <summary>
		/// Initialize a new instance of <see cref="MetricBaseUnit"/>
		/// </summary>
		public MetricBaseUnit()	: base() {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="MetricBaseUnit"/>
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of unit</param>
		public MetricBaseUnit(Dimension dimension)
			: base(dimension) {
		}
	}
}
