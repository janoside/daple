
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class InverseSineFunction : MathFunction {

		public InverseSineFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.ArcSin(d);
		}
	}
}