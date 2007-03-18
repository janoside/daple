using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for FunctionPlotter.
	/// </summary>
	public class FunctionPlotter : Plotter2d {

		public FunctionPlotter(CartesianPlane p) : base(p) {
			this.fExpression = new Daple.Expressions.Expression("5*sin(x)");
			this.fPen = new Pen(Color.Red);
		}

		protected override void CalculateFunctionPoints() {
			float x = (float)this.fMinX;//this.fCartesianPlane.pXAxis.pMin;
			float dx = (float)(this.fMaxX-this.fMinX);//this.fCartesianPlane.pXAxis.pMax - this.fCartesianPlane.pXAxis.pMin);
			dx /= (float)(this.fNumberXPoints-1);
			double evaluation;

			this.fPoints.Clear();
			for ( int i = 0; i < this.fNumberXPoints; i++ ) {
				evaluation = this.fExpression.Evaluate(x);
				if ( evaluation != float.NaN && evaluation != double.NaN ) {
					this.fPoints.Add(new PointF(x,(float)evaluation));
				}
				x += dx;
			}
			this.fNeedsFunctionCalculation = false;
		}

		protected override void UpdateFromAxis() {
			this.fMinX = this.fCartesianPlane.pXAxis.pMin;
			this.fMaxX = this.fCartesianPlane.pXAxis.pMax;
		}

		public override string ToString() {
			return "FunctionPlotter2d["+this.fExpression.ToString()+"]";
		}
	}
}
