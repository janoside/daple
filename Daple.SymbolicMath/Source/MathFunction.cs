using System;

namespace Daple.Expressions.Functions {

	/// <summary>
	/// Summary description for MathFunction.
	/// </summary>
	public abstract class MathFunction : Function {

		protected string fMainString;

		public MathFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		protected override void Analyze(VariableCollection vc) {
			string s = this.fString;

			for ( int i = 0; i < s.Length; i++ ) {
				if ( s.Substring(i, 1).Equals("^") && !StringUtil.InsideParentheses(s, i) ) {
					this.fPower = new Expression(s.Substring(i+1,s.Length-i-1));
					s = s.Substring(0,i);
					this.fMainString = s.Substring(0,i);
				}
			}
			if ( StringUtil.Contains(s, "(") ) {
				int x = s.IndexOf("(");
				this.fArgument = new Expression(s.Substring(x+1,s.Length-x-2));
			} else {
				try {
					Double.Parse(s);
				} catch(System.FormatException) {
					vc.Add(new Variable(s));
				}
			}
			if ( this.fPower != null ) {
				vc.AddAll(this.fPower.pVariables);
			}
			if ( this.fArgument != null ) {
				vc.AddAll(this.fArgument.pVariables);
			}
		}

		public override double Evaluate(VariableCollection vc) {
			if ( this.fPower == null ) {
				return this.FunctionEvaluation(this.fArgument.Evaluate(vc));	
			} else {
				return Math.Pow(this.FunctionEvaluation(this.fArgument.Evaluate(vc)),this.fPower.Evaluate(vc));	
			}
		}

		public override string Substitute(VariableCollection vc) {
			string s = this.fString.Substring(0,this.fString.IndexOf("(")) + "(" + this.fArgument.Substitute(vc) + ")";
			if ( this.fPower != null ) {
				s += "^" + this.fPower.Substitute(vc);
			}
			return s;
		}

		public abstract double FunctionEvaluation(double d);

		public override string Differentiate(Variable v) {
			return "";
		}
	}
}
