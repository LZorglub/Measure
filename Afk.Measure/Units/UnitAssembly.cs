using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Afk.Measure.Units
{
    /// <summary>
    /// Provides list of unit from a dedicated assembly
    /// </summary>
    class UnitAssembly
    {
        internal struct HashUnit
        {
            public int Id;
            public Type UnitType;
        }

        private Dictionary<Dimension, List<HashUnit>> _dimensionToUnits;
        private List<Unit> _wellKnownUnits;

        /// <summary>
        /// Initialize a new instace of <see cref="UnitAssembly"/>
        /// </summary>
        /// <param name="assembly"></param>
        public UnitAssembly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            AssemblyFullName = assembly.FullName;

            this.LoadAssembly(assembly);
        }

        /// <summary>
        /// Loads <see cref="Unit"/> contains in the assembly
        /// </summary>
        /// <param name="assembly"></param>
        private void LoadAssembly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));

#if NETSTANDARD
            IEnumerable<TypeInfo> types = assembly.DefinedTypes.
                Where(e => !e.IsAbstract && e.IsSubclassOf(typeof(Unit)) && e != typeof(ProductMetricBaseUnit).GetTypeInfo() && e != typeof(ProductUnit).GetTypeInfo() && e != typeof(PrefixUnit).GetTypeInfo());

            // Select new instance of Unit with a right symbol
            IEnumerable<Unit> unites = types.Select(e => (Unit)Activator.CreateInstance(e.AsType())).Where(e => !string.IsNullOrEmpty(e.Symbol));
#else
            IEnumerable<Type> types = assembly.GetTypes().
                Where(e => !e.IsAbstract && e.IsSubclassOf(typeof(Unit)) && e != typeof(ProductMetricBaseUnit) && e != typeof(ProductUnit) && e != typeof(PrefixUnit));

            // Select new instance of Unit with a right symbol
            IEnumerable<Unit> unites = types.Select(e => (Unit)Activator.CreateInstance(e)).Where(e => !string.IsNullOrEmpty(e.Symbol));
#endif

            _wellKnownUnits = new List<Unit>();
            _dimensionToUnits = new Dictionary<Dimension, List<HashUnit>>();

            // Only unit with exponent 1 are selected.
            _wellKnownUnits.AddRange(unites.Where(e => e.Exponent == 1));

            // Dictionary of units by dimension contain only dimension different from dimensionless
            foreach (Unit u in unites)
            {
                if (!u.Dimension.Equals(Dimension.None))
                {
                    HashUnit hu = new HashUnit();
                    hu.Id = u.GetUICode();
                    hu.UnitType = u.GetType();

                    if (!_dimensionToUnits.ContainsKey(u.Dimension))
                        _dimensionToUnits.Add(u.Dimension, new List<HashUnit>());
                    _dimensionToUnits[u.Dimension].Add(hu);
                }
            }
        }

        /// <summary>
        /// Gets the assembly full name
        /// </summary>
        public string AssemblyFullName { get; private set; }

        /// <summary>
        /// Gets all the units known in the assembly
        /// </summary>
        public Unit[] WellKnownUnits
        {
            get
            {
                return _wellKnownUnits.ToArray();
            }
        }

        /// <summary>
        /// Gets units from the specified <see cref="Dimension"/>
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public IEnumerable<HashUnit> GetUnitsFrom(Dimension dimension)
        {
            if (dimension == null) throw new ArgumentNullException(nameof(dimension));
            if (_dimensionToUnits.ContainsKey(dimension))
            {
                return _dimensionToUnits[dimension];
            }
            return null;
        }
    }
}
