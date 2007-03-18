
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class NullFunction : MathFunction {

		public NullFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return d;
		}

		public override string Substitute(VariableCollection vc) {
			string s = base.Substitute(vc);
			if ( s.StartsWith("null") ) {
				s = s.Substring(s.IndexOf("null")+"null".Length);		
			}
			return s;
		}
	}
}