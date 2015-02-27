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
        public Pint()
            : base(new Dimension(3, 0, 0, 0, 0, 0, 0))
        {
            _symbol = "pt";
            _exponent = 1;
            _baseConverter = new Afk.Measure.Converter.RationalConverter(1, 1000000).Concat(new Afk.Measure.Converter.MultiplyConverter(473.176473));
        }
    }

    /// <summary>
    /// Represents US quart : 2 pt
    /// </summary>
    public class Quart : Pint
    {
        public Quart()
            : base()
        {
            _symbol = "qt";
            _baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(2));
        }
    }

    /// <summary>
    /// Represents the US gallon
    /// </summary>
    public class Gallon : Pint
    {
        public Gallon()
            : base()
        {
            _symbol = "gal";
            _baseConverter = _baseConverter.Concat(new Afk.Measure.Converter.MultiplyConverter(8));
        }
    }

}
