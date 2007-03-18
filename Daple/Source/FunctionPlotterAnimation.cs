using Daple.Expressions;
using Daple.Plotting.TwoD;
using Daple.Plotting;

namespace Daple.Animation.Testing {

	/// <summary>
	/// Summary description for FunctionPlotterAnimation.
	/// </summary>
	public class FunctionPlotterAnimation : Animation, IDrawable {

		public FunctionPlotterAnimation(GraphPanel gp, TimeManager tm, Expression e, CartesianPlane p) : base(gp,tm) {
			Variable v = new Variable("time",1);
			for ( int i = 0; i < this.fNumberOfSteps; i++ ) {
				FunctionPlotter fp = new FunctionPlotter(p);
				v.pValue = this.fInterval.pMin + (double)i/(double)(this.fNumberOfSteps-1)*(this.fInterval.pMax-this.fInterval.pMin);
				VariableCollection vc = new VariableCollection(v);
				fp.pExpression = new Expression(e.Substitute(vc));
				this.Add(fp);
			}
			this.fThread.Start();
		}

		public void Draw(System.Drawing.Graphics g) {
			((IDrawable)(this.fSteps[this.fIndex])).Draw(g);
		}
	}
}
