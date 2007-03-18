using System;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for XPosition2dColorSetter.
	/// </summary>
	public class XPosition2dColorSetter : Position2dColorSetter {

		protected float fMinX;

		protected float fMaxX;

		public XPosition2dColorSetter(float minX, float maxX) {
			this.fMinX = minX;
			this.fMaxX = maxX;
		}

		protected override System.Drawing.Color GetPositionColor(Position2dColorInformation ci) {
			return Colors.Lerp(this.fColors,(ci.pPosition.X-this.fMinX)/(float)(this.fMaxX-this.fMinX));
		}
	}
}
