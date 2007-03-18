
namespace Daple.Expressions.Functions.Specifics {
	/// <summary>
	/// Summary description for FactorialFunction.
	/// </summary>
	public class DoubleFactorialFunction : MathFunction {

		public DoubleFactorialFunction(VariableCollection vc, string s) : base(vc,s) {
		}

		public override double FunctionEvaluation(double d) {
			return MathUtil.DoubleFactorial(d);
		}
	}
}
