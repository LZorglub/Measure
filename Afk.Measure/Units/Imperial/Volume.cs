namespace Afk.Measure.Units.Imperial
{
    /// <summary>
    /// Represents the fluid once unit (fl oz)
    /// </summary>
	public class FluidOunce : Pint {
        /// <summary>
        /// Initialize a new instance of <see cref="FluidOunce"/>
        /// </summary>
        public FluidOunce()
			: base() {
			_symbol = "fl oz";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 20));
		}
	}

    /// <summary>
    /// Represents the Gill unit (gill)
    /// </summary>
	public class Gill : Pint {
        /// <summary>
        /// Initialize a new instance of <see cref="Gill"/>
        /// </summary>
        public Gill()
			: base() {
			_symbol = "gill";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.RationalConverter(1, 4));
		}
	}

    /// <summary>
    /// Represents the Pint unit (pt)
    /// </summary>
    public class Pint : BaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Pint"/>
        /// </summary>
        public Pint()
			: base(new Dimension(3, 0, 0, 0, 0, 0, 0)) {
			_symbol = "pt";
			_exponent = 1;
			_baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000000).Concat(new Afk.Measure.Converter.MultiplyConverter(568.26125));
		}
	}

    /// <summary>
    /// Represents the quart unit (qt)
    /// </summary>
	public class Quart : Pint {
        /// <summary>
        /// Initialize a new instance of <see cref="Quart"/>
        /// </summary>
        public Quart() : base() {
			_symbol = "qt";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2));
		}
	}

    /// <summary>
    /// Represents the gallon unit (gal)
    /// </summary>
	public class Gallon : Pint {
        /// <summary>
        /// Initialize a new instance of <see cref="Gallon"/>
        /// </summary>
        public Gallon() : base() {
			_symbol = "gal";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(8));
		}
	}
}
