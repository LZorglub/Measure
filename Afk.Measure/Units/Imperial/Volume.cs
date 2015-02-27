using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Imperial {

	public class FluidOunce : Pint {
		public FluidOunce()
			: base() {
			_symbol = "fl oz";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 20));
		}
	}

	public class Gill : Pint {
		public Gill()
			: base() {
			_symbol = "gill";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 4));
		}
	}
	
	public class Pint : BaseUnit {
		public Pint()
			: base(new Dimension(3, 0, 0, 0, 0, 0, 0)) {
			_symbol = "pt";
			_exponent = 1;
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000000).Concat(new Afk.Measure.Converter.MultiplyConverter(568.26125));
		}
	}

	public class Quart : Pint {
		public Quart() : base() {
			_symbol = "qt";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2));
		}
	}

	public class Gallon : Pint {
		public Gallon() : base() {
			_symbol = "gal";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(8));
		}
	}
}
