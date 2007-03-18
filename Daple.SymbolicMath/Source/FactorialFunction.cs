
namespace Daple.Expressions.Functions.Specifics {

	/// <summary>
	/// Summary description for FactorialFunction.
	/// </summary>
	public class FactorialFunction : MathFunction {

		public FactorialFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.Factorial((int)d);
		}
	}
}
