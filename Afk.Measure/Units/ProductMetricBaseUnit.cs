using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Afk.Measure.Units.Metric.SI;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents the product of two <see cref="MetricBaseUnit"/>
	/// </summary>
	public class ProductMetricBaseUnit : Measure.Units.MetricBaseUnit, IMetricUnitOffset {

		//private ExpandedUnit _expandedUnit;
		private ProductUnitPath _unitPath;

		/// <summary>
		/// Gets the unit path of the current instance
		/// </summary>
		internal ProductUnitPath UnitPath {
			get { return _unitPath; }
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductMetricBaseUnit"/>
		/// </summary>
		ProductMetricBaseUnit() : base() {
			_prefixe = Measure.Units.Metric.Prefixes.SIPrefixe.None;
			_unitPath = new ProductUnitPath();
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductMetricBaseUnit"/>
		/// </summary>
		/// <param name="expandedUnit">A <see cref="ExpandedUnit"/> which contains all elementary unit.</param>
		/// <param name="context">Path of the product unit.</param>
		internal ProductMetricBaseUnit(ExpandedUnit expandedUnit, ProductUnitPath context)
			: this() {
			Initialise(expandedUnit);
			_unitPath = context;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductMetricBaseUnit"/>
		/// </summary>
		/// <param name="unitA">Single <see cref="MetricBaseUnit"/> of product</param>
		public ProductMetricBaseUnit(MetricBaseUnit unitA)
			: this() {
			Initialise(unitA.GetExpandedUnits());
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductMetricBaseUnit"/>
		/// </summary>
		/// <param name="unitA">Firs operand unit of product</param>
		/// <param name="unitB">Second operand unit of product</param>
		public ProductMetricBaseUnit(MetricBaseUnit unitA, MetricBaseUnit unitB) : this() {
			Initialise(unitA.GetExpandedUnits() + unitB.GetExpandedUnits());
		}

		/// <summary>
		/// Initialize a new instance of <see cref="ProductMetricBaseUnit"/>
		/// </summary>
		/// <param name="expandedUnits">A <see cref="ExpandedUnit"/> which contains all elementary unit</param>
		private void Initialise(ExpandedUnit expandedUnits) {
			this._dimension = expandedUnits.Dimension;
			this._baseConverter = expandedUnits.BaseConverter;
			this._symbol = expandedUnits.Symbol;

            this.Exponent = expandedUnits.Exponent;
			this._expandedUnit = expandedUnits;

			MetricBaseUnit mbu = expandedUnits.ElementAt(0).Key as Measure.Units.MetricBaseUnit;
			if (mbu != null) {
				IMetricUnitOffset mOffset = mbu as IMetricUnitOffset;
				if (mOffset != null) {
					_prefixe = mOffset.Prefixe;
					_metricSymbol = mOffset.MetricSymbol + this._symbol.Substring(mbu.Symbol.Length);
				}
			}
			else
				throw new Exception("Bad unit");
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
			ProductMetricBaseUnit pu = (ProductMetricBaseUnit)base.Inverse();
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
			ProductMetricBaseUnit pu = (ProductMetricBaseUnit)base.Power(pow);
			pu._symbol = pu._expandedUnit.Symbol;
			return pu;
		}

		#region IMetricUnitOffset Membres

		private Measure.Units.Metric.Prefixes.SIPrefixe _prefixe;
		/// <summary>
		/// Gets the unit prefixe
		/// </summary>
		public Measure.Units.Metric.Prefixes.SIPrefixe Prefixe {
			get { return _prefixe; }
		}

		private string _metricSymbol;
		/// <summary>
		/// Gets the metric symbol
		/// </summary>
		public string MetricSymbol {
			get { return (_metricSymbol == null) ? Symbol : _metricSymbol; }
		}

		#endregion
	}
}
