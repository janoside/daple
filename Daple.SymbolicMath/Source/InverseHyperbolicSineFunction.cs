
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class InverseHyperbolicSineFunction : MathFunction {

		public InverseHyperbolicSineFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.ArcSinh(d);
		}
	}
}