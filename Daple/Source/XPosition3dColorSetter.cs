using System;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for XPosition3dColorSetter.
	/// </summary>
	public class XPosition3dColorSetter : Expression3dColorSetter {

		public XPosition3dColorSetter(double minX, double maxX, double minY, double maxY) : base("x+y*0",minX,maxX,minY,maxY) {
		}
	}
}
