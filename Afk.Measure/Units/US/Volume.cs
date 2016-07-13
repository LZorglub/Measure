using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// United States customary units : http://en.wikipedia.org/wiki/United_States_customary_units#Units_of_capacity_and_volume

namespace Afk.Measure.Units.US
{
    /// <summary>
    /// Represents US pint
    /// </summary>
    public class Pint : BaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Pint"/>
        /// </summary>
        public Pint()
            : base(new Dimension(3, 0, 0, 0, 0, 0, 0))
        {
            _symbol = "pt";
            this.Exponent = 1;
            _baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000000).Concat(new Afk.Measure.Converter.MultiplyConverter(473.176473));
        }

        /// <summary>
        /// Gets the localizable symbol of Pint
        /// </summary>
        public override string LocalizableSymbol
        {
            get
            {
                return "pt US";
            }
        }
    }

    /// <summary>
    /// Represents US quart : 2 pt
    /// </summary>
    public class Quart : Pint
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Quart"/>
        /// </summary>
        public Quart()
            : base()
        {
            _symbol = "qt";
            _baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2));
        }

        /// <summary>
        /// Gets the localizable symbol of Quart
        /// </summary>
        public override string LocalizableSymbol
        {
            get
            {
                return "qt US";
            }
        }
    }

    /// <summary>
    /// Represents the US gallon
    /// </summary>
    public class Gallon : Pint
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Gallon"/>
        /// </summary>
        public Gallon()
            : base()
        {
            _symbol = "gal";
            _baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(8));
        }

        /// <summary>
        /// Gets the localizable symbol of gallon
        /// </summary>
        public override string LocalizableSymbol
        {
            get
            {
                return "gal US";
            }
        }
    }

}
