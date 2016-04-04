using Afk.Measure.Units.Metric.SI;

namespace Afk.Measure.Units.Metric.Derived
{
    /// <summary>
    /// Represents the minute unit (min)
    /// </summary>
	public sealed class Minute : Second {
        /// <summary>
        /// Initialize a new instance of <see cref="Minute"/>
        /// </summary>
        public Minute()
			: base() {
			_symbol = "min";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(60));
		}
	}

    /// <summary>
    /// Represents the Hour unit (h)
    /// </summary>
	public sealed class Hour : Second {
        /// <summary>
        /// Initialize a new instance of <see cref="Hour"/>
        /// </summary>
        public Hour()
			: base() {
			_symbol = "h";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(3600));
		}
	}

    /// <summary>
    /// Represents the day unit (d)
    /// </summary>
	public sealed class Day : Second {
        /// <summary>
        /// Initialize a new instance of <see cref="Day"/>
        /// </summary>
        public Day()
			: base() {
			_symbol = "d";
			_baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(3600*24));
		}
	}
}
