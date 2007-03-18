using System;

namespace Daple.Expressions.Functions {

	/// <summary>
	/// Summary description for ConstantFunction.
	/// </summary>
	public class ConstantFunction : Function {

		private double fValue;
	
		public ConstantFunction(VariableCollection vc, string s) : base(vc,s) {
			if ( StringUtil.Contains(s,"^") ) {
				this.fValue = Double.Parse(s.Substring(0,s.IndexOf("^")));
				this.fPower = new Expression(s.Substring(s.IndexOf("^")+1));
				foreach ( Variable v in this.fPower.pVariables ) {
					vc.Add(v);
				}
			} else {
				this.fValue = Double.Parse(this.fString);
			}
		}

		public ConstantFunction(string s) : this(new VariableCollection(),s) {
		}

		public bool pIsConstant {
			get {
				return (this.fPower == null);
			}
		}

		public override string Differentiate(Variable v) {
			if ( this.pIsConstant ) {
				return "0";
			} else {
				return this.fString + "*ln(" + this.fValue.ToString() + ")*" + this.fPower.Differentiate(v);
			}
		}

		public override double Evaluate(VariableCollection vc) {
			if ( this.fPower != null ) {
				return Math.Pow(this.fValue,this.fPower.Evaluate(vc));
			} else {
				return this.fValue;
			}
		}

		public override string Substitute(VariableCollection vc) {
			if ( this.fPower == null ) {
				return this.fString;
			} else {
				return this.fValue.ToString() + "^" + this.fPower.Substitute(vc);
			}
		}

		public override string ToString() {
			return this.fString;
		}
	}
}
