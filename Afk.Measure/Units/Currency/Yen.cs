using Afk.Measure.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Currency
{
    /// <summary>
    /// Represents the yen currency
    /// </summary>
    public class Yen : BaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Yen"/>
        /// </summary>
		public Yen()
            : base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1))
        {
            _symbol = "¥";
            // The conversion is based on exchange rate, we dont provide any default convertion
            _baseConverter = UnitConverter.NULL;
        }

        /// <summary>
        /// Gets the converter unit
        /// </summary>
        public override Converter.UnitConverter BaseConverter
        {
            get
            {
                return CurrencyContext.GetConverter(this);
            }
        }
    }
}
