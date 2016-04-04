namespace Afk.Measure.Units.Imperial
{
    /// <summary>
    /// Represents the Grain unit (grain)
    /// </summary>
    public class Grain : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Grain"/>
        /// </summary>
        public Grain()
			: base() {
			_symbol = "grain";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 7000));
		}
	}

    /// <summary>
    /// Represents the Drachm unit (drachm)
    /// </summary>
	public class Drachm : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Drachm"/>
        /// </summary>
        public Drachm()
			: base() {
			_symbol = "drachm";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 256));
		}
	}

    /// <summary>
    /// Represents the Ounce unit (oz)
    /// </summary>
	public class Ounce : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Ounce"/>
        /// </summary>
        public Ounce()
			: base() {
			_symbol = "oz";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 16));
		}
	}

    /// <summary>
    /// Represents the Pound unit (lb)
    /// </summary>
	public class Pound : BaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Pound"/>
        /// </summary>
        public Pound()
			: base(new Dimension(0, 0, 0, 1, 0, 0, 0)) {
			_symbol = "lb";
			_exponent = 1;
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000).Concat(new Afk.Measure.Converter.MultiplyConverter(453.59237));
		}
	}

    /// <summary>
    /// Represents the stone unit (st)
    /// </summary>
	public class Stone : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Stone"/>
        /// </summary>
        public Stone()
			: base() {
			_symbol = "st";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(14));
		}
	}

    /// <summary>
    /// Represents the Quarter unit (quarter)
    /// </summary>
	public class Quarter : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Quarter"/>
        /// </summary>
        public Quarter()
			: base() {
			_symbol = "quarter";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(28));
		}
	}

    /// <summary>
    /// Represents the hundredWeight unit (cwt)
    /// </summary>
	public class HundredWeight : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="HundredWeight"/>
        /// </summary>
        public HundredWeight()
			: base() {
			_symbol = "cwt";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(112));
		}
	}

    /// <summary>
    /// Represents the Ton unit (t)
    /// </summary>
	public class Ton : Pound {
        /// <summary>
        /// Initialize a new instance of <see cref="Ton"/>
        /// </summary>
        public Ton()
			: base() {
			_symbol = "t";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2240));
		}
	}
}