using Afk.Measure.Converter;
using Afk.Measure.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure
{
    public class CurrencyConverters
    {
        /// <summary>
        /// Gets the converter for specified unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public UnitConverter this[string unit]
        {
            get { return null; }
            set { }
        }
    }

    public class CurrencyContext : IDisposable
    {
        /// <summary>
        /// Represents an exchange rate for unit to euro
        /// </summary>
        private class CurrencyExchangeRate
        {
            /// <summary>
            /// Initialize a new instance of <see cref="CurrencyExchangeRate"/>
            /// </summary>
            /// <param name="unit"></param>
            /// <param name="converter"></param>
            public CurrencyExchangeRate(Unit unit, UnitConverter converter)
            {
                if (unit == null) throw new ArgumentNullException(nameof(unit));
                if (converter == null) throw new ArgumentNullException(nameof(converter));

                this.Unit = unit;
                this.Converter = converter;
            }

            /// <summary>
            /// Gets the unit to convert
            /// </summary>
            public Unit Unit { get; private set; }
            /// <summary>
            /// Gets the <see cref="UnitConverter"/> use to converts unit
            /// </summary>
            public UnitConverter Converter { get; internal set; }
        }

        /// <summary>
        /// Current context for session (TLS)
        /// </summary>
        [ThreadStatic]
        internal static CurrencyContext Current;

        private List<CurrencyExchangeRate> converters;

        /// <summary>
        /// Initialize a new context for currency change
        /// </summary>
        public CurrencyContext()
        {
            if (Current != null)
                throw new InvalidOperationException("Can not enqueue currency context");

            this.converters = new List<CurrencyExchangeRate>();
            Current = this;
        }

        /// <summary>
        /// Dispose the context
        /// </summary>
        public void Dispose()
        {
            lock (converters)
            {
                converters.Clear();
            }
            Current = null;
        }

        /// <summary>
        /// Adds an euro converter for <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="converter"></param>
        public void AddOrReplaceConverter(string unit, double converter)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            AddOrReplaceConverter(Unit.Parse(unit), new MultiplyConverter(converter));
        }

        /// <summary>
        /// Adds an euro converter for <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="converter"></param>
        public void AddOrReplaceConverter(Unit unit, double converter)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            AddOrReplaceConverter(unit, new MultiplyConverter(converter));
        }


        /// <summary>
        /// Adds an euro converter for <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="converter"></param>
        public void AddOrReplaceConverter(string unit, UnitConverter converter)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            AddOrReplaceConverter(Unit.Parse(unit), converter);
        }

        /// <summary>
        /// Adds an euro converter for <see cref="Unit"/>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="converter"></param>
        public void AddOrReplaceConverter(Unit unit, UnitConverter converter)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            if (converter == null) throw new ArgumentNullException(nameof(converter));

            Dimension currency = new Dimension(0, 0, 0, 0, 0, 0, 0, 1);
            if (unit.Dimension != currency) throw new ArgumentException(string.Format("Unit {0} is not a currency", unit.ToString()));

            lock (this.converters)
            {
                var cv = this.converters.FirstOrDefault(e => e.Unit.GetUICode() == unit.GetUICode());
                if (cv != null)
                {
                    cv.Converter = converter;
                }
                else
                {
                    converters.Add(new CurrencyExchangeRate(unit, converter));
                }
            }
        }

        /// <summary>
        /// Gets the converter for specified unit in current context
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static UnitConverter GetConverter(Unit unit)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));

            var context = CurrencyContext.Current;
            if (context == null)
            {
                throw new InvalidOperationException("No context for the current conversion");
            }
            else
            {
                lock (context.converters)
                {
                    return context.converters.FirstOrDefault(e => e.Unit.GetUICode() == unit.GetUICode())?.Converter;
                }
            }
        }
    }
}
