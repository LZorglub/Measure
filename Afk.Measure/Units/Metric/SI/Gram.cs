using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.SI {
	/// <summary>
	/// Represents the Gram unit (kg)
	/// </summary>
	/// <remarks>It is important to note that the kilogram is the only SI unit with a prefix as part of its name and symbol</remarks>
	public class Gram : MetricBaseUnit, IMetricUnitOffset {
        /// <summary>
        /// Initialize a new instance of <see cref="Gram"/>
        /// </summary>
        public Gram()
			: base(new Dimension(0, 0, 0, 1, 0, 0, 0)) {
			_symbol = "kg";
		}


		#region IMetricUnitOffset Membres
		/// <summary>
		/// Gets the default prefix of unit
		/// </summary>
		/// <remarks>The kilogram is the base unit because it, not grams is used in the definitions of derived units</remarks>
		public Measure.Units.Metric.Prefixes.SIPrefixe Prefixe {
			get { return Measure.Units.Metric.Prefixes.SIPrefixe.Kilo; }
		}

		/// <summary>
		/// Gets the metric symbol without prefix
		/// </summary>
		public string MetricSymbol {
			get { return "g"; }
		}
		#endregion
	}
}
