using Daple.Expressions;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for Expression3dColorSetter.
	/// </summary>
	public class Expression2dColorSetter : Position2dColorSetter {

		protected Expression fExpression;

		protected Evaluator fEvaluator;

		protected double fMinX;

		protected double fMaxX;

		protected double fMinY;

		protected double fExpressionRange;

		public Expression2dColorSetter(string s, double minX, double maxX) {
			this.fMinX = minX;
			this.fMaxX = maxX;
			this.fExpression = new Expression(s);
			this.Update();
		}

		public Expression pExpression {
			get {
				return this.fExpression;
			}
		}

		protected void Update() {
			this.fEvaluator = new Evaluator(this.fExpression);
			this.fMinY = this.fEvaluator.Min(
				this.fMinX,
				this.fMaxX);

			this.fExpressionRange = this.fEvaluator.Range(
				this.fMinX,
				this.fMaxX);
		}

		protected override System.Drawing.Color GetPositionColor(Position2dColorInformation ci) {
			return Colors.Lerp(this.fColors,(float)((this.fExpression.Evaluate(ci.pPosition.X)-this.fMinY)/this.fExpressionRange));
		}
	}
}

