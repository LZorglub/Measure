﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.Metric;
using Afk.Measure.Units.Metric.Prefixes;
using static Afk.Measure.Units.UnitAssembly;

namespace Afk.Measure.Units {

	/// <summary>
	/// Provide the method to get the product of two <see cref="BaseUnit"/>
	/// </summary>
	/// <remarks>
	/// In a derived unit formed by division, the use of a prefix symbol (or a prefix name) in both the
	/// numerator and the denominator can cause confusion. Thus, for example, 10 kV/mm is acceptable, but
	/// 10 MV/m is often considered preferable because it contains only one prefix symbol and it is in the
	/// numerator.
	/// In a derived unit formed by multiplication, the use of more than one prefix symbol (or more than one
	/// prefix name) can also cause confusion. Thus, for example, 10 MV · ms is acceptable, but 10 kV · s is often
	/// considered preferable.
	/// Note: Such considerations usually do not apply if the derived unit involves the kilogram. For example,
	/// 0.13 mmol/g is not considered preferable to 0.13 mol/kg.
	/// </remarks>
	class ProductUnitBuilder {

		public static readonly char[] SEPARATORS = new char[]{ (char)183, '.' };

		/// <summary>
		/// Get the product of two <see cref="BaseUnit"/>
		/// </summary>
		/// <param name="unitA">First operand</param>
		/// <param name="unitB">Second operand</param>
		/// <returns><see cref="BaseUnit"/> equivalent to the product of <b>unitA</b> and <b>unitB</b></returns>
		public static BaseUnit GetProductInstance(BaseUnit unitA, BaseUnit unitB) {
			if (unitA == BaseUnit.UNITONE) return unitB;
			if (unitB == BaseUnit.UNITONE) return unitA;

			ExpandedUnit expandedUnit = unitA.GetExpandedUnits() + unitB.GetExpandedUnits();

			// Filter the dimensionless
			if (expandedUnit.Dimension.Equals(Dimension.None))
				return BaseUnit.UNITONE;

			ProductUnitPath newPath = new ProductUnitPath();

			#region Path of product
			// Try to found an unit in the path
			ProductUnitPath contextA = GetContext(unitA);
			if (contextA != null) {
				newPath.Path.AddRange(contextA.Path.Except(newPath.Path));
				newPath.Path.Add(unitA.GetUICode());
			}
			ProductUnitPath contextB = GetContext(unitB);
			if (contextB != null) {
				newPath.Path.AddRange(contextB.Path.Except(newPath.Path));
				newPath.Path.Add(unitB.GetUICode());
			}

			if (newPath.Path.Count > 0) {
				// Retrieve all unit in the dimension
				IEnumerable<HashUnit> hUnit = Unit.GetUnitsListFromDimension(expandedUnit.Dimension);

				if (hUnit != null) {
					foreach (HashUnit hU in hUnit) {
						// If a unit can be found we select this unit
						if (newPath.Path.Contains(hU.Id)) {
							BaseUnit u = (BaseUnit)Activator.CreateInstance(hU.UnitType);
							ProductUnitPath contextU = GetContext(u);
							if (contextU != null) {
								contextU.Path.AddRange(newPath.Path.Except(contextU.Path));
							}
							return u;
						}
					}
				}
			}
			#endregion

            // Override the symbol if units dimensions dont have intersection
            string overrideSymbol = null;
            if (!unitA.Dimension.Cross(unitB.Dimension))
            {
                overrideSymbol = $"{unitA.Symbol}{SEPARATORS[0]}{unitB.Symbol}";
            }

			// Choice of the right product class
			if (expandedUnit.ElementAt(0).Key is Measure.Units.MetricBaseUnit) {
				return new ProductMetricBaseUnit(expandedUnit, newPath, overrideSymbol);
			}
			else
				return new ProductUnit(expandedUnit, newPath);
		}

        /// <summary>
		/// Get the product of two <see cref="PrefixUnit"/>
		/// </summary>
		/// <param name="unitA">First operand</param>
		/// <param name="unitB">Second operand</param>
		/// <returns><see cref="BaseUnit"/> equivalent to the product of <b>unitA</b> and <b>unitB</b></returns>
		public static Unit GetProductInstance(PrefixUnit unitA, PrefixUnit unitB)
        {
            // Authorize product only if the unit dimension are different
            if (unitA.Dimension.Cross(unitB.Dimension)) throw new InvalidOperationException($"Unable to multiply {unitA.Symbol} by {unitB.Symbol}");

            ExpandedUnit expandedUnit = unitA.GetExpandedUnits() + unitB.GetExpandedUnits();

            // Override the symbol like units dimensions dont have intersection
            string overrideSymbol = $"{unitA.BaseSymbol}{SEPARATORS[0]}{unitB.Symbol}";
            // Override the converter : unitA without prefix converter * unitB converter
            var unitConverter = unitA.BaseUnit.BaseConverter.Concat(unitB.BaseConverter);
            return new PrefixUnit(new Tuple<SIPrefixe, int>(unitA.Prefixe, unitA.Exponent), new ProductMetricBaseUnit(expandedUnit, new ProductUnitPath(), overrideSymbol, unitConverter));
        }

        /// <summary>
        /// Gets the path of a product unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private static ProductUnitPath GetContext(BaseUnit unit) {
			if (unit is ProductUnit) {
				return ((ProductUnit)unit).UnitPath;
			}
			else if (unit is ProductMetricBaseUnit) {
				return ((ProductMetricBaseUnit)unit).UnitPath;
			}
			return null;
		}

	}
}
