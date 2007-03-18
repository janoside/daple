using Daple.Expressions;

namespace Daple.MathType {

	/// <summary>
	/// Summary description for ExpressionPanel.
	/// </summary>
	public class ExpressionPanel : System.Windows.Forms.UserControl {

		private Expression fExpression;

		public ExpressionPanel(Expression e) {
			this.fExpression = e;
		}

		private void Initialize() {
		}
	}
}
