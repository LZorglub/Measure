using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.System {
	/// <summary>
	/// Represents the SI system
	/// </summary>
	public sealed class SI {
		/// <summary>
		/// Gets the unit for Ampere
		/// </summary>
		public static Measure.Units.MetricBaseUnit AMPERE;
		/// <summary>
		/// Gets the unit for candela
		/// </summary>
		public static Measure.Units.MetricBaseUnit CANDELA;
		/// <summary>
		/// Gets the unit for gram
		/// </summary>
		/// <remarks>Gram is the only unit with a prefix, the symbol is kg.</remarks>
		public static Measure.Units.MetricBaseUnit GRAM;
		/// <summary>
		/// Gets the unit for Kelvin
		/// </summary>
		public static Measure.Units.MetricBaseUnit KELVIN;
		/// <summary>
		/// Gets the unit for Meter
		/// </summary>
		public static Measure.Units.MetricBaseUnit METER;
		/// <summary>
		/// Gets the unit for Mole
		/// </summary>
		public static Measure.Units.MetricBaseUnit MOLE;
		/// <summary>
		/// Gets the unit for Second
		/// </summary>
		public static Measure.Units.MetricBaseUnit SECOND;

		/// <summary>
		/// Initialize static members of <see cref="SI"/>
		/// </summary>
		static SI() {
			AMPERE = new Measure.Units.Metric.SI.Ampere();
			CANDELA = new Measure.Units.Metric.SI.Candela();
			GRAM = new Measure.Units.Metric.SI.Gram();
			KELVIN = new Measure.Units.Metric.SI.Kelvin();
			METER = new Measure.Units.Metric.SI.Meter();
			MOLE = new Measure.Units.Metric.SI.Mole();
			SECOND = new Measure.Units.Metric.SI.Second();
		}

		/// <summary>
		/// Initiliaze a new instance of <see cref="SI"/>
		/// </summary>
		private SI() {
		}

		/// <summary>
		/// Gets <see cref="BaseUnit"/> of specified dimension.
		/// </summary>
		/// <param name="dimension"><see cref="eDimension"/> of unit</param>
		/// <returns><see cref="BaseUnit"/> equivalent to <b>dimension</b>; otherwise null</returns>
		public static BaseUnit GetReferenceUnit(eDimension dimension) {
			switch (dimension) {
				case eDimension.Current:
					return AMPERE;
				case eDimension.Length:
					return METER;
				case eDimension.Luminosity:
					return CANDELA;
				case eDimension.Mass:
					return GRAM;
				case eDimension.Substance:
					return MOLE;
				case eDimension.Temperature:
					return KELVIN;
				case eDimension.Time:
					return SECOND;
			}

			return null;
		}
	}
}
