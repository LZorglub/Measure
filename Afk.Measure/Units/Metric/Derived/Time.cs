using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.Metric.SI;

namespace Afk.Measure.Units.Metric.Derived {
	public sealed class Minute : Second {
		public Minute()
			: base() {
			_symbol = "min";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(60));
		}
	}


	public sealed class Hour : Second {
		public Hour()
			: base() {
			_symbol = "h";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(3600));
		}
	}

	public sealed class Day : Second {
		public Day()
			: base() {
			_symbol = "d";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(3600*24));
		}
	}
}
