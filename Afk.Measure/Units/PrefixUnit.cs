﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units.Metric.SI;
using Afk.Measure.Units.Metric.Prefixes;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents a unit with a prefixe.
	/// </summary>
	public sealed class PrefixUnit : Unit {

		private SIPrefixe _prefixe;
		private Converter.UnitConverter _prefixConverter;

		private MetricBaseUnit _baseUnit;

		/// <summary>
		/// Gets the prefixe unit.
		/// </summary>
		public SIPrefixe Prefixe {
			get { return _prefixe; }
		}

		/// <summary>
		/// Gets the metric base unit of the current instance
		/// </summary>
		public MetricBaseUnit BaseUnit {
			get { return _baseUnit; }
		}

		/// <summary>
		/// Gets the converter of the prefixe.
		/// </summary>
		public Converter.UnitConverter PrefixConverter {
			get { return _prefixConverter; }
		}

        /// <summary>
        /// Initialize a new instance of <see cref="PrefixUnit"/>
        /// </summary>
        /// <param name="baseUnit"><see cref="MetricBaseUnit"/></param>
        public PrefixUnit(MetricBaseUnit baseUnit)
			: base(baseUnit.Dimension) {
			_prefixe = SIPrefixe.None;
			_prefixConverter = Converter.UnitConverter.IDENTITY;
			_baseUnit = baseUnit;

			this._baseConverter = baseUnit.BaseConverter;
            this.Exponent = baseUnit.Exponent;
			this._symbol = baseUnit.BaseSymbol; 
		}

        /// <summary>
        /// Initialize a new instance of <see cref="PrefixUnit"/>
        /// </summary>
        /// <param name="prefixe">Prefixe of unit</param>
        /// <param name="baseUnit"><see cref="MetricBaseUnit"/></param>
        public PrefixUnit(SIPrefixe prefixe, MetricBaseUnit baseUnit)
			: this(baseUnit) {
            this.Initialize(prefixe, this.BaseUnit.Exponent);
		}

        /// <summary>
        /// Initialize a new instance of <see cref="PrefixUnit"/>
        /// </summary>
        /// <param name="prefixe">Tuple of prefix unit, compose by the prefix and exponent applied to this prefix</param>
        /// <param name="baseUnit"><see cref="MetricBaseUnit"/></param>
        public PrefixUnit(Tuple<SIPrefixe, int> prefixe, MetricBaseUnit baseUnit)
            : this(baseUnit)
        {
            this.Initialize(prefixe.Item1, prefixe.Item2);
        }

        /// <summary>
        /// Initialize the <see cref="PrefixUnit"/>
        /// </summary>
        /// <param name="prefixe">Prefixe of unit</param>
        /// <param name="exponent">Exponent to apply to prefixe</param>
        private void Initialize(SIPrefixe prefixe, int exponent)
        {
            this._prefixe = prefixe;

            // Détermination du converter de préfixe
            Measure.Converter.UnitConverter converter = Measure.Converter.UnitConverter.IDENTITY;

            // Pour minimiser les problèmes d'arrondis si le préfixe est négatif on utilise
            // un converter Rational et s'il est positif on utilise un Multiply

            int expp = Convert.ToInt32(prefixe.Exponent);
            // Si l'unité de base possède déjà un facteur (kg) il faut le prendre en compte
            if (_baseUnit is IMetricUnitOffset)
            {
                Measure.Units.Metric.Prefixes.SIPrefixe pOffset = ((IMetricUnitOffset)_baseUnit).Prefixe;
                if (pOffset.Base == prefixe.Base)
                {
                    expp -= Convert.ToInt32(pOffset.Exponent);
                    if (expp < 0)
                    {
                        converter = new Measure.Converter.RationalConverter(1, (long)Math.Pow(prefixe.Base, -expp));
                    }
                    else if (expp > 0)
                    {
                        converter = new Measure.Converter.MultiplyConverter((long)Math.Pow(prefixe.Base, expp));
                    }
                }
                else
                {
                    // Les préfixes ne sont pas de même bases il faut utiliser le facteur (Kig)
                    converter = new Measure.Converter.MultiplyConverter(Math.Pow(prefixe.Base, expp) / Math.Pow(pOffset.Base, Convert.ToInt32(pOffset.Exponent)));
                }
            }
            else
            {
                if (expp < 0)
                {
                    converter = new Measure.Converter.RationalConverter(1, (long)Math.Pow(prefixe.Base, -expp));
                }
                else if (expp > 0)
                {
                    converter = new Measure.Converter.MultiplyConverter((long)Math.Pow(prefixe.Base, expp));
                }
            }

            // On calcule le converter à utiliser en fonction de l'exposant imposé (celui de l'unité ou un autre)
            // Exemple km2 : le converter calculé juste avant = *1000, différent de identity alors on l'éléve au carré puis
            // on change le baseConverter en concaténant le converter du préfixe obtenu
            // Exemple kWh2 : Equivalent à k(m2.s-3.h)2, l'exposant imposé doit être 2 et pas celui de la première unité
            if (converter != Measure.Converter.UnitConverter.IDENTITY)
            {
                if (exponent < 0)
                {
                    converter = converter.Inverse();
                }

                // _prefixConverter == IDENTITY before this loop
                for (int exp = 0; exp < Math.Abs(exponent); exp++)
                {
                    this._prefixConverter = this._prefixConverter.Concat(converter);
                }

                // Applied the prefix converter to the base converter
                this._baseConverter = this._prefixConverter.Concat(this._baseConverter);
            }
        }

        /// <summary>
        /// Gets the symbol of unit
        /// </summary>
        public override string Symbol {
			get {
				// Si l'unité est un produit il ne faut pas prendre en compte son exposant qui est
				// déjà exprimé dans le MetricSymbol
				if (_baseUnit is ProductMetricBaseUnit)
					return _prefixe.Symbol + ((ProductMetricBaseUnit)_baseUnit).MetricSymbol;
				// Si l'unité de base posséde déjà un préfixe il faut prendre son unité sans préfixe
				else if (_baseUnit is IMetricUnitOffset)
					return _prefixe.Symbol + ((IMetricUnitOffset)_baseUnit).MetricSymbol + ((_baseUnit.Exponent!=1)?_baseUnit.Exponent.ToString():string.Empty);

				return _prefixe.Symbol + base.Symbol;
			}
		}

		/// <summary>
		/// Gets the reverse unit
		/// </summary>
		/// <returns><see cref="Unit"/> inverted</returns>
		public override Unit Inverse() {
			// Le prefixe ne bouge pas puisqu'on interverti l'exposant et le converter de base
			// 1/km = km-1
			Unit u = base.Inverse();
			((PrefixUnit)u)._baseUnit = (MetricBaseUnit)_baseUnit.Inverse();
			return u;
		}

        /// <summary>
        /// Returns a specified unit raised to the specified power.
        /// </summary>
        /// <param name="pow">An int-precision floating-point number that specifies a power.</param>
        /// <returns></returns>
		public override Unit Power(int pow) {
			MetricBaseUnit u = (MetricBaseUnit)_baseUnit.Power(pow);
			return new PrefixUnit(this.Prefixe, u);
		}

		/// <summary>
		/// Gets the <see cref="ExpandedUnit"/> of current instance
		/// </summary>
		/// <returns></returns>
		internal override ExpandedUnit GetExpandedUnits() {
			return this._baseUnit.GetExpandedUnits();
		}
	}

	/// <summary>
	/// Support for specific unit with prefixe (like kg)
	/// </summary>
	public interface IMetricUnitOffset {
		/// <summary>
		/// Gets the base prefix of unit (Kilo)
		/// </summary>
		SIPrefixe Prefixe { get; }

		/// <summary>
		/// Gets the metric symbol of unit (g)
		/// </summary>
		string MetricSymbol { get; }
	}
}
