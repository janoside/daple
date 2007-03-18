using System;

namespace Daple.Expressions {

	/// <summary>
	/// Summary description for Variable.
	/// </summary>
	public class Variable {

		private string fString;

		private double fValue;

		public Variable(string s, double d) {
			this.fString = s;
			this.fValue = d;
		}

		public Variable(string s) : this(s,0) {
		}

		public double pValue {
			get {
				return this.fValue;
			}
			set {
				this.fValue = value;
			}
		}

		public string pString {
			get {
				return this.fString;
			}
		}

		public string Differentiate(Variable v) {
			if ( this.Equals(v) ) {
				return "1";
			} else {
				return "0";
			}
		}

		public override string ToString() {
			return this.fString;
		}

		public override bool Equals(object obj) {
			if ( obj is Variable ) {
				return ((Variable)obj).pString.Equals(this.fString);
			}
			return base.Equals(obj);
		}
	}
}
