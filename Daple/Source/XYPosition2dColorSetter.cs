using System;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for XYPosition2dColorSetter.
	/// </summary>
	public class XYPosition2dColorSetter : Expression2dColorSetter {

		public XYPosition2dColorSetter(string s, double x0, double x1) : base(s,x0,x1) {
		}

		protected override System.Drawing.Color GetPositionColor(Position2dColorInformation ci) {
			return Colors.Lerp(
				this.fColors,
				(float)((this.fExpression.Evaluate(ci.pPosition.X)+ci.pPosition.X-this.fMinX)/(this.fExpressionRange+(this.fMaxX-this.fMinX))));
		}
	}
}
