using System;
//using System.Windows.Forms;

namespace Daple.Expressions {

	/// <summary>
	/// The top-level Class for mathematical-expression evaluation.
	/// As defined here, an Expression consists of one or more
	/// Quotients that are stored based on their sign (+ or -) in
	/// the Expression.  Each Quotient then contains one or more
	/// Functions that are multiplied or divided.  An Expression, being
	/// the top-level object here, stores all of the variables that are
	/// present.  As an Expression is broken down into Quotients and
	/// Functions, the VariableCollection stored by the Expression is
	/// passed down and each Quotient and Function contributes to the
	/// variable list as it is analyzed.
	/// </summary>
	public class Expression : IEvaluatable {

		private static readonly Variable Pi = new Variable("pi", MathUtil.Pi);
		private static readonly Variable E = new Variable("e", MathUtil.Exp(1));

		private static readonly VariableCollection Constants = new VariableCollection(Expression.Pi,
																					  Expression.E);

		/// <summary>
		/// The positive Quotients in the Expression.
		/// </summary>
		private QuotientCollection fPositiveQuotients;

		/// <summary>
		/// The negative Quotients in the Expression.
		/// </summary>
		private QuotientCollection fNegativeQuotients;

		/// <summary>
		/// The collection of all of the Variables in the Expression.
		/// </summary>
		private VariableCollection fVariables;

		/// <summary>
		/// The string representation of the Expression.
		/// </summary>
		private string fString;

		/// <summary>
		/// Whether or not the Expression uses the mathematical constants
		/// when being evaluated.
		/// </summary>
		private bool fUseConstants;

		/// <summary>
		/// Constructs an Expression based on the specified string.  The
		/// Expression is broken down into Quotients by the Analyze method
		/// and then each Quotient is further divided into Functions.  The
		/// Simplify method is then used to combine any constants and to do
		/// a general clean-up.
		/// </summary>
		/// <param name="s">The string that represents the Expression.</param>
		public Expression(string s) {
			this.fString = StringUtil.RemoveSpaces(s);
			this.fUseConstants = true;

			this.fVariables = new VariableCollection();
			this.fPositiveQuotients = new QuotientCollection();
			this.fNegativeQuotients = new QuotientCollection();

			this.Analyze(this.fString);
			this.Simplify();
		}

		public string pString {
			get {
				return this.fString;
			}
		}

		public bool Contains(Variable v) {
			return this.fVariables.Contains(v);
		}

		/// <summary>
		/// Simplifies the Expression by asking each of the Quotients in
		/// the Expression to simplify itself.
		/// </summary>
		public void Simplify() {
			foreach ( Quotient q in this.fPositiveQuotients ) {
				q.Simplify();
			}
			foreach ( Quotient q in this.fNegativeQuotients ) {
				q.Simplify();
			}
		}

		public string Differentiate(Variable v) {
			string s = "";

			foreach ( Quotient q in this.fPositiveQuotients ) {
				s += q.Differentiate(v);
			}
			foreach ( Quotient q in this.fNegativeQuotients ) {
				s += q.Differentiate(v);
			}

			return s;
		}

		public QuotientCollection pPositiveQuotients {
			get {
				return this.fPositiveQuotients;
			}
		}

		public QuotientCollection pNegativeQuotients {
			get {
				return this.fNegativeQuotients;
			}
		}

		/// <summary>
		/// Evaluates the Expression using the specified VariableCollection.
		/// Also ensures that all of the mathematical constants (Pi,E) are 
		/// represented as such during evaluation.
		/// </summary>
		/// <param name="vc"></param>
		/// <returns></returns>
		public double Evaluate(VariableCollection vc) {
			if ( this.fUseConstants ) {
				foreach ( Variable v in Expression.Constants ) {
					vc.Add(v);
				}
			}

			double sum = 0;
			foreach ( Quotient q in this.fPositiveQuotients ) {
				sum += q.Evaluate(vc);
			}
			foreach ( Quotient q in this.fNegativeQuotients ) {
				sum -= q.Evaluate(vc);
			}
			return sum;
		}

		public double Evaluate(double x) {
			try {
				VariableCollection vc = new VariableCollection();
				foreach ( Variable v in Expression.Constants ) {
					vc.Add(v);
				}
				for ( int i = 0; i < this.fVariables.Count; i++ ) {
					if ( !vc.Contains(this.fVariables[i]) ) {
						vc.Add(new Variable(this.fVariables[i].pString,x));
					}
				}
				return this.Evaluate(vc);

			} catch ( System.Exception ) {
				return 0;
			}
		}

		public double Evaluate(double x, double y) {
			try {
				bool b = true;
				VariableCollection vc = new VariableCollection();
				foreach ( Variable v in Expression.Constants ) {
					vc.Add(v);
				}
				foreach ( Variable v in this.fVariables ) {
					if ( !vc.Contains(v) ) {
						if ( b ) {
							vc.Add(new Variable(v.pString,x));
							b = false;
						} else {
							vc.Add(new Variable(v.pString,y));
						}
					}
				}
			//	vc.Add(new Variable(this.fVariables[0].pString,x));
			//	vc.Add(new Variable(this.fVariables[1].pString,y));
				return this.Evaluate(vc);

			} catch ( System.ArgumentOutOfRangeException ) {
				//Console.WriteLine("hereeeee");
				return 0;
			}
		}

		public VariableCollection pVariables {
			get {
				return this.fVariables;
			}
		}

		public string Substitute(VariableCollection vc) {
			string s = "";
			foreach ( Quotient q in this.fPositiveQuotients ) {
				s += "+" + q.Substitute(vc);
			}
			foreach ( Quotient q in this.fNegativeQuotients ) {
				s += "-" + q.Substitute(vc);
			}
			if ( s.StartsWith("+") ) {
				s = s.Substring(1);	
			}
			return s;
		}

		private void AddQuotient(string s, bool isSubtracted) {
			if ( isSubtracted ) {
				this.fNegativeQuotients.Add(new Quotient(this.fVariables,s));	
			} else {
				this.fPositiveQuotients.Add(new Quotient(this.fVariables,s));
			}
		}

		/// <summary>
		/// Principle method for Expression analysis.  Breaks the Expression
		/// down into a set of Quotients, each known to be positively or
		/// negatively signed based on the character before them in the string
		/// ("+" or "-") (or lack of such a character - the implicit "+").
		/// </summary>
		/// <param name="s">The string to analyze.</param>
		private void Analyze(string s) {
			this.fNegativeQuotients = new QuotientCollection();
			this.fPositiveQuotients = new QuotientCollection();
			this.fVariables = new VariableCollection();

			bool multipleFunctions = false;
			bool isSubtracted = false;

			while ( s.Length > 0 ) {
				multipleFunctions = false;
				for ( int i = 0; i < s.Length; i++ ) {
					if ( !StringUtil.InsideParentheses(s, i) ) {
						if ( s.Substring(i,1).Equals("+") ) {
							multipleFunctions = true;
							if ( !s.Substring(0,i).Equals("") ) {
								this.AddQuotient(s.Substring(0,i),isSubtracted);
								s = s.Substring(i);
							} else {
								s = s.Substring(i+1);	
							}
							isSubtracted = false;
							break;
						} else if ( s.Substring(i,1).Equals("-") ) {
							multipleFunctions = true;
							if ( !s.Substring(0,i).Equals("") ) {
								this.AddQuotient(s.Substring(0,i),isSubtracted);
								s = s.Substring(i);
							} else {
								s = s.Substring(i+1);	
							}
							isSubtracted = true;
							break;
						}
					}
				}
				if ( !multipleFunctions ) {
					this.AddQuotient(s,isSubtracted);
					s = "";
					break;
				}
			}
		}

		public override string ToString() {
			return this.fString;
		}
	}
}
