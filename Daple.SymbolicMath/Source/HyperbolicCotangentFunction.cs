
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for SineFunction.
	/// </summary>
	public class HyperbolicCotangentFunction : MathFunction {

		public HyperbolicCotangentFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.Coth(d);
		}
	}
}