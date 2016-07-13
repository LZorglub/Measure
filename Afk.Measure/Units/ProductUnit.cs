using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents the product of two <see cref="BaseUnit"/>
	/// </summary>
	public class ProductUnit : BaseUnit {
		//private ExpandedUnit _expandedUnit;
		private ProductUnitPath _unitPath;

		/// <summary>
		/// Gets the unit path of the current instance
		/// </summary>
		internal ProductUnitPath UnitPath {
			get { return _unitPath; }
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductUnit"/>
		/// </summary>
		ProductUnit()
			: base() {
			_unitPath = new ProductUnitPath();
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductUnit"/>
		/// </summary>
		/// <param name="expandedUnit">A <see cref="ExpandedUnit"/> which contains all elementary unit.</param>
		/// <param name="context">Path of the product unit.</param>
		internal ProductUnit(ExpandedUnit expandedUnit, ProductUnitPath context)
			: this() {
			Initialise(expandedUnit);
			_unitPath = context;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductUnit"/>
		/// </summary>
		/// <param name="unitA">Firs operand unit of product</param>
		/// <param name="unitB">Second operand unit of product</param>
		public ProductUnit(BaseUnit unitA, BaseUnit unitB)
			: this() {
			Initialise(unitA.GetExpandedUnits() + unitB.GetExpandedUnits());
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductUnit"/>
		/// </summary>
		/// <param name="expandedUnits">A <see cref="ExpandedUnit"/> which contains all elementary unit</param>
		private void Initialise(ExpandedUnit expandedUnits) {
			this._dimension = expandedUnits.Dimension;
			this._baseConverter = expandedUnits.BaseConverter;
			this._symbol = expandedUnits.Symbol;

            this.Exponent = expandedUnits.Exponent;
			this._expandedUnit = expandedUnits;
		}

		/// <summary>
		/// Gets the unit symbol
		/// </summary>
		public override string Symbol {
			get {
				return this._symbol;
			}
		}

		/// <summary>
		/// Gets the expanded units
		/// </summary>
		/// <returns>A <see cref="ExpandedUnit"/> which contain all elementary unit</returns>
		internal override ExpandedUnit GetExpandedUnits() {
			return _expandedUnit;
		}

		/// <summary>
		/// Gets the inverted unit
		/// </summary>
		/// <returns><see cref="BaseUnit"/> inverted</returns>
		public override Unit Inverse() {
			ProductUnit pu = (ProductUnit)base.Inverse();
			//pu._expandedUnit = pu._expandedUnit.Inverse();
			pu._symbol = pu._expandedUnit.Symbol;
			return pu;
		}

		/// <summary>
		/// Gets the unit raise to power <b>pow</b>
		/// </summary>
		/// <param name="pow"></param>
		/// <returns></returns>
		public override Unit Power(int pow) {
			ProductUnit pu = (ProductUnit)base.Power(pow);
			pu._symbol = pu._expandedUnit.Symbol;
			return pu;
		}
	}
}
