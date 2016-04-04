namespace Afk.Measure.Units.Metric.Prefixes
{
    /// <summary>
    /// Represents a decimal or a binary prefixe 
    /// </summary>
    /// <remarks>
    /// It is important to note that the kilogram is the only SI unit with a prefix as part of 
    /// its name and symbol. Because multiple prefixes may not be used, in the case of the 
    /// kilogram the prefix names are used with the unit name "gram" and the prefix symbols 
    /// are used with the unit symbol "g." 
    /// With this exception, any SI prefix may be used with any SI unit
    /// </remarks>
    public sealed class SIPrefixe {

		#region SI Prefixe
		private static SIPrefixe _Yotta;
		private static SIPrefixe _Zetta;
		private static SIPrefixe _Exbi;
		private static SIPrefixe _Exa;
		private static SIPrefixe _Pebi;
		private static SIPrefixe _Peta;
		private static SIPrefixe _Tebi;
		private static SIPrefixe _Tera;
		private static SIPrefixe _Gibi;
		private static SIPrefixe _Giga;
		private static SIPrefixe _Mebi;
		private static SIPrefixe _Mega;
		private static SIPrefixe _Kibi;
		private static SIPrefixe _Kilo;
		private static SIPrefixe _Hecto;
		private static SIPrefixe _Deka;
		private static SIPrefixe _None;
		private static SIPrefixe _Deci;
		private static SIPrefixe _Centi;
		private static SIPrefixe _Milli;
		private static SIPrefixe _Micro;
		private static SIPrefixe _Nano;
		private static SIPrefixe _Pico;
		private static SIPrefixe _Femto;
		private static SIPrefixe _Atto;
		private static SIPrefixe _Zepto;
		private static SIPrefixe _Yocto;

		/// <summary>
		/// Gets the yotta prefixe
		/// </summary>
		public static SIPrefixe Yotta { get { return _Yotta; } }
		/// <summary>
		/// Gets the zetta prefixe
		/// </summary>
		public static SIPrefixe Zetta { get { return _Zetta; } }
		/// <summary>
		/// Gets the exbi prefixe
		/// </summary>
		public static SIPrefixe Exbi { get { return _Exbi; } }
		/// <summary>
		/// Gets the exa prefixe
		/// </summary>
		public static SIPrefixe Exa { get { return _Exa; } }
		/// <summary>
		/// Gets the pebi prefixe
		/// </summary>
		public static SIPrefixe Pebi { get { return _Pebi; } }
		/// <summary>
		/// Gets the peta prefixe
		/// </summary>
		public static SIPrefixe Peta { get { return _Peta; } }
		/// <summary>
		/// Gets the tebi prefixe
		/// </summary>
		public static SIPrefixe Tebi { get { return _Tebi; } }
		/// <summary>
		/// Gets the tera prefixe
		/// </summary>
		public static SIPrefixe Tera { get { return _Tera; } }
		/// <summary>
		/// Gets the gibi prefixe
		/// </summary>
		public static SIPrefixe Gibi { get { return _Gibi; } }
		/// <summary>
		/// Gets the giga prefixe
		/// </summary>
		public static SIPrefixe Giga { get { return _Giga; } }
		/// <summary>
		/// Gets the mebi prefixe
		/// </summary>
		public static SIPrefixe Mebi { get { return _Mebi; } }
		/// <summary>
		/// Gets the mega prefixe
		/// </summary>
		public static SIPrefixe Mega { get { return _Mega; } }
		/// <summary>
		/// Gets the kibi prefixe
		/// </summary>
		public static SIPrefixe Kibi { get { return _Kibi; } }
		/// <summary>
		/// Gets the kilo prefixe
		/// </summary>
		public static SIPrefixe Kilo { get { return _Kilo; } }
		/// <summary>
		/// Gets the hecto prefixe
		/// </summary>
		public static SIPrefixe Hecto { get { return _Hecto; } }
		/// <summary>
		/// Gets the deka prefixe
		/// </summary>
		public static SIPrefixe Deka { get { return _Deka; } }
		/// <summary>
		/// Gets the empty prefixe
		/// </summary>
		public static SIPrefixe None { get { return _None; } }
		/// <summary>
		/// Gets the deci prefixe
		/// </summary>
		public static SIPrefixe Deci { get { return _Deci; } }
		/// <summary>
		/// Gets the centi prefixe
		/// </summary>
		public static SIPrefixe Centi { get { return _Centi; } }
		/// <summary>
		/// Gets the milli prefixe
		/// </summary>
		public static SIPrefixe Milli { get { return _Milli; } }
		/// <summary>
		/// Gets the micro prefixe
		/// </summary>
		public static SIPrefixe Micro { get { return _Micro; } }
		/// <summary>
		/// Gets the nano prefixe
		/// </summary>
		public static SIPrefixe Nano { get { return _Nano; } }
		/// <summary>
		/// Gets the pico prefixe
		/// </summary>
		public static SIPrefixe Pico { get { return _Pico; } }
		/// <summary>
		/// Gets the femto prefixe
		/// </summary>
		public static SIPrefixe Femto { get { return _Femto; } }
		/// <summary>
		/// Gets the atto prefixe
		/// </summary>
		public static SIPrefixe Atto { get { return _Atto; } }
		/// <summary>
		/// Gets the zepto prefixe
		/// </summary>
		public static SIPrefixe Zepto { get { return _Zepto; } }
		/// <summary>
		/// Gets the yocto prefixe
		/// </summary>
		public static SIPrefixe Yocto { get { return _Yocto; } }
		#endregion

		/// <summary>
		/// Gets the prefixe name
		/// </summary>
        public string Name
        {
            get;
            private set;
        }

		/// <summary>
		/// Gets the prefixe symbol
		/// </summary>
		public string Symbol {
            get;
            private set;
        }

		/// <summary>
		/// Gets the prefixe baseN 
		/// </summary>
		public long Base {
            get;
            private set;
        }

		/// <summary>
		/// Gets the exponent prefixe
		/// </summary>
		public ExponentPrefixes Exponent {
            get;
            private set;
        }

		/// <summary>
		/// Initialize the static members of <see cref="SIPrefixe"/>
		/// </summary>
		static SIPrefixe() {
			_Yotta = new SIPrefixe("yotta", "Y", ExponentPrefixes.Yotta);
			_Zetta = new SIPrefixe("zetta", "Z", ExponentPrefixes.Zetta);
			_Exbi = new SIPrefixe("exbi", "Ei", ExponentPrefixes.Exbi, 2);
			_Exa = new SIPrefixe("exa", "E", ExponentPrefixes.Exa);
			_Pebi = new SIPrefixe("pebi", "Pi", ExponentPrefixes.Pebi, 2);
			_Peta = new SIPrefixe("peta", "P", ExponentPrefixes.Peta);
			_Tebi = new SIPrefixe("tebi", "Ti", ExponentPrefixes.Tebi, 2);
			_Tera = new SIPrefixe("tera", "T", ExponentPrefixes.Tera);
			_Gibi = new SIPrefixe("gibi", "Gi", ExponentPrefixes.Gibi, 2);
			_Giga = new SIPrefixe("giga", "G", ExponentPrefixes.Giga);
			_Mebi = new SIPrefixe("mebi", "Mi", ExponentPrefixes.Mebi, 2);
			_Mega = new SIPrefixe("mega", "M", ExponentPrefixes.Mega);
			_Kibi = new SIPrefixe("kibi", "Ki", ExponentPrefixes.Kibi, 2);
			_Kilo = new SIPrefixe("kilo", "k", ExponentPrefixes.Kilo);
			_Hecto = new SIPrefixe("hecto", "h", ExponentPrefixes.Hecto);
			_Deka = new SIPrefixe("deka", "da", ExponentPrefixes.Deka);
			_None = new SIPrefixe("", "", ExponentPrefixes.None);
			_Deci = new SIPrefixe("deci", "d", ExponentPrefixes.Deci);
			_Centi = new SIPrefixe("centi", "c", ExponentPrefixes.Centi);
			_Milli = new SIPrefixe("milli", "m", ExponentPrefixes.Milli);
			_Micro = new SIPrefixe("micro", "µ", ExponentPrefixes.Micro);
			_Nano = new SIPrefixe("nano", "n", ExponentPrefixes.Nano);
			_Pico = new SIPrefixe("pico", "p", ExponentPrefixes.Pico);
			_Femto = new SIPrefixe("femto", "f", ExponentPrefixes.Femto);
			_Atto = new SIPrefixe("atto", "a", ExponentPrefixes.Atto);
			_Zepto = new SIPrefixe("zepto", "z", ExponentPrefixes.Zepto);
			_Yocto = new SIPrefixe("yocto", "y", ExponentPrefixes.Yocto);
		}

		/// <summary>
		/// Initialize a new instance of <see cref="SIPrefixe"/>
		/// </summary>
		private SIPrefixe() {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="SIPrefixe"/>
		/// </summary>
		/// <param name="name">Prefixe name</param>
		/// <param name="symbol">Prefixe symbol</param>
		/// <param name="prefixe"><see cref="ExponentPrefixes"/> enum.</param>
		/// <remarks>Default base is 10</remarks>
		private SIPrefixe(string name, string symbol, ExponentPrefixes prefixe)
			: this(name, symbol, prefixe, 10) {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="SIPrefixe"/>
		/// </summary>
		/// <param name="name">Prefixe name</param>
		/// <param name="symbol">Prefixe symbol</param>
		/// <param name="prefixe"><see cref="ExponentPrefixes"/> enum.</param>
		/// <param name="power">Prefixe base</param>
		private SIPrefixe(string name, string symbol, ExponentPrefixes prefixe, long power) {
			Name = name;
			Symbol = symbol;
			Exponent = prefixe;
			Base = power;
		}

		/// <summary>
		/// Converts the value of the current <see cref="SIPrefixe"/> object to its equivalent string representation
		/// </summary>
		/// <returns>A string representation of the value of the current <see cref="SIPrefixe"/> object</returns>
		public override string ToString() {
			return this.GetType().Name + " " + this.Exponent.ToString();
		}

		/// <summary>
		/// Converts the string representation of a prefixe to its <see cref="SIPrefixe"/> equivalent.
		/// </summary>
		/// <param name="symbol"><see cref="String"/> containing a prefixe to convert.</param>
		/// <returns><see cref="SIPrefixe"/> value equivalent to the string contained in <b>prefixe</b>; otherwise null</returns>
		public static SIPrefixe Parse(string prefixe) {
			return Parse(prefixe, false);
		}

		/// <summary>
		/// Converts the string representation of a prefixe to its <see cref="SIPrefixe"/> equivalent.
		/// </summary>
		/// <param name="symbol"><see cref="String"/> containing a prefixe to convert.</param>
		/// <param name="ignoreCase">Indicator which specify if method if case-sensitive or not.</param>
		/// <returns><see cref="SIPrefixe"/> value equivalent to the string contained in <b>prefixe</b>; otherwise null</returns>
		public static SIPrefixe Parse(string prefixe, bool ignoreCase) {
			if (string.IsNullOrEmpty(prefixe)) return _None;

			if (string.Compare(prefixe, "yotta", ignoreCase) == 0
			 || string.Compare(prefixe, "Y"    , ignoreCase) == 0) return _Yotta;
			if (string.Compare(prefixe, "zetta", ignoreCase) == 0
			 || string.Compare(prefixe, "Z"    , ignoreCase) == 0) return _Zetta;
			if (string.Compare(prefixe, "exbi", ignoreCase) == 0
			 || string.Compare(prefixe, "Ei", ignoreCase) == 0) return _Exbi;
			if (string.Compare(prefixe, "exa", ignoreCase) == 0
			 || string.Compare(prefixe, "E"    , ignoreCase) == 0) return _Exa;
			if (string.Compare(prefixe, "pebi", ignoreCase) == 0
			 || string.Compare(prefixe, "Pi", ignoreCase) == 0) return _Pebi;
			if (string.Compare(prefixe, "peta", ignoreCase) == 0
			 || string.Compare(prefixe, "P"    , ignoreCase) == 0) return _Peta;
			if (string.Compare(prefixe, "tebi", ignoreCase) == 0
			 || string.Compare(prefixe, "Ti", ignoreCase) == 0) return _Tebi;
			if (string.Compare(prefixe, "tera" , ignoreCase) == 0
			 || string.Compare(prefixe, "T"    , ignoreCase) == 0) return _Tera;
			if (string.Compare(prefixe, "gibi", ignoreCase) == 0
			 || string.Compare(prefixe, "Gi", ignoreCase) == 0) return _Gibi;
			if (string.Compare(prefixe, "giga", ignoreCase) == 0
			 || string.Compare(prefixe, "G"    , ignoreCase) == 0) return _Giga;
			if (string.Compare(prefixe, "mebi", ignoreCase) == 0
			 || string.Compare(prefixe, "Mi", ignoreCase) == 0) return _Mebi;
			if (string.Compare(prefixe, "mega", ignoreCase) == 0
			 || string.Compare(prefixe, "M"    , ignoreCase) == 0) return _Mega;
			if (string.Compare(prefixe, "kibi", ignoreCase) == 0
			 || string.Compare(prefixe, "Ki", ignoreCase) == 0) return _Kibi;
			if (string.Compare(prefixe, "kilo", ignoreCase) == 0
			 || string.Compare(prefixe, "k"    , ignoreCase) == 0) return _Kilo;
			if (string.Compare(prefixe, "hecto", ignoreCase) == 0
			 || string.Compare(prefixe, "h"    , ignoreCase) == 0) return _Hecto;
			if (string.Compare(prefixe, "deka" , ignoreCase) == 0
			 || string.Compare(prefixe, "da"   , ignoreCase) == 0) return _Deka;
			if (string.Compare(prefixe, "deci" , ignoreCase) == 0
			 || string.Compare(prefixe, "d"    , ignoreCase) == 0) return _Deci;
			if (string.Compare(prefixe, "centi", ignoreCase) == 0
			 || string.Compare(prefixe, "c"    , ignoreCase) == 0) return _Centi;
			if (string.Compare(prefixe, "milli", ignoreCase) == 0
			 || string.Compare(prefixe, "m"    , ignoreCase) == 0) return _Milli;
			if (string.Compare(prefixe, "micro", ignoreCase) == 0
			 || string.Compare(prefixe, "µ"    , ignoreCase) == 0) return _Micro;
			if (string.Compare(prefixe, "nano" , ignoreCase) == 0
			 || string.Compare(prefixe, "n"    , ignoreCase) == 0) return _Nano;
			if (string.Compare(prefixe, "pico" , ignoreCase) == 0
			 || string.Compare(prefixe, "p"    , ignoreCase) == 0) return _Pico;
			if (string.Compare(prefixe, "femto", ignoreCase) == 0
			 || string.Compare(prefixe, "f"    , ignoreCase) == 0) return _Femto;
			if (string.Compare(prefixe, "atto" , ignoreCase) == 0
			 || string.Compare(prefixe, "a"    , ignoreCase) == 0) return _Atto;
			if (string.Compare(prefixe, "zepto", ignoreCase) == 0
			 || string.Compare(prefixe, "z"    , ignoreCase) == 0) return _Zepto;
			if (string.Compare(prefixe, "yocto", ignoreCase) == 0
			 || string.Compare(prefixe, "y"    , ignoreCase) == 0) return _Yocto;

			return null;
		}
	}
}
