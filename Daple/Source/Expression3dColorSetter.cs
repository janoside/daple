using Daple.Expressions;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for Expression3dColorSetter.
	/// </summary>
	public class Expression3dColorSetter : Position3dColorSetter {

		protected Expression fExpression;

		protected Evaluator fEvaluator;

		protected double fMinX;

		protected double fMaxX;

		protected double fMinY;

		protected double fMaxY;

		protected double fMinZ;

		protected double fExpressionRange;

		public Expression3dColorSetter(string s, double minX, double maxX, double minY, double maxY) {
			this.fMinX = minX;
			this.fMaxX = maxX;
			this.fMinY = minY;
			this.fMaxY = maxY;
			this.fExpression = new Expression(s);
			this.Update();
		}

		public Expression3dColorSetter(double minX, double maxX, double minY, double maxY) : this("sin(x)*cos(x*y)",minX,maxX,minY,maxY) {
		}

		public Expression pExpression {
			get {
				return this.fExpression;
			}
		}

		protected void Update() {
			this.fEvaluator = new Evaluator(this.fExpression);
			this.fMinZ = this.fEvaluator.Min(
				this.fMinX,
				this.fMaxX,
				this.fMinY,
				this.fMaxY);

			this.fExpressionRange = this.fEvaluator.Range(
				this.fMinX,
				this.fMaxX,
				this.fMinY,
				this.fMaxY);
		}

		protected override System.Drawing.Color GetPositionColor(Position3dColorInformation ci) {
			return Colors.Lerp(this.fColors,(float)((this.fExpression.Evaluate(ci.pPosition.X,ci.pPosition.Y)-this.fMinZ)/this.fExpressionRange));
		}
	}
}
