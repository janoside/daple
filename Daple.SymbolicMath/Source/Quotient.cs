//using System.Windows.Forms;

using Daple.Expressions.Functions;

namespace Daple.Expressions {

	/// <summary>
	/// Class that represents one or more 'Functions' multiplied
	/// together.
	/// </summary>
	public class Quotient : IEvaluatable, IVariableStorer {

		private FunctionCollection fMultipliedFunctions;

		private FunctionCollection fDividedFunctions;

		private VariableCollection fVariables;

		private string fString;

		public Quotient(VariableCollection vc, string s) {
			this.fVariables = new VariableCollection();
			this.fString = s;
			this.Analyze(vc,this.fString);
		}

		public FunctionCollection pMultipliedFunctions {
			get {
				return this.fMultipliedFunctions;
			}
		}

		public FunctionCollection pDividedFunctions {
			get {
				return this.fDividedFunctions;
			}
		}

		public VariableCollection pVariables {
			get {
				return this.fVariables;
			}
		}

		public void Merge(Quotient q) {
		}

		public string Substitute(VariableCollection vc) {
			string s = "1";
			
			foreach ( Function f in this.fMultipliedFunctions ) {
				s += "*" + f.Substitute(vc);
			}
			foreach ( Function f in this.fDividedFunctions ) {
				s += "/" + f.Substitute(vc);
			}

			if ( s.StartsWith("1*") ) {
				s = s.Substring(2);
			}

			return s;
		}

		public string Differentiate(Variable v) {
			string s = "";

			for ( int i = 0; i < this.fMultipliedFunctions.Count; i++ ) {
				s += this.fMultipliedFunctions[i].Differentiate(v);
				for ( int j = 0; j < this.fMultipliedFunctions.Count; j++ ) {
					s += "*";
					s += this.fMultipliedFunctions[j].ToString();
				}
			}

			return s;
		}

		public override string ToString() {
			return this.fString;
		}

		public VariableCollection GetVariables() {
			return this.fVariables;
		}

		public void Simplify() {
			double q = 1;
			bool needsNewMultiplier = false;
			System.Collections.ArrayList a = new System.Collections.ArrayList();
			int x = 0;
			foreach ( Function f in this.fMultipliedFunctions ) {
				if ( f is ConstantFunction ) {
					if ( ((ConstantFunction)f).pIsConstant ) {
						needsNewMultiplier = true;
						a.Add(x);
						q *= f.Evaluate(new VariableCollection());
					}
				}
				x++;
			}
			x = 0;
			foreach ( int xx in a ) {
				this.fMultipliedFunctions.RemoveAt(xx-x);
				x++;
			}
			a.Clear();
			x = 0;
			foreach ( Function f in this.fDividedFunctions ) {
				if ( f is ConstantFunction ) {
					if ( ((ConstantFunction)f).pIsConstant ) {
						needsNewMultiplier = true;
						a.Add(x);
						q /= f.Evaluate(new VariableCollection());
					}
				}
				x++;
			}
			x = 0;
			foreach ( int xx in a ) {
				this.fDividedFunctions.RemoveAt(xx-x);
				x++;
			}

			if ( needsNewMultiplier ) {
				this.fMultipliedFunctions.Add(new ConstantFunction(q.ToString()));
			}
		}

		public double Evaluate(VariableCollection vc) {
			double quotient = 1;

			foreach ( Function f in this.fMultipliedFunctions ) {
				quotient *= f.Evaluate(vc);
			}
			foreach ( Function f in this.fDividedFunctions ) {
				quotient /= f.Evaluate(vc);
			}

			return quotient;
		}

		private void AddQuotient(VariableCollection vc, string s, bool isDivided) {
			Function function;
			if ( !s.StartsWith("(") ) {
				function = Function.GetFunction(vc,s);
				if ( isDivided ) {
					this.fDividedFunctions.Add(function);
				} else {
					this.fMultipliedFunctions.Add(function);
				}
			} else {
				function = Function.GetFunction(vc,"null"+s);
				if ( isDivided ) {
					this.fDividedFunctions.Add(function);
				} else {
					this.fMultipliedFunctions.Add(function);
				}
			}
			this.fVariables.AddAll(function.pVariables);
		}

		private void Analyze(VariableCollection vc, string s) {
			this.fMultipliedFunctions = new FunctionCollection();
			this.fDividedFunctions = new FunctionCollection();

			bool multipleFunctions = false;
			bool isDivided = false;

			while ( s.Length > 0 ) {
				multipleFunctions = false;
				for ( int i = 0; i < s.Length; i++ ) {
					if ( !StringUtil.InsideParentheses(s,i) ) {
						if ( s.Substring(i,1).Equals("*") ) {
							multipleFunctions = true;
							this.AddQuotient(vc,s.Substring(0,i),isDivided);
							s = s.Substring(i+1);
							isDivided = false;
							break;
						} else if ( s.Substring(i,1).Equals("/") ) {
							multipleFunctions = true;
							this.AddQuotient(vc,s.Substring(0,i),isDivided);
							s = s.Substring(i+1);
							isDivided = true;
							break;	
						}
					}	
				}
				if ( !multipleFunctions ) {
					this.AddQuotient(vc,s,isDivided);
					s = "";
					break;
				}
			}
		}
	}
}
