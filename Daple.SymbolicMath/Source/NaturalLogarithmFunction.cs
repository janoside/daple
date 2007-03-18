
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class NaturalLogarithmFunction : MathFunction {

		public NaturalLogarithmFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.Ln(d);
		}
	}
}