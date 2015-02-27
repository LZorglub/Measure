using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Imperial {

	public class Grain : Pound {
		public Grain()
			: base() {
			_symbol = "grain";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 7000));
		}
	}

	public class Drachm : Pound {
		public Drachm()
			: base() {
			_symbol = "drachm";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 256));
		}
	}

	public class Ounce : Pound {
		public Ounce()
			: base() {
			_symbol = "oz";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 16));
		}
	}

	public class Pound : BaseUnit {
		public Pound()
			: base(new Dimension(0, 0, 0, 1, 0, 0, 0)) {
			_symbol = "lb";
			_exponent = 1;
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000).Concat(new Afk.Measure.Converter.MultiplyConverter(453.59237));
		}
	}

	public class Stone : Pound {
		public Stone()
			: base() {
			_symbol = "st";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(14));
		}
	}

	public class Quarter : Pound {
		public Quarter()
			: base() {
			_symbol = "quarter";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(28));
		}
	}

	public class HundredWeight : Pound {
		public HundredWeight()
			: base() {
			_symbol = "cwt";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(112));
		}
	}

	public class Ton : Pound {
		public Ton()
			: base() {
			_symbol = "t";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2240));
		}
	}
}