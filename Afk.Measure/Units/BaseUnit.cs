using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents a <see cref="Unit"/> can be multiply/divide
	/// </summary>
	/// <remarks>
	/// It's not possible to multiply/divide units with a prefix, the result of prefix would be inconsistent
	/// Mega * Centi = 10^4 (not a prefix)
	/// </remarks>
	public abstract class BaseUnit : Unit {
		/// <summary>
		/// Base unit equivalent to dimensionless unit
		/// </summary>
		internal sealed class UnitOne : BaseUnit {
			/// <summary>
			/// Initialize a new instance of <see cref="UnitOne"/>
			/// </summary>
			public UnitOne()
				: base(Dimension.None) {
			}
		}

		/// <summary>
		/// Initialize a new instance of <see cref="BaseUnit"/>
		/// </summary>
		public BaseUnit() : base() {
		}

		/// <summary>
		/// Initialize a new instance of <see cref="BaseUnit"/>
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of unit</param>
		public BaseUnit(Dimension dimension)
			: base(dimension) {
		}

		/// <summary>
		/// Gets the dimensionless unit
		/// </summary>
		public static BaseUnit UNITONE = new UnitOne();

		/// <summary>
		/// Gets the product of two <see cref="BaseUnit"/>
		/// </summary>
		/// <param name="unitA">First operand <see cref="BaseUnit"/></param>
		/// <param name="unitB">Second operand <see cref="BaseUnit"/></param>
		/// <returns><see cref="BaseUnit"/> equivalent to the product of <b>unitA</b> by <b>unitB</b></returns>
		public static BaseUnit operator *(BaseUnit unitA, BaseUnit unitB) {
			return ProductUnitBuilder.GetProductInstance(unitA, unitB);
		}

		/// <summary>
		/// Gets the division of two <see cref="BaseUnit"/>
		/// </summary>
		/// <param name="unitA">First operand <see cref="BaseUnit"/></param>
		/// <param name="unitB">Second operand <see cref="BaseUnit"/></param>
		/// <returns><see cref="BaseUnit"/> equivalent to the division of <b>unitA</b> by <b>unitB</b></returns>
		public static BaseUnit operator /(BaseUnit unitA, BaseUnit unitB) {
			return ProductUnitBuilder.GetProductInstance(unitA, (BaseUnit)unitB.Inverse());
		}
	}
}
