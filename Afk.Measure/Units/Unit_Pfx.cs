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
		// This file contains all static methods to create prefixe unit

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
        /// <summary>
        /// Gets the requested unit with yotta prefix (10E24)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Yotta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Yotta);
		}

        /// <summary>
        /// Gets the requested unit with zetta prefix (10E21)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Zetta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Zetta);
		}

        /// <summary>
        /// Gets the requested unit with exbi prefix (2E60)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Exbi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Exbi);
		}

        /// <summary>
        /// Gets the requested unit with exa prefix (10E18)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Exa<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Exa);
		}

        /// <summary>
        /// Gets the requested unit with pebi prefix (2E50)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>

        public static PrefixUnit Pebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Pebi);
		}

        /// <summary>
        /// Gets the requested unit with peta prefix (10E15)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Peta<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Peta);
		}

        /// <summary>
        /// Gets the requested unit with tebi prefix (2E40)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Tebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Tebi);
		}

        /// <summary>
        /// Gets the requested unit with tera prefix (10E12)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Tera<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Tera);
		}

        /// <summary>
        /// Gets the requested unit with gibi prefix (2E30)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Gibi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Gibi);
		}

        /// <summary>
        /// Gets the requested unit with giga prefix (10E9)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Giga<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Giga);
		}

        /// <summary>
        /// Gets the requested unit with mebi prefix (2E20)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Mebi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Mebi);
		}

        /// <summary>
        /// Gets the requested unit with mega prefix (10E6)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Mega<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Mega);
		}

        /// <summary>
        /// Gets the requested unit with kibi prefix (2E10)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Kibi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Kibi);
		}

        /// <summary>
        /// Gets the requested unit with kilo prefix (10E3)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Kilo<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Kilo);
		}

        /// <summary>
        /// Gets the requested unit with hecto prefix (10E2)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Hecto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Hecto);
		}

        /// <summary>
        /// Gets the requested unit with deca prefix (10E1)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Deka<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Deka);
		}

        /// <summary>
        /// Gets the requested unit with no prefix (1)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit None<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.None);
		}

        /// <summary>
        /// Gets the requested unit with deci prefix (10E-1)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Deci<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Deci);
		}

        /// <summary>
        /// Gets the requested unit with centi prefix (10E-2)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Centi<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Centi);
		}

        /// <summary>
        /// Gets the requested unit with milli prefix (10E-3)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
        public static PrefixUnit Milli<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Milli);
		}

        /// <summary>
        /// Gets the requested unit with micro prefix (10E-6)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Micro<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Micro);
		}

        /// <summary>
        /// Gets the requested unit with nano prefix (10E-9)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Nano<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Nano);
		}

        /// <summary>
        /// Gets the requested unit with pico prefix (10E-12)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Pico<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Pico);
		}

        /// <summary>
        /// Gets the requested unit with femto prefix (10E-15)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Femto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Femto);
		}

        /// <summary>
        /// Gets the requested unit with atto prefix (10E-18)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Atto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Atto);
		}

        /// <summary>
        /// Gets the requested unit with zepto prefix (10E-21)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Zepto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Zepto);
		}

        /// <summary>
        /// Gets the requested unit with yocto prefix (10E-24)
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>The instance of the unit requested</returns>
		public static PrefixUnit Yocto<TUnit>() where TUnit : MetricBaseUnit, new() {
			return CreateUnit<TUnit>(SIPrefixe.Yocto);
		}
		#endregion
	}
}
