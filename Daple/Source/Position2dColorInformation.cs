using Dx = Microsoft.DirectX;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for PositionColorInformation.
	/// </summary>
	public class Position2dColorInformation : ColorInformation {

		protected Dx.Vector2 fPosition;

		public Position2dColorInformation(Dx.Vector2 v) {
			this.fPosition = v;
		}

		public Dx.Vector2 pPosition {
			get {
				return this.fPosition;
			}
		}
	}
}