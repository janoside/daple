
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class CosineFunction : MathFunction {

		public CosineFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.Cos(d);
		}
	}
}