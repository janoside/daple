
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class InverseHyperbolicSecantFunction : MathFunction {

		public InverseHyperbolicSecantFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.ArcSech(d);
		}
	}
}