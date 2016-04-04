namespace Afk.Measure.Units.Imperial
{
    /// <summary>
    /// Represents the inch unit
    /// </summary>
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

    /// <summary>
    /// Represents the foot unit
    /// </summary>
    public class Foot : BaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Foot"/>
        /// </summary>
        public Foot() : base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "ft";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(0.3048);
		}
	}

    /// <summary>
    /// Represents the yard unit
    /// </summary>
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
    
    /// <summary>
    /// Represents the mile unit
    /// </summary>
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
