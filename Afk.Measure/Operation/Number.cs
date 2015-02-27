using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Afk.Measure.Operation {
	/// <summary>
	/// Provide operation on generic type
	/// </summary>
	/// <typeparam name="T">Type of first operand</typeparam>
	/// <typeparam name="V">Type of second operand</typeparam>
	internal class Number<T, V> {
		private T value;

		private static readonly Func<T, V, T> Add = CompileDelegate<T>(Expression.Add);
		private static readonly Func<T, V, T> Sub = CompileDelegate<T>(Expression.Subtract);
		private static readonly Func<T, V, T> Mul = CompileDelegate<T>(Expression.Multiply);
		private static readonly Func<T, V, T> Div = CompileDelegate<T>(Expression.Divide);
		//private static readonly Func<T, V, T> Mod = CompileDelegate<T>(Expression.Modulo);
		private static readonly Func<T, V, bool> GreaterThan = CompileDelegate<bool>(Expression.GreaterThan);
		private static readonly Func<T, V, bool> GreaterThanOrEqual = CompileDelegate<bool>(Expression.GreaterThanOrEqual);
		private static readonly Func<T, V, bool> LessThan = CompileDelegate<bool>(Expression.LessThan);
		private static readonly Func<T, V, bool> LessThanOrEqual = CompileDelegate<bool>(Expression.LessThanOrEqual);
		private static readonly Func<T, V, bool> Equal = CompileDelegate<bool>(Expression.Equal);
		private static readonly Func<V, T> ConvertVtoT = CompileDelegateConvert<V, T>();
		private static readonly Func<T, V> ConvertTtoV = CompileDelegateConvert<T, V>();

		/// <summary>
		/// Compile operation delegate which return a <b>W</b> type.
		/// </summary>
		/// <param name="operation">Specify the operation to compile</param>
		/// <returns>Operation function; null if error</returns>
		private static Func<T, V, W> CompileDelegate<W>(Func<Expression, Expression, Expression> operation) {
			try {
				//create two inprameters
				ParameterExpression leftExp = Expression.Parameter(typeof(T), "left");
				ParameterExpression rightExp = Expression.Parameter(typeof(V), "right");

				//create the body from the delegate that we passed in
				Expression body = operation(leftExp, rightExp);

				//create a lambda that takes two args of T and returns T
				LambdaExpression lambda = Expression.Lambda(typeof(Func<T, V, W>), body, leftExp, rightExp);

				//compile the lambda to a delegate that takes two args of T and returns T
				Func<T, V, W> compiled = (Func<T, V, W>)lambda.Compile();
				return compiled;
			}
			catch {
				//type T does not support math operations
				return null;
			}
		}

		/// <summary>
		/// Compile convertion operation 
		/// </summary>
		/// <typeparam name="U">Type to convert</typeparam>
		/// <typeparam name="W">Result type</typeparam>
		/// <returns>Operation function; null if error</returns>
		private static Func<U, W> CompileDelegateConvert<U, W>() {
			try {
				//create two inprameters
				ParameterExpression expression = Expression.Parameter(typeof(U), "left");

				//create the body from the delegate that we passed in
				Expression body = Expression.Convert(expression, typeof(W));

				//create a lambda that takes two args of T and returns T
				LambdaExpression lambda = Expression.Lambda(typeof(Func<U, W>), body, expression);

				//compile the lambda to a delegate that takes two args of T and returns T
				Func<U, W> compiled = (Func<U, W>)lambda.Compile();
				return compiled;
			}
			catch {
				//type T does not support math operations
			}
			return null;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="Number"/>
		/// </summary>
		/// <param name="value"><b>Value</b> of current instance</param>
		internal Number(T value) {
			this.value = value;
		}

		/// <summary>
		/// Gets the <b>value</b> of instance
		/// </summary>
		public T Value {
			get { return value; }
		}

		/// <summary>
		/// Implicit cast operator of <b>T</b> in <b>Number<T,V>/></b>
		/// </summary>
		/// <param name="value"><b>Value</b> to cast</param>
		/// <returns>A <see cref="Number"/> representation of the value</returns>
		public static implicit operator Number<T, V>(T value) {
			return new Number<T, V>(value);
		}

		/// <summary>
		/// Implicit cast operator of <see cref="Number"/> to <b>T</b> type.
		/// </summary>
		/// <param name="value"><see cref="Number"/> to cast</param>
		/// <returns>A <b>T</b> representation of <see cref="Number"/></returns>
		public static implicit operator T(Number<T, V> value) {
			return value.value;
		}

		/// <summary>
		/// Convert value to found a valid operation to apply.
		/// </summary>
		/// <param name="operationT">Delegate for operation of type T</param>
		/// <param name="operationV">Deletgate of operation of type V</param>
		/// <param name="a"><see cref="Number"/> in first operand operation</param>
		/// <param name="b"><b>value</b> in second operand operation</param>
		/// <returns><see cref="Number"/> which represents the result of operation between <b>a</b> and <b>b</b></returns>
		private static Number<T, V> ConvertOp(Func<T, T, T> operationT, Func<V, V, V> operationV, Number<T, V> a, V b) {
			if (typeof(V) == typeof(double)) {
				// Try to preserve precision, firt convert T in double, second do operation, last convert double to T
				T t = ConvertVtoT(operationV(ConvertTtoV(a.Value), b));
				return new Number<T, V>(t);
			}
			else {
				T n = ConvertVtoT(b);
				return new Number<T, V>(operationT(a.Value, n));
			}
		}

		/// <summary>
		/// Add a specified <b>Number</b> and a <b>V</b> type.
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type</param>
		/// <returns>A <see cref="Number"/> whose value is the sum of the values of a and b.</returns>
		public static Number<T, V> operator +(Number<T, V> a, V b) {
			if (Add == null) {
				return ConvertOp(Number<T, T>.Add, Number<V, V>.Add, a, b);
			}
			
			return new Number<T, V>(Add(a.value, b));
		}

		/// <summary>
		/// Substracts a specified <b>Number</b> and a <b>V</b> type.
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type</param>
		/// <returns>A <see cref="Number"/> whose value is the result of a minus the value of b.</returns>
		public static Number<T, V> operator -(Number<T, V> a, V b) {
			if (Sub == null) {
				return ConvertOp(Number<T, T>.Sub, Number<V, V>.Sub, a, b);
			}

			return new Number<T, V>(Sub(a.value, b));
		}

		/// <summary>
		/// Divide a specified <b>Number</b> and a <b>V</b> type.
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type</param>
		/// <returns>A <see cref="Number"/> whose value is the division of the values of a and b.</returns>
		public static Number<T, V> operator /(Number<T, V> a, V b) {
			if (Div == null) {
				return ConvertOp(Number<T, T>.Div, Number<V, V>.Div, a, b);
			}

			return new Number<T, V>(Div(a.value, b));
		}

		/// <summary>
		/// Multiply a specified <b>Number</b> and a <b>V</b> type.
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type</param>
		/// <returns>A <see cref="Number"/> whose value is the multiplication of the values of a and b.</returns>
		public static Number<T, V> operator *(Number<T, V> a, V b) {
			if (Mul == null) {
				return ConvertOp(Number<T, T>.Mul, Number<V, V>.Mul, a, b);
			}

			return new Number<T, V>(Mul(a.value, b));
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is less than a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is less than the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator <(Number<T, V> a, V b) {
			return LessThan(a.value, b);
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is greater than a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is greater than the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator >(Number<T, V> a, V b) {
			return GreaterThan(a.value, b);
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is less or equal than a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is less or equal than the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator <=(Number<T, V> a, V b) {
			return LessThanOrEqual(a.value, b);
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is greater or equal than a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is greater or equal than the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator >=(Number<T, V> a, V b) {
			return GreaterThanOrEqual(a.value, b);
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is equal to a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is equal to the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator ==(Number<T, V> a, V b) {
			if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null))
				return Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null);

			return Equal(a.value, b);
		}

		/// <summary>
		/// Indicates wether a specified <see cref="Number"/> is not equal to a <b>V</b> type
		/// </summary>
		/// <param name="a">A <see cref="Number"/></param>
		/// <param name="b">A <b>V</b> type.</param>
		/// <returns>true if the value of <b>a</b> is not equal to the value of <b>b</b>; otherwise, false.</returns>
		public static bool operator !=(Number<T, V> a, V b) {
			if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null))
				return !(Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null));

			return !Equal(a.value, b);
		}

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object
		/// </summary>
		/// <param name="value">The object to compare to this instance</param>
		/// <returns>true if <b>value</b> is an instance of <see cref="Number"/> and equals the value of this instance; otherwise, false.</returns>
		public override bool Equals(object value) {
			return base.Equals(value);
		}

		/// <summary>
		/// Returns the hash code for this instance
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode() {
			return base.GetHashCode();
		}

		/*
		public static bool IsNumeric {
			get {
				//ugly hack..
				//requires an exception in the delegate generator 
				//in order to determine if the type supports math operations
				if (Add == null)
					return false;
				else
					return true;
			}
		}
		 * */
	}
}
