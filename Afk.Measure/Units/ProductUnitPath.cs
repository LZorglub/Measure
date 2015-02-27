using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afk.Measure.Units {
	/// <summary>
	/// Represents the unit path of succesive multiply/divide operation
	/// </summary>
	class ProductUnitPath {
		private List<int> _unitsPath;

		/// <summary>
		/// Initialize a new instance of <see cref="UnitPath"/>
		/// </summary>
		public ProductUnitPath() {
			_unitsPath = new List<int>();
		}

		/// <summary>
		/// Gets the path of <see cref="Unit"/>
		/// </summary>
		public List<int> Path {
			get { return _unitsPath; }
		}
	}
}
