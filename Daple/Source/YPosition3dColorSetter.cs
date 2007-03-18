using System;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for XPosition3dColorSetter.
	/// </summary>
	public class YPosition3dColorSetter : Expression3dColorSetter {

		public YPosition3dColorSetter(double minX, double maxX, double minY, double maxY) : base("x*0+y",minX,maxX,minY,maxY) {
		}
	}
}
