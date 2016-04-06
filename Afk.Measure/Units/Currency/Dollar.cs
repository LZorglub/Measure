using Afk.Measure.Converter;

namespace Afk.Measure.Units.Currency
{
    /// <summary>
    /// Represents the dollar currency
    /// </summary>
    public class Dollar : BaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Dollar"/>
        /// </summary>
		public Dollar()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
            _symbol = "$";
            // The conversion is based on exchange rate, we dont provide any default conversion
            _baseConverter = UnitConverter.NULL;
        }

        /// <summary>
        /// Gets the converter unit
        /// </summary>
        public override Converter.UnitConverter BaseConverter
        {
            get {
                return CurrencyContext.GetConverter(this);
            }
        }
    }
}
