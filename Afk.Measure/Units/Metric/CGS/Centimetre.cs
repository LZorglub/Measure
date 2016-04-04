namespace Afk.Measure.Units.Metric.CGS
{

    /// <summary>
    /// Represents the Cm, a centimetre-gram-second (CGS) unit of length
    /// </summary>
    public class Centimetre : MetricBaseUnit, IMetricUnitOffset {

        /// <summary>
        /// Initiliaze a new instance of <see cref="Centimetre"/>
        /// </summary>
		public Centimetre()
			: base(new Dimension(1, 0, 0, 0, 0, 0, 0)) {
			_symbol = "cm";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(10).Power(-2);
		}

		#region IMetricUnitOffset Membres
        /// <summary>
        /// Gets the prefix of the unit
        /// </summary>
		public Measure.Units.Metric.Prefixes.SIPrefixe Prefixe {
			get { return Measure.Units.Metric.Prefixes.SIPrefixe.Centi; }
		}

        /// <summary>
        /// Gets the metric symbol
        /// </summary>
		public string MetricSymbol {
			get { return "m"; }
		}

		#endregion
	}
}
