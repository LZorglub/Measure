using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using Afk.Measure.Quantity;

namespace Afk.Measure {

	/// <summary>
	/// Specifies the dimension of units
	/// </summary>
	public enum eDimension {
		Length = 0,
		Time = 1,
		Temperature = 2,
		Mass = 3,
		Current = 4,
		Substance = 5,
		Luminosity = 6,
		Currency = 7,
	}

	/// <summary>
	/// Dimension 
	/// </summary>
	/// <remarks>
	/// 0 length meter
	/// 1 time second
	/// 2 temperature kelvin
	/// 3 mass kilogram
	/// 4 current ampere
	/// 5 substance mole
	/// 6 luminosity candela
	/// 7 currency
	/// 
	/// units = { "m", "s", "K", "kg", "A", "mol", "cd", "€" };
	/// </remarks>
	public sealed class Dimension : IEquatable<Dimension> {
		int[] _dimensions;

		/// <summary>
		/// Dimension None is dimensionless
		/// </summary>
		public static Dimension None;

		/// <summary>
		/// Symbol of each dimension
		/// </summary>
		private static string[] units = new string[] { "m", "s", "K", "kg", "A", "mol", "cd", "€" };

		private static Dictionary<Dimension, Type> dimensionToQuantity;
		private static object _synchronizedObject;

		/// <summary>
		/// Specifies if a generic class is equal to specify type
		/// </summary>
		/// <param name="generic">Type of generic class</param>
		/// <param name="toCheck">Implemented type to verified</param>
		/// <returns>True if generic class is the right specify type</returns>
		private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck) {
			while (toCheck != null && toCheck != typeof(object)) {
				var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
				if (generic == cur) { return true; }
				toCheck = toCheck.BaseType;
			}
			return false;
		}

		/// <summary>
		/// Initialize static members of <see cref="Dimension"/>
		/// </summary>
		static Dimension() {
			None = new Dimension();
			_synchronizedObject = new object();
		}

        /// <summary>
        /// Initialize a new instance of <see cref="Dimension"/> with specify dimension
        /// </summary>
        /// <param name="length"></param>
        /// <param name="time"></param>
        /// <param name="temperature"></param>
        /// <param name="mass"></param>
        /// <param name="current"></param>
        /// <param name="substance"></param>
        /// <param name="luminosity"></param>
        /// <param name="currency"></param>
        public Dimension(int length = 0, int time = 0, int temperature = 0,
            int mass = 0, int current = 0, int substance = 0, int luminosity = 0, int currency = 0)
        {
            _dimensions = new int[8] { length, time, temperature, mass, current, substance, luminosity, currency };
        }

		/// <summary>
		/// Get exponent of specify dimension
		/// </summary>
		/// <param name="index"><see cref="eDimension"/></param>
		/// <returns>Exponent of specify dimension</returns>
		public int this[eDimension index] {
			get { return _dimensions[(int)index]; }
		}

		/// <summary>
		/// Get exponent of specify index
		/// </summary>
		/// <param name="index">Index of dimension</param>
		/// <returns>Exponent of specify index dimension</returns>
		/// <remarks>See <see cref="eDimension"/> for dimension index</remarks>
		public int this[int index] {
			get { return _dimensions[index]; }
		}

		/// <summary>
		/// Get a readonly array of dimension
		/// </summary>
		/// <returns>Int array which represent the dimension </returns>
		public ReadOnlyCollection<int> ToArray() {
			return new List<int>(_dimensions).AsReadOnly();
		}

		/// <summary>
		/// Get the sum of two dimensions
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>Sum of the dimensions</returns>
		public static Dimension operator +(Dimension left, Dimension right) {
			Dimension d = new Dimension();
			d._dimensions = left._dimensions.Select((e, i) => e + right._dimensions[i]).ToArray();
			return d;
		}

		/// <summary>
		/// Get the subtraction of two dimensions
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>Difference of the dimensions</returns>
		public static Dimension operator -(Dimension left, Dimension right) {
			Dimension d = new Dimension();
			d._dimensions = left._dimensions.Select((e, i) => e - right._dimensions[i]).ToArray();
			return d;
		}

		/// <summary>
		/// Get the multiplication of dimensions by integer
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>Multiplication of dimension by integer</returns>
		public static Dimension operator *(Dimension left, int right) {
			Dimension d = new Dimension();
			d._dimensions = left._dimensions.Select((e, i) => e * right).ToArray();
			return d;
		}

		/// <summary>
		/// Get the multiplication of integer by dimensions 
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>Multiplication of dimension by integer</returns>
		public static Dimension operator *(int left, Dimension right) {
			Dimension d = new Dimension();
			d._dimensions = right._dimensions.Select((e, i) => e * left).ToArray();
			return d;
		}

		/// <summary>
		/// Returns a value indicating whether the two specified dimension are equals
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>true if <b>left</b> is equals to <b>right</b>; otherwise, false.</returns>
		public static bool operator ==(Dimension left, Dimension right) {
			if (Object.Equals(left, null) || Object.Equals(right, null))
				return false;

			return left.Equals(right);
		}

		/// <summary>
		/// Returns a value indicating whether the two specified dimension are not equals
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>true if <b>left</b> is not equals to <b>right</b>; otherwise, false.</returns>
		public static bool operator !=(Dimension left, Dimension right) {
			if (Object.Equals(left, null) || Object.Equals(right, null))
				return true;

			return !left.Equals(right);
		}

		/// <summary>
		/// Get the dimension inversed
		/// </summary>
		/// <returns>Inversed dimension</returns>
		public Dimension Inverse() {
			Dimension d = new Dimension();
			d._dimensions = this._dimensions.Select((e, i) => e * -1).ToArray();
			return d;
		}

		/// <summary>
		/// Returns a value indicating whether this instance cross a specified object
		/// </summary>
		/// <param name="dimension">The <see cref="Dimension"/> to compare to this instance</param>
		/// <returns>true if <b>dimension</b> cross the value of this instance; otherwise, false.</returns>
		public bool Cross(Dimension dimension) {
			Dimension d = new Dimension();
			d._dimensions = _dimensions.Select((e, i) => (e != 0 && dimension._dimensions[i] != 0) ? 1 : 0).ToArray();
			return (!d.Equals(Dimension.None));
		}

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object
		/// </summary>
		/// <param name="value">The object to compare to this instance</param>
		/// <returns>true if <b>value</b> is an instance of <see cref="Dimension"/> and equals the value of this instance; otherwise, false.</returns>
		public override bool Equals(object value) {
			if (value is Dimension) {
				bool result = (_dimensions[0] == ((Dimension)value)._dimensions[0]);
				for (int i = 1; result && i < _dimensions.Length; i++) {
					result &= (_dimensions[i] == ((Dimension)value)._dimensions[i]);
				}
				return result;
			}
			return base.Equals(value);
		}

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object
        /// </summary>
        /// <param name="other">The object to compare to this instance</param>
        /// <returns>true if <b>value</b> equals the value of this instance; otherwise, false.</returns>
        public bool Equals(Dimension other)
        {
            return this.Equals((object)other);
        }

		/// <summary>
		/// Returns the hash code for this instance
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}

		/// <summary>
		/// Converts the value of the current <see cref="Dimension"/> object to its equivalent string representation
		/// </summary>
		/// <returns>A string representation of the value of the current <see cref="Dimension"/> object</returns>
		public override string ToString() {
			StringBuilder builder = new StringBuilder();
			for (int index = 0; index < _dimensions.Length; index++)
				builder.Append(units[index] + _dimensions[index]);
			return builder.ToString();
		}

		/// <summary>
		/// Converts the value of the current <see cref="Dimension"/> object to its equivalent short string representation
		/// </summary>
		/// <returns>A short string representation of the value of the current <see cref="Dimension"/> object</returns>
		public string ToShortString() {
			StringBuilder builder = new StringBuilder();
			for (int index = 0; index < _dimensions.Length; index++)
				if (_dimensions[index] != 0)
					builder.Append(units[index] + _dimensions[index]);
			string shortString = builder.ToString();
			if (string.IsNullOrEmpty(shortString))
				return "DimensionLess";
			return shortString;
		}

		/// <summary>
		/// Get the type of quantity equal to specified dimension
		/// </summary>
		/// <param name="dimension"><see cref="Dimension"/> of unit</param>
		/// <returns><see cref="Type"/> of quantity equivalent to specified dimension</returns>
		private static Type QuantityTypeFrom(Dimension dimension) {
			lock (_synchronizedObject) {
				if (dimensionToQuantity == null) {
					dimensionToQuantity = new Dictionary<Dimension, Type>();

					// Search all quantity in current assembly, not DerivedQuantity
					IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().
						Where(e => IsSubclassOfRawGeneric(typeof(Measure.Quantity.Quantity<>), e) && e != typeof(DerivedQuantity<>));
					foreach (Type tp in types) {
						if (!tp.IsAbstract) {
							// Create a quantity reference to obtain the unit and dimension
							if (tp.IsGenericType) {
								try {
									Quantity<object> qty = (Quantity<object>)Activator.CreateInstance(tp.MakeGenericType(typeof(object)));

									if (qty.Unit != null) {
										dimensionToQuantity.Add(qty.Unit.Dimension, tp);
									}
								}
								catch {
									// Don't disturbe if generic class has more than one type parameter
								}
							}
						}
					}
				}
			}

			if (dimensionToQuantity.ContainsKey(dimension))
				return dimensionToQuantity[dimension];

			return null;
		}

		/// <summary>
		/// Gets the default quantity of specified quantity
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dimension"><see cref="Dimension"/> of quantity</param>
		/// <returns>A <see cref="Quantity"/> equivalent to the <b>dimension</b></returns>
		public static Quantity<T> QuantityFrom<T>(Dimension dimension) {
			Type tp = QuantityTypeFrom(dimension);

			if (tp == null) return null;

			tp = tp.MakeGenericType(typeof(T));
			object qty = Activator.CreateInstance(tp);
			return (Quantity<T>)qty;
		}
    }
}
