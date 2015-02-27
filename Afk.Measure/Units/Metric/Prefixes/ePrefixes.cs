using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units.Metric.Prefixes {
	/// <summary>
	/// Specifies the decimal and binary prefixes
	/// </summary>
	public enum ePrefixes {
		Yotta = 24, // Y
		Zetta = 21, // Z
		Exbi = 60,  // Ei
		Exa = 18,  // E
		Pebi = 50, // Pi
		Peta = 15, // P
		Tebi = 40, // Ti
		Tera = 12, // T
		Gibi = 30, // Gi
		Giga = 9,  // G
		Mebi = 20, // Mi
		Mega = 6, // M
		Kibi = 10, // ki 2^10 = 1024
		Kilo = 3, // k
		Hecto = 2, // h
		Deka = 1, // da
		None = 0,
		Deci = -1, // d
		Centi = -2, // c
		Milli = -3, // m
		Micro = -6, // µ
		Nano = -9, // n
		Pico = -12, // p
		Femto = -15, // f
		Atto = -18, // a
		Zepto = -21, // z
		Yocto = -24 // y
	}
}
