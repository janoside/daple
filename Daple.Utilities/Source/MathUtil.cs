
namespace Daple {

	/// <summary>
	/// Summary description for MathUtil.
	/// </summary>
	public class MathUtil {

		public const double Pi = System.Math.PI;

		public const double E = System.Math.E;

		#region Trigonometric Functions

		/// <summary>
		/// Returns the sine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The sine.</returns>
		public static double Sin(double x) {
			return (float)System.Math.Sin(x);
		}

		/// <summary>
		/// Returns the cosine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The cosine.</returns>
		public static double Cos(double x) {
			return (float)System.Math.Cos(x);
		}

		/// <summary>
		/// Returns the tangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The tangent.</returns>
		public static double Tan(double x) {
			return (float)System.Math.Tan(x);
		}

		/// <summary>
		/// Returns the cosecant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The cosecant.</returns>
		public static double Csc(double x) {
			return 1.0f / MathUtil.Sin(x);
		}

		/// <summary>
		/// Returns the secant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The secant.</returns>
		public static double Sec(double x) {
			return 1.0f / MathUtil.Cos(x);
		}

		/// <summary>
		/// Returns the cotangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The cotangent.</returns>
		public static double Cot(double x) {
			return 1.0f / MathUtil.Tan(x);
		}

		#endregion
		
		#region Inverse Trigonometric Functions
		
		/// <summary>
		/// Returns the inverse sine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse sine.</returns>
		public static double ArcSin(double x) {
			return System.Math.Asin(x);
		}

		/// <summary>
		/// Returns the inverse cosine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse cosine.</returns>
		public static double ArcCos(double x) {
			return System.Math.Acos(x);
		}
        
		/// <summary>
		/// Returns the inverse tangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse tangent.</returns>
		public static double ArcTan(double x) {
			return System.Math.Atan(x);
		}

		#endregion
		
		#region Hyperbolic Trigonometric Functions

		/// <summary>
		/// Returns the hyperbolic sine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic sine.</returns>
		public static double Sinh(double x) {
			return System.Math.Sinh(x);
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic cosine.</returns>
		public static double Cosh(double x) {
			return System.Math.Cosh(x);
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic tangent.</returns>
		public static double Tanh(double x) {
			return System.Math.Tanh(x);
		}

		/// <summary>
		/// Returns the hyperbolic cosecant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic cosecant.</returns>
		public static double Csch(double x) {
			return 1.0f / MathUtil.Sinh(x);
		}

		/// <summary>
		/// Returns the hyperbolic secant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic secant.</returns>
		public static double Sech(double x) {
			return 1.0f / MathUtil.Cosh(x);
		}

		/// <summary>
		/// Returns the hyperbolic cotangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The hyperbolic cotangent.</returns>
		public static double Coth(double x) {
			return 1.0f / MathUtil.Tanh(x);
		}

		#endregion

		#region Inverse Hyperbolic Trigonometric Functions

		/// <summary>
		/// Returns the inverse hyperbolic sine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic sine.</returns>
		public static double ArcSinh(double x) {
			return MathUtil.Ln(x + MathUtil.Sqrt(x * x + 1));
		}
		
		/// <summary>
		/// Returns the inverse hyperbolic cosine of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic cosine.</returns>
		public static double ArcCosh(double x) {
			return MathUtil.Ln(x + MathUtil.Sqrt(x - 1) * MathUtil.Sqrt(x + 1));
		}
		
		/// <summary>
		/// Returns the inverse hyperbolic tangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic tangent.</returns>
		public static double ArcTanh(double x) {
			return MathUtil.Ln(x + 1) / 2.0 - MathUtil.Ln(1 - x) / 2.0;
		}

		/// <summary>
		/// Returns the inverse hyperbolic cosecant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic cosecant.</returns>
		public static double ArcCsch(double x) {
			return MathUtil.Ln(1.0 / x + MathUtil.Sqrt(1 + 1.0 / (x * x)));
		}

		/// <summary>
		/// Returns the inverse hyperbolic secant of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic secant.</returns>
		public static double ArcSech(double x) {
			return MathUtil.Ln(1.0 / x + MathUtil.Sqrt(1.0 / x - 1) * MathUtil.Sqrt(1.0 / x + 1));
		}

		/// <summary>
		/// Returns the inverse hyperbolic cotangent of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The inverse hyperbolic cotangent.</returns>
		public static double ArcCoth(double x) {
			return (MathUtil.Ln(x + 1) / 2.0 - MathUtil.Ln(x - 1) / 2.0);	
		}

		#endregion

		/// <summary>
		/// Returns the absolute value of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The absolute value.</returns>
		public static double Abs(double x) {
			return System.Math.Abs(x);
		}

		public static double Max(double x, double y) {
			if ( x > y ) {
				return x;
			} else {
				return y;
			}
		}

		public static double ToDegrees(double radians) {
			return radians * 180.0 / MathUtil.Pi;
		}

		public static double ToRadians(double degrees) {
			return degrees * MathUtil.Pi / 180.0;
		}
	
		public static double Max(params double [] d) {
			double max = d[0];
			for ( int i = 1; i < d.Length; i++ ) {
				if ( d[i] > max ) {
					max = d[i];
				}
			}
			return max;
		}

		public static double Pow(double x, double pow) {
			return System.Math.Pow(x,pow);
		}

		public static double Exp(double x) {
			return System.Math.Exp(x);
		}

		public static bool Equals(double x, double y) {
			return (x-y) == 0;
		}

		public static int Factorial(int x) {
			return (x == 1) ? x : x*Factorial(x-1);
		}

		public static int Fibonacci(int x) {
			return (x < 3) ? x : Fibonacci(x-2) + Fibonacci(x-1);
		}

		public static bool IsPrime(int n) {
			if ( (n % 2) == 0 ) {
				return false;
			}

			int sqrt = (int)MathUtil.Sqrt(n);
			for ( int i = 3; i <= sqrt; i += 2) {
				if ( (n % i) == 0 ) {
					return false;
				}
			}
			return true;
		}

		public static bool IsBetween(double test, double min, double max) {
			return (test > min) && (test < max);
		}

		public static int NextPrime(int n) {
			do {
				n++;
			} while ( !MathUtil.IsPrime(n) );

			return n;
		}

		public static double DoubleFactorial(double x) {
			return (x < 3) ? x : x*DoubleFactorial(x-2);
		}

		public static double Gamma(double x) {
			return 0;
		}

		/// <summary>
		/// Returns the square root of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The square root.</returns>
		public static double Sqrt(double x) {
			return System.Math.Sqrt(x);
		}

		/// <summary>
		/// Returns the natural logarithm of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The natural logarithm.</returns>
		public static double Ln(double x) {
			return System.Math.Log(x);
		}

		/// <summary>
		/// Returns the base-10 logarithm of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The base-10 logarithm.</returns>
		public static double Log(double x) {
			return MathUtil.Log(x, 10.0);
		}

		/// <summary>
		/// Returns the base-specified logarithm of the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <param name="newBase">The logarithm base.</param>
		/// <returns>The base-specified logarithm.</returns>
		public static double Log(double x, double newBase) {
			return System.Math.Log(x,newBase);
		}

		/// <summary>
		/// Returns the Signum function evaluated at the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The Signum function value.</returns>
		public static double Sgn(double x) {
			if ( x > 0 ) {
				return 1;	
			}
			return -1;
		}

		/// <summary>
		/// Returns the Heaviside function evaluated at the given value.
		/// </summary>
		/// <param name="x">The argument.</param>
		/// <returns>The Heaviside function value.</returns>
		public static float Heaviside(double x) {
			if ( x < 0 ) {
				return 0;
			} else {
				return 1;	
			}
		}

		/// <summary>
		/// Returns the partial factorial which is the factor of all of the integers
		/// less than or equal to the larger value, greater than the smaller value.
		/// Useful for calculating the quotients of large factorials since the
		/// individual large factorials may not be able to be stored.
		/// </summary>
		/// <param name="large">The larger value.</param>
		/// <param name="small">The smaller value.</param>
		/// <returns>The partial factorial.</returns>
		public static int PartialFactorial(int large, int small) {
		
			int currentValue = large;
			int factorial = 1;
		
			while ( currentValue > small ) {
				factorial *= currentValue;
				currentValue--;
			}
		
			return factorial;
		}
	}
}
