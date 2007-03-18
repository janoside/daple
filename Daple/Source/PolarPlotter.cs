using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for FunctionPlotter.
	/// </summary>
	public class PolarPlotter : Plotter2d {

		public PolarPlotter(CartesianPlane p) : base(p) {
			this.fExpression = new Daple.Expressions.Expression("5*sin(6*x)");
			this.fPen = new Pen(Color.Red);
			this.fNumberXPoints = 500;
		}

		protected override void UpdateFromAxis() {
			// nothing
		}

		protected override void CalculateFunctionPoints() {
			float x = (float)this.fMinX;
			float dx = (float)(this.fMaxX - this.fMinX);
			dx /= (float)(this.fNumberXPoints-1);

			this.fPoints.Clear();
			for ( int i = 0; i < this.fNumberXPoints; i++ ) {
				double val = this.fExpression.Evaluate(x);
				this.fPoints.Add(new PointF((float)(val * MathUtil.Cos(x)), (float)(val * MathUtil.Sin(x))));
				x += dx;
			}
			this.fNeedsFunctionCalculation = false;
		}
	}
}