using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Currency {
	public class Euro : BaseUnit {

		public Euro()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "EUR";
		}

	}

	#region Anciennes devises
	/// <summary>
	/// Franc français
	/// </summary>
	public sealed class FrenchFranc : BaseUnit {
		public FrenchFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "FRF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957000161);
		}
	}

	/// <summary>
	/// Mark allemand
	/// </summary>
	public sealed class DeutscheMark : BaseUnit {
		public DeutscheMark()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "DEM";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1.95583);
		}
	}

	/// <summary>
	/// Schilling autrichien
	/// </summary>
	public sealed class AustrichSchilling : BaseUnit {
		public AustrichSchilling()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ATS";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 13.7603);
		}
	}

	/// <summary>
	/// Franc belge
	/// </summary>
	public sealed class BelgiumFranc : BaseUnit {
		public BelgiumFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "BEF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 40.3399);
		}
	}

	/// <summary>
	/// Peseta
	/// </summary>
	public sealed class Peseta : BaseUnit {
		public Peseta()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ESP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 166.386);
		}
	}

	/// <summary>
	/// Mark finlandais
	/// </summary>
	public sealed class FinlandMark : BaseUnit {
		public FinlandMark()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "FIM";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 5.94573);
		}
	}

	/// <summary>
	/// Livre irlandaise
	/// </summary>
	public sealed class IrishPound : BaseUnit {
		public IrishPound()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "IEP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.787564);
		}
	}

	/// <summary>
	/// Lire italienne
	/// </summary>
	public sealed class ItalyLire : BaseUnit {
		public ItalyLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ITL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Franc luxembourgeois
	/// </summary>
	public sealed class LuxembourgFranc : BaseUnit {
		public LuxembourgFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "LUF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 40.3399);
		}
	}

	/// <summary>
	/// Florin neerlandais
	/// </summary>
	public sealed class Gulden : BaseUnit {
		public Gulden()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "NLG";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 2.20371);
		}
	}

	/// <summary>
	/// Escudo Portugal
	/// </summary>
	public sealed class Escudo : BaseUnit {
		public Escudo()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "PTE";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 200.482);
		}
	}

	/// <summary>
	/// Franc andorran
	/// </summary>
	public sealed class AndorFranc : BaseUnit {
		public AndorFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ADF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957);
		}
	}

	/// <summary>
	/// Peseta andorrane
	/// </summary>
	public sealed class AndorPeseta : BaseUnit {
		public AndorPeseta()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "ADP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 166.386);
		}
	}

	/// <summary>
	/// Franc monegasque
	/// </summary>
	public sealed class MonacoFranc : BaseUnit {
		public MonacoFranc()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "MCF";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 6.55957);
		}
	}

	/// <summary>
	/// Lire de saint-marin
	/// </summary>
	public sealed class SaintMarinLire : BaseUnit {
		public SaintMarinLire ()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SML";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Lire vaticane
	/// </summary>
	public sealed class VaticanLire : BaseUnit {
		public VaticanLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "VAL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 1936.27);
		}
	}

	/// <summary>
	/// Drachme grecque
	/// </summary>
	public sealed class Drachme : BaseUnit {
		public Drachme()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "GRD";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 340.750);
		}
	}

	/// <summary>
	/// Tolar slovène
	/// </summary>
	public sealed class Tolar : BaseUnit {
		public Tolar()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SIT";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 239.640);
		}
	}

	/// <summary>
	/// Livre chypriote
	/// </summary>
	public sealed class CypreLivre  : BaseUnit {
		public CypreLivre()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "CYP";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.585274);
		}
	}

	/// <summary>
	/// Lire maltaise
	/// </summary>
	public sealed class MalteLire : BaseUnit {
		public MalteLire()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "MTL";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 0.4293);
		}
	}

	/// <summary>
	/// Couronne slovaque
	/// </summary>
	public sealed class SlovenskaKoruna : BaseUnit {
		public SlovenskaKoruna()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "SKK";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 30.1260);
		}
	}

	/// <summary>
	/// Couronne estonienne
	/// </summary>
	public sealed class EestiKroon : BaseUnit {
		public EestiKroon()
			: base(new Dimension(0, 0, 0, 0, 0, 0, 0, 1)) {
			_symbol = "EKK";
			_baseConverter = new Afk.Measure.Converter.MultiplyConverter(1 / 15.6466);
		}
	}

	#endregion

}
