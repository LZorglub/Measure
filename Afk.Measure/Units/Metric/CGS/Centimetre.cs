using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.CGS {
	public class Centimetre : MetricBaseUnit, IMetricUnitOffset {

		public Centimetre()
			: base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "cm";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(10).Power(-2);
		}

		#region IMetricUnitOffset Membres

		public Measure.Units.Metric.Prefixes.SIPrefixe Prefixe {
			get { return Measure.Units.Metric.Prefixes.SIPrefixe.Centi; }
		}

		public string MetricSymbol {
			get { return "m"; }
		}

		#endregion
	}
}
