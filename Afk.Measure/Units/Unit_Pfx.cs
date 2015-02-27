using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.Metric.Prefixes;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents an unit
	/// </summary>
	public partial class Unit {
		// This file contains all static method to create prefixe unit

        /// <summary>
        /// Creates a <see cref="PrefixUnit"/>
        /// </summary>
        /// <typeparam name="TUnit"></typeparam>
        /// <param name="siPrefixe"></param>
        /// <returns></returns>
		private static PrefixUnit CreateUnit<TUnit>(SIPrefixe siPrefixe) where TUnit : MetricBaseUnit, new() {
			PrefixUnit unit = new PrefixUnit(siPrefixe, new TUnit());
			return unit;
		}

		#region Prefixe Unit
		public static PrefixUnit Yotta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Yotta);
		}
		public static PrefixUnit Zetta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Zetta);
		}
		public static PrefixUnit Exbi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Exbi);
		}
		public static PrefixUnit Exa<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Exa);
		}
		public static PrefixUnit Pebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Pebi);
		}
		public static PrefixUnit Peta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Peta);
		}
		public static PrefixUnit Tebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Tebi);
		}
		public static PrefixUnit Tera<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Tera);
		}
		public static PrefixUnit Gibi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Gibi);
		}
		public static PrefixUnit Giga<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Giga);
		}
		public static PrefixUnit Mebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Mebi);
		}
		public static PrefixUnit Mega<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Mega);
		}
		public static PrefixUnit Kibi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Kibi);
		}
		public static PrefixUnit Kilo<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Kilo);
		}
		public static PrefixUnit Hecto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Hecto);
		}
		public static PrefixUnit Deka<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Deka);
		}
		public static PrefixUnit None<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.None);
		}
		public static PrefixUnit Deci<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Deci);
		}
		public static PrefixUnit Centi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Centi);
		}
		public static PrefixUnit Milli<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Milli);
		}
		public static PrefixUnit Micro<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Micro);
		}
		public static PrefixUnit Nano<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Nano);
		}
		public static PrefixUnit Pico<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Pico);
		}
		public static PrefixUnit Femto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Femto);
		}
		public static PrefixUnit Atto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Atto);
		}
		public static PrefixUnit Zepto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Zepto);
		}
		public static PrefixUnit Yocto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Yocto);
		}
		#endregion
	}
}
