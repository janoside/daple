using System;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for XPosition3dColorSetter.
	/// </summary>
	public class XYPosition3dColorSetter : Expression3dColorSetter {

		public XYPosition3dColorSetter(double minX, double maxX, double minY, double maxY) : base("x+y",minX,maxX,minY,maxY) {
		}
	}
}
