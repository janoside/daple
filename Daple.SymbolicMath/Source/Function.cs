using System;
//using System.Windows.Forms;

using Daple.Expressions.Functions;
using Daple.Expressions.Functions.Specifics;

namespace Daple.Expressions {

	/// <summary>
	/// Summary description for Function.
	/// </summary>
	public abstract class Function : IEvaluatable {

		protected Expression fArgument;

		/// <summary>
		/// The power to which this function is raised.
		/// A null power indicates unity.
		/// </summary>
		protected Expression fPower;

		/// <summary>
		/// The variables contained within the Function.
		/// </summary>
		private VariableCollection fVariables;

		protected string fString;

		public Function(VariableCollection vc, string s) {
			this.fVariables = new VariableCollection();
			this.fString = s;
			this.Analyze(vc);
		}

		public VariableCollection pVariables {
			get {
				return this.fVariables;
			}
		}

		public Expression pArgument {
			get {
				return this.fArgument;
			}
		}

		public Expression pPower {
			get {
				return this.fPower;
			}
		}

		public override string ToString() {
			return this.fString;
		}

		protected virtual void Analyze(VariableCollection vc) {
			string s = this.fString;

			for ( int i = 0; i < s.Length; i++ ) {
				if ( s.Substring(i, 1).Equals("^") && !StringUtil.InsideParentheses(s, i) ) {
					this.fPower = new Expression(s.Substring(i+1,s.Length-i-1));
					s = s.Substring(0,i);
				}
			}
			//	if ( String2.contains(s,"^") ) {
			//		this.myPower = new Expression(s.substring(s.indexOf("^")+1,s.length()));
			//		this.myString = s.substring(0,s.indexOf("^"));
			//	}
			if ( StringUtil.Contains(s, "(") ) {
				int x = s.IndexOf("(");
				this.fArgument = new Expression(s.Substring(x+1,s.Length-x-2));
			} else {
				try {
					Double.Parse(s);
				} catch(System.FormatException) {
					this.fVariables.Add(new Variable(s));
				}
			}
			if ( this.fPower != null ) {
				this.fVariables.AddAll(this.fPower.pVariables);
			}
			if ( this.fArgument != null ) {
				this.fVariables.AddAll(this.fArgument.pVariables);
			}

			// tell the Expression about all of the Variables
			vc.AddAll(this.fVariables);
		}

		public abstract double Evaluate(VariableCollection v);

		public abstract string Substitute(VariableCollection vc);

		public abstract string Differentiate(Variable v);

		public static Function GetFunction(VariableCollection vc, string s) {
			if ( s.StartsWith("sinh") ) {
				return new HyperbolicSineFunction(vc,s);
			} else if ( s.StartsWith("sin") ) {
				return new SineFunction(vc,s);
			} else if ( s.StartsWith("cosh") ) {
				return new HyperbolicCosineFunction(vc,s);
			} else if ( s.StartsWith("cos") ) {
				return new CosineFunction(vc,s);
			} else if ( s.StartsWith("exp") ) {
				return new ExponentialFunction(vc,s);
			} else if ( s.StartsWith("abs") ) {
				return new AbsoluteValueFunction(vc,s);
			} else if ( s.StartsWith("sech") ) {
				return new HyperbolicSecantFunction(vc,s);	
			} else if ( s.StartsWith("sec") ) {
				return new SecantFunction(vc,s);
			} else if ( s.StartsWith("coth") ) {
				return new HyperbolicCotangentFunction(vc,s);	
			} else if ( s.StartsWith("cot") ) {
				return new CotangentFunction(vc,s);
			} else if ( s.StartsWith("csch") ) {
				return new HyperbolicCosecantFunction(vc,s);
			} else if ( s.StartsWith("csc") ) {
				return new CosecantFunction(vc,s);
			} else if ( s.StartsWith("arcsinh") ) {
				return new InverseHyperbolicSineFunction(vc,s);
			} else if ( s.StartsWith("arccosh") ) {
				return new InverseHyperbolicCosineFunction(vc,s);
			} else if ( s.StartsWith("arctanh") ) {
				return new InverseHyperbolicTangentFunction(vc,s);
			} else if ( s.StartsWith("ln") ) {
				return new NaturalLogarithmFunction(vc,s);
			} else if ( s.StartsWith("log") ) {
				return new LogarithmFunction(vc,s);
			} else if ( s.StartsWith("heaviside") ) {
				return new HeavisideFunction(vc,s);
			} else if ( s.StartsWith("tanh") ) {
				return new HyperbolicTangentFunction(vc,s);
			} else if ( s.StartsWith("tan") ) {
				return new TangentFunction(vc,s);
			} else if ( s.StartsWith("null") ) {
				return new NullFunction(vc,s);
			} else if ( s.StartsWith("sqrt") ) {
				return new SquareRootFunction(vc,s);
			} else if ( s.StartsWith("arcsin") ) {
				return new InverseSineFunction(vc,s);
			} else if ( s.StartsWith("arccos") ) {
				return new InverseCosineFunction(vc,s);
			} else if ( s.StartsWith("arctan") ) {
				return new InverseTangentFunction(vc,s);
			} else if ( s.StartsWith("arccsch") ) {
				return new InverseHyperbolicCosecantFunction(vc,s);
			} else if ( s.StartsWith("arcsech") ) {
				return new InverseHyperbolicSecantFunction(vc,s);
			} else if ( s.StartsWith("arccoth") ) {
				return new InverseHyperbolicCotangentFunction(vc,s);
			} else if ( s.StartsWith("sgn") ) {
				return new SignumFunction(vc,s);
			} else if ( s.StartsWith("factorial") ) {
				return new FactorialFunction(vc,s);
			} else if ( s.StartsWith("doublefactorial") ) {
				return new DoubleFactorialFunction(vc,s);
			}
			if ( StringUtil.Contains(s,"^") ) {
				try {
					Double.Parse(s.Substring(0,s.IndexOf("^")));
					return new ConstantFunction(vc,s);
				} catch ( System.FormatException ) {
					return new VariableFunction(vc,s);
				}
			} else {
				try {
					Double.Parse(s);
					return new ConstantFunction(vc,s);
				} catch ( System.FormatException ) {
					return new VariableFunction(vc,s);	
				}
			}
		}
	}
}
