using System;

namespace Daple.Expressions.Functions {

	/// <summary>
	/// Summary description for VariableFunction.
	/// </summary>
	public class VariableFunction : Function {
	
		private Variable fVariable;
	
		public VariableFunction(VariableCollection vc, string s) : base(vc,s) {
			if ( StringUtil.Contains(s,"^") ) {
				this.fVariable = new Variable(s.Substring(0,s.IndexOf("^")));
				//	this.myPower = new Expression(s.substring(s.indexOf("^")+1));
			} else {
				this.fVariable = new Variable(s);	
			}
			vc.Add(this.fVariable);
		}
	
		public override string Substitute(VariableCollection vc) {
			string s = "";
			foreach ( Variable v in vc ) {
				if ( v.Equals(this.fVariable) ) {
					if ( this.fPower != null ) {
						s = v.pValue.ToString() + "^(" + this.fPower.Substitute(vc) + ")";
					} else {
						s = v.pValue.ToString();
					}
				}
			}
			if ( s.Equals("") ) {
				return this.fString;	
			}
			return s;
		}

		public override string Differentiate(Variable v) {
			string s = this.fString;
			s += "*(";

			s += this.fPower.pString + "*" + this.fVariable.Differentiate(v);
			s += "/" + this.fVariable.pString;

			s += "ln(" + this.fVariable.pString + ")*" + this.fPower.Differentiate(v);

			s += ")";
			return s;
		}
	
		public override double Evaluate(VariableCollection vc) {
			if ( vc == null ) {
				return 0;
			}
			for ( int i = 0; i < vc.Count; i++ ) {
				if ( this.fVariable.Equals(vc[i]) ) {
					if ( this.fPower != null ) {
						return Math.Pow(vc[i].pValue,this.fPower.Evaluate(vc));
					} else {
						return vc[i].pValue;
					}
				}
			}
			return 0;
		}
	}
}
