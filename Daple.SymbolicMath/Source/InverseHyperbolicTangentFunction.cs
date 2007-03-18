
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class InverseHyperbolicTangentFunction : MathFunction {

		public InverseHyperbolicTangentFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.ArcTanh(d);
		}
	}
}