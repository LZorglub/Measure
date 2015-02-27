using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Units.Metric.SI;
using Afk.Measure.Units.Metric;

namespace Afk.Measure.Quantity {
	/// <summary>
	/// Represents a quantity
	/// </summary>
	public partial class Quantity {
		/// <summary>
		/// Gets a quantity from specified <see cref="Unit"/> and <b>value</b>
		/// </summary>
		/// <typeparam name="T">Type of value</typeparam>
		/// <param name="unit"><see cref="Unit"/> of quantity</param>
		/// <param name="value"><b>value</b> of quantity</param>
		/// <returns><see cref="Quantity"/> equivalent to specified <b>unit</b> and <b>value</b></returns>
		private static Quantity<T> CreateQuantity<T>(Unit unit, T value) {
			Quantity<T> qty = Dimension.QuantityFrom<T>(unit.Dimension);
			if (qty == null) qty = new DerivedQuantity<T>();
			qty.Unit = unit;
			qty.Value = value;

			return qty;
		}

		/// <summary>
		/// Gets a quantity specified <see cref="Unit"/> and <b>value</b>
		/// </summary>
		/// <typeparam name="T">Type of value</typeparam>
		/// <param name="unit"><see cref="Unit"/> of quantity</param>
		/// <param name="value"><b>value</b> of quantity</param>
		/// <returns><see cref="Quantity"/> equivalent to specified <b>unit</b> and <b>value</b></returns>
		public static Quantity<T> From<T>(Unit unit, T value) {
			return CreateQuantity<T>(unit, value);
		}

		#region Generic methods
		/// <summary>
		/// Yotta prefix (10E24)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Yotta<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Yotta<TUnit>(), value);
		}

		/// <summary>
		/// Zetta prefix (10E21)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Zetta<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Zetta<TUnit>(), value);
		}

		/// <summary>
		/// Exbi prefix (10E18)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Exbi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Exbi<TUnit>(), value);
		}

		/// <summary>
		/// Exa prefix (10E18)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Exa<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Exa<TUnit>(), value);
		}

		/// <summary>
		/// Pebi prefix (10E15)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Pebi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Pebi<TUnit>(), value);
		}

		/// <summary>
		/// Peta prefix (10E15)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Peta<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Peta<TUnit>(), value);
		}

		/// <summary>
		/// Tebi prefix (10E12)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Tebi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Tebi<TUnit>(), value);
		}

		/// <summary>
		/// Tera prefix (10E12)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Tera<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Tera<TUnit>(), value);
		}

		/// <summary>
		/// Gibi prefix (10E9)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Gibi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Gibi<TUnit>(), value);
		}

		/// <summary>
		/// giga prefix (10E9)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Giga<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Giga<TUnit>(), value);
		}

		/// <summary>
		/// Mebi prefix (10E6)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Mebi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Mebi<TUnit>(), value);
		}

		/// <summary>
		/// Mega prefix (10E6)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Mega<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Mega<TUnit>(), value);
		}

		/// <summary>
		/// Kibi prefix (10E3)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Kibi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Kibi<TUnit>(), value);
		}

		/// <summary>
		/// Kilo prefix (10E3)
		/// </summary>
		/// <param name="value">The amount of quantity</param>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Kilo<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Kilo<TUnit>(), value);
		}

		/// <summary>
		/// Hecto prefix (10E2)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Hecto<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Hecto<TUnit>(), value);
		}

		/// <summary>
		/// Deca prefix (10E1)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Deka<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Deka<TUnit>(), value);
		}

		/// <summary>
		/// None prefix (1)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> None<T, TUnit>(T value) where TUnit : BaseUnit, new() {
			return CreateQuantity<T>(new TUnit(), value);
		}

		/// <summary>
		/// Deci prefix (10E-1)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Deci<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Deci<TUnit>(), value);
		}

		/// <summary>
		/// Centi prefix (10E-2)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Centi<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Centi<TUnit>(), value);
		}

		/// <summary>
		/// Milli prefix (10E-3)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Milli<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Milli<TUnit>(), value);
		}

		/// <summary>
		/// Micro prefix (10E-6)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Micro<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Micro<TUnit>(), value);
		}

		/// <summary>
		/// Nano prefix (10E-9)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Nano<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Nano<TUnit>(), value);
		}

		/// <summary>
		/// Pico prefix (10E-12)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Pico<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Pico<TUnit>(), value);
		}

		/// <summary>
		/// Femto prefix (10E-15)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Femto<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Femto<TUnit>(), value);
		}

		/// <summary>
		/// Atto prefix (10E-18)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Atto<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Atto<TUnit>(), value);
		}

		/// <summary>
		/// Zepto prefix (10E-21)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Zepto<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Zepto<TUnit>(), value);
		}

		/// <summary>
		/// Yocto prefix (10E-24)
		/// </summary>
		/// <typeparam name="T">Type of <b>value</b></typeparam>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<T> Yocto<T, TUnit>(T value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<T>(PrefixUnit.Yocto<TUnit>(), value);
		}
		#endregion

		#region Double quantity
		/// <summary>
		/// Yotta prefix (10E24)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Yotta<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Yotta<TUnit>(), value);
		}

		/// <summary>
		/// Zetta prefix (10E21)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Zetta<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Zetta<TUnit>(), value);
		}

		/// <summary>
		/// Exbi prefix (10E18)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Exbi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Exbi<TUnit>(), value);
		}

		/// <summary>
		/// Exa prefix (10E18)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Exa<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Exa<TUnit>(), value);
		}

		/// <summary>
		/// Pebi prefix (10E15)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Pebi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Pebi<TUnit>(), value);
		}

		/// <summary>
		/// Peta prefix (10E15)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Peta<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Peta<TUnit>(), value);
		}

		/// <summary>
		/// Tebi prefix (10E12)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Tebi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Tebi<TUnit>(), value);
		}

		/// <summary>
		/// Tera prefix (10E12)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Tera<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Tera<TUnit>(), value);
		}

		/// <summary>
		/// Gibi prefix (10E9)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Gibi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Gibi<TUnit>(), value);
		}

		/// <summary>
		/// giga prefix (10E9)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Giga<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Giga<TUnit>(), value);
		}

		/// <summary>
		/// Mebi prefix (10E6)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Mebi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Mebi<TUnit>(), value);
		}

		/// <summary>
		/// Mega prefix (10E6)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Mega<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Mega<TUnit>(), value);
		}

		/// <summary>
		/// Kibi prefix (10E3)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Kibi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Kibi<TUnit>(), value);
		}

		/// <summary>
		/// Kilo prefix (10E3)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Kilo<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Kilo<TUnit>(), value);
		}

		/// <summary>
		/// Hecto prefix (10E2)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Hecto<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Hecto<TUnit>(), value);
		}

		/// <summary>
		/// Deca prefix (10E1)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Deka<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Deka<TUnit>(), value);
		}

		/// <summary>
		/// None prefix (1)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> None<TUnit>(double value) where TUnit : BaseUnit, new() {
			return CreateQuantity<double>(new TUnit(), value);
		}

		/// <summary>
		/// Deci prefix (10E-1)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Deci<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Deci<TUnit>(), value);
		}

		/// <summary>
		/// Centi prefix (10E-2)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Centi<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Centi<TUnit>(), value);
		}

		/// <summary>
		/// Milli prefix (10E-3)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Milli<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Milli<TUnit>(), value);
		}

		/// <summary>
		/// Micro prefix (10E-6)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Micro<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Micro<TUnit>(), value);
		}

		/// <summary>
		/// Nano prefix (10E-9)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Nano<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Nano<TUnit>(), value);
		}

		/// <summary>
		/// Pico prefix (10E-12)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Pico<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Pico<TUnit>(), value);
		}

		/// <summary>
		/// Femto prefix (10E-15)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Femto<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Femto<TUnit>(), value);
		}

		/// <summary>
		/// Atto prefix (10E-18)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Atto<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Atto<TUnit>(), value);
		}

		/// <summary>
		/// Zepto prefix (10E-21)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Zepto<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Zepto<TUnit>(), value);
		}

		/// <summary>
		/// Yocto prefix (10E-24)
		/// </summary>
		/// <typeparam name="TUnit"><see cref="MetricBaseUnit"/></typeparam>
		/// <param name="value">The amount of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the specified <b>value</b></returns>
		public static Quantity<double> Yocto<TUnit>(double value) where TUnit : MetricBaseUnit, new() {
			return CreateQuantity<double>(PrefixUnit.Yocto<TUnit>(), value);
		}
		#endregion
	}
}
