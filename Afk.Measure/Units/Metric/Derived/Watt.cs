using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	/// <summary>
	/// Le watt (symbole W) est une unité dérivée du système international pour la puissance. Un watt est la puissance d'un système énergétique dans lequel une énergie de 1 joule est transférée uniformément pendant 1 seconde[1].
	/// </summary>
	/// <remarks>
	/// Un watt est égal à un joule par seconde, ou un newton mètre par seconde ou encore un kilogramme mètre carré par seconde au cube :
	/// W = J·s-1 = N·m·s-1 = kg·m2·s-3
	/// </remarks>
	public class Watt : ProductMetricBaseUnit {

		public Watt()
			: base(new Joule(), (Measure.Units.MetricBaseUnit)Afk.Measure.Units.System.SI.SECOND.Inverse()) {
			_exponent = 1;
			_symbol = "W";
		}
	}
}

