using System.Drawing;

using Daple.Expressions;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for ParametricPlotter.
	/// </summary>
	public class ParametricPlotter : Plotter2d {

		protected Expression fExpression2;

		public ParametricPlotter(CartesianPlane p) : base(p) {
		}

		public Expression pExpression2 {
			get {
				return this.fExpression2;
			}
			set {
				this.fExpression2 = value;
			}
		}

		protected override void UpdateFromAxis() {
			// nothing
		}

		public string GetExpressions() {
			return "["+this.fExpression.ToString()+","+this.fExpression2.ToString()+"]";
		}

		protected override void CalculateFunctionPoints() {
			float x = (float)this.fMinX;
			float dx = (float)(this.fMaxX-this.fMinX);
			dx /= (float)(this.fNumberXPoints-1);
			double evaluation;
			double evaluation2;

			this.fPoints.Clear();
			for ( int i = 0; i < this.fNumberXPoints; i++ ) {
				evaluation = this.fExpression.Evaluate(x);
				evaluation2 = this.fExpression2.Evaluate(x);
				if ( evaluation != double.NaN && evaluation2 != double.NaN ) {
					this.fPoints.Add(new PointF((float)evaluation,(float)evaluation2));
				}
				x += dx;
			}
			this.fNeedsFunctionCalculation = false;
		}
	}
}
