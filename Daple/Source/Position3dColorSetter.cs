
namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for Position3dColorSetter.
	/// </summary>
	public abstract class Position3dColorSetter : ColorSetter {

		public Position3dColorSetter() {
		}

		public override System.Drawing.Color GetColor(ColorInformation ci) {
			if ( ci is Position3dColorInformation ) {
				return this.GetPositionColor((Position3dColorInformation)ci);
			}
			return System.Drawing.Color.White;
		}

		protected abstract System.Drawing.Color GetPositionColor(Position3dColorInformation ci);
	}
}
