
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class AbsoluteValueFunction : MathFunction {

		public AbsoluteValueFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.Abs(d);
		}

		public override string Differentiate(Variable v) {
			if ( !this.fArgument.Contains(v) && !this.fPower.Contains(v) ) {
				return "0";
			} else {
				string s = this.fString + "*(";
				
				s += this.fPower.pString + "/" + this.fMainString;
				Expression e = new Expression(this.fMainString);
				s += "*" + e.Differentiate(v);

				s += "+ln("+this.fMainString+")*"+this.fPower.Differentiate(v);

				return s;
			}
		}
	}
}