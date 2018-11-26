namespace Afk.Measure.Units.Currency
{
    /// <summary>
    /// Represents the euro unit
    /// </summary>
    public class Euro : MetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Euro"/>
        /// </summary>
		public Euro()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "EUR";
		}
	}

    /// <summary>
    /// Represents the euro symbol unit
    /// </summary>
    public class EuroSymbol : MetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="EuroSymbol"/>
        /// </summary>
		public EuroSymbol()
            : base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1))
        {
            _symbol = "€";
        }
    }

    #region Old currency
    /// <summary>
    /// Franc français
    /// </summary>
    public sealed class FrenchFranc : MetricBaseUnit
    {
        /// <summary>
        /// Initialize a new instance of <see cref="FrenchFranc"/>
        /// </summary>
		public FrenchFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "FRF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957000161);
		}
	}

	/// <summary>
	/// Mark allemand
	/// </summary>
	public sealed class DeutscheMark : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="DeutscheMark"/>
        /// </summary>
        public DeutscheMark()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "DEM";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1.95583);
		}
	}

	/// <summary>
	/// Schilling autrichien
	/// </summary>
	public sealed class AustrichSchilling : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="AustrichSchilling"/>
        /// </summary>
        public AustrichSchilling()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ATS";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 13.7603);
		}
	}

	/// <summary>
	/// Franc belge
	/// </summary>
	public sealed class BelgiumFranc : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="BelgiumFranc"/>
        /// </summary>
        public BelgiumFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "BEF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 40.3399);
		}
	}

	/// <summary>
	/// Peseta
	/// </summary>
	public sealed class Peseta : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Peseta"/>
        /// </summary>
        public Peseta()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ESP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 166.386);
		}
	}

	/// <summary>
	/// Mark finlandais
	/// </summary>
	public sealed class FinlandMark : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="FinlandMark"/>
        /// </summary>
        public FinlandMark()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "FIM";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 5.94573);
		}
	}

	/// <summary>
	/// Livre irlandaise
	/// </summary>
	public sealed class IrishPound : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="IrishPound"/>
        /// </summary>
        public IrishPound()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "IEP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.787564);
		}
	}

	/// <summary>
	/// Lire italienne
	/// </summary>
	public sealed class ItalyLire : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="ItalyLire"/>
        /// </summary>
        public ItalyLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ITL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Franc luxembourgeois
	/// </summary>
	public sealed class LuxembourgFranc : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="LuxembourgFranc"/>
        /// </summary>
        public LuxembourgFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "LUF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 40.3399);
		}
	}

	/// <summary>
	/// Florin neerlandais
	/// </summary>
	public sealed class Gulden : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Gulden"/>
        /// </summary>
        public Gulden()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "NLG";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 2.20371);
		}
	}

	/// <summary>
	/// Escudo Portugal
	/// </summary>
	public sealed class Escudo : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Escudo"/>
        /// </summary>
        public Escudo()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "PTE";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 200.482);
		}
	}

	/// <summary>
	/// Franc andorran
	/// </summary>
	public sealed class AndorFranc : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="AndorFranc"/>
        /// </summary>
        public AndorFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ADF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957);
		}
	}

	/// <summary>
	/// Peseta andorrane
	/// </summary>
	public sealed class AndorPeseta : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="AndorPeseta"/>
        /// </summary>
        public AndorPeseta()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ADP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 166.386);
		}
	}

	/// <summary>
	/// Franc monegasque
	/// </summary>
	public sealed class MonacoFranc : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="MonacoFranc"/>
        /// </summary>
        public MonacoFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "MCF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957);
		}
	}

	/// <summary>
	/// Lire de saint-marin
	/// </summary>
	public sealed class SaintMarinLire : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="SaintMarinLire"/>
        /// </summary>
        public SaintMarinLire ()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SML";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Lire vaticane
	/// </summary>
	public sealed class VaticanLire : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="VaticanLire"/>
        /// </summary>
        public VaticanLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "VAL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Drachme grecque
	/// </summary>
	public sealed class Drachme : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Drachme"/>
        /// </summary>
        public Drachme()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "GRD";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 340.750);
		}
	}

	/// <summary>
	/// Tolar slovène
	/// </summary>
	public sealed class Tolar : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="Tolar"/>
        /// </summary>
        public Tolar()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SIT";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 239.640);
		}
	}

	/// <summary>
	/// Livre chypriote
	/// </summary>
	public sealed class CypreLivre  : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="CypreLivre"/>
        /// </summary>
        public CypreLivre()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "CYP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.585274);
		}
	}

	/// <summary>
	/// Lire maltaise
	/// </summary>
	public sealed class MalteLire : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="MalteLire"/>
        /// </summary>
        public MalteLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "MTL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.4293);
		}
	}

	/// <summary>
	/// Couronne slovaque
	/// </summary>
	public sealed class SlovenskaKoruna : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="SlovenskaKoruna"/>
        /// </summary>
        public SlovenskaKoruna()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SKK";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 30.1260);
		}
	}

	/// <summary>
	/// Couronne estonienne
	/// </summary>
	public sealed class EestiKroon : MetricBaseUnit {
        /// <summary>
        /// Initialize a new instance of <see cref="EestiKroon"/>
        /// </summary>
        public EestiKroon()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "EKK";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 15.6466);
		}
	}

	#endregion

}
