using Dx = Microsoft.DirectX;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for PositionColorInformation.
	/// </summary>
	public class Position3dColorInformation : ColorInformation {

		protected Dx.Vector3 fPosition;

		public Position3dColorInformation(Dx.Vector3 v) {
			this.fPosition = v;
		}

		public Dx.Vector3 pPosition {
			get {
				return this.fPosition;
			}
		}
	}
}
