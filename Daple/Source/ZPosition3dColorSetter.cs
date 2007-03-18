
namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for ZPosition3dColorSetter.
	/// </summary>
	public class ZPosition3dColorSetter : Position3dColorSetter {

		protected float fMinZ;

		protected float fMaxZ;

		public ZPosition3dColorSetter(float min, float max) {
			this.fMinZ = min;
			this.fMaxZ = max;
		}

		protected override System.Drawing.Color GetPositionColor(Position3dColorInformation ci) {
			return Colors.Lerp(this.fColors,(ci.pPosition.Z-this.fMinZ)/(this.fMaxZ-this.fMinZ));
		}
	}
}
