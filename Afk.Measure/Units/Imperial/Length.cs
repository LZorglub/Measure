using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Imperial {
	public class Inch : Foot
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Inch"/>
        /// </summary>
		public Inch()
			: base() {
			_symbol = "in";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 12));
		}
	}

	public class Foot : BaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Foot"/>
        /// </summary>
        public Foot() : base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "ft";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(0.3048);
		}
	}

	public class Yard : Foot {
        /// <summary>
        /// Initialize a new instance of <see cref="Yard"/>
        /// </summary>
        public Yard()
			: base() {
			_symbol = "yd";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(3));
		}
	}

	public class Mile : Foot {
        /// <summary>
        /// Initialize a new instance of <see cref="Mile"/>
        /// </summary>
        public Mile()
			: base() {
			_symbol = "mi";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(5280));
		}
	}

}
