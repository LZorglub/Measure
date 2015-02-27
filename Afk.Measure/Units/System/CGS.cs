using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.System {
	/// <summary>
	/// Represents the CGS system.
	/// </summary>
	/// <remarks>The centimetre-gram-second system (abbreviated CGS or cgs) is a metric system of physical units based on centimetre as the unit of length, gram as a unit of mass, and second as a unit of time. All CGS mechanical units are unambiguously derived from these three base units, but there are several different ways of extending the CGS system to cover electromagnetism.</remarks>
	public sealed class CGS {

		public static Measure.Units.MetricBaseUnit GRAM;
		public static Measure.Units.MetricBaseUnit CENTIMETRE;

		/// <summary>
		/// Initialize static members of <see cref="CGS"/>
		/// </summary>
		static CGS() {
			GRAM = new Measure.Units.Metric.CGS.Gram();
			CENTIMETRE = new Measure.Units.Metric.CGS.Centimetre();
		}

		/// <summary>
		/// Initialize a new instance of <see cref="CGS"/>
		/// </summary>
		private CGS() {
		}

		/// <summary>
		/// Gets <see cref="BaseUnit"/> of specified dimension.
		/// </summary>
		/// <param name="dimension"><see cref="eDimension"/> of unit</param>
		/// <returns><see cref="BaseUnit"/> equivalent to <b>dimension</b>; otherwise null</returns>
		public static BaseUnit GetReferenceUnit(eDimension dimension) {
			switch (dimension) {
				case eDimension.Current:
					return SI.AMPERE;
				case eDimension.Length:
					return CENTIMETRE;
				case eDimension.Luminosity:
					return SI.CANDELA;
				case eDimension.Mass:
					return GRAM;
				case eDimension.Substance:
					return SI.MOLE;
				case eDimension.Temperature:
					return SI.KELVIN;
				case eDimension.Time:
					return SI.SECOND;
			}

			return null;
		}
	}
}
