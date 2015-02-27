using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace Afk.Measure.Units.Metric.Derived {
	public class Volume : ProductMetricBaseUnit{
		public Volume()
			: base(new Area(), Afk.Measure.Units.System.SI.METER) {
		}
	}

	/// <summary>
	/// Représente l'unité litre.
	/// </summary>
	/// <remarks>
	/// La classe Litre ne peut pas hériter de <see cref="Volume"/>.
	/// Un volume est égal à dm * dm * dm. Si Litre hérite de volume ses unités étendues seront le mètre
	/// ce qui provoque une erreur de conversion lorsque celles ci devront être utilisé.
	/// Cas : l * (m.°C) = m4.°C on préfére l * (m.°C) = l.m.°C
	/// </remarks>
	public class Litre : MetricBaseUnit {
		public Litre()
			: base(new Dimension(3, 0, 0, 0, 0, 0, 0)) {
			_exponent = 1;
			_symbol = "l";
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000);
		}
	}
}
