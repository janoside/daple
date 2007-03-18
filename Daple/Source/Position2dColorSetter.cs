
namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for Position3dColorSetter.
	/// </summary>
	public abstract class Position2dColorSetter : ColorSetter {

		public Position2dColorSetter() {
		}

		public override System.Drawing.Color GetColor(ColorInformation ci) {
			if ( ci is Position2dColorInformation ) {
				return this.GetPositionColor((Position2dColorInformation)ci);
			}
			return System.Drawing.Color.White;
		}

		protected abstract System.Drawing.Color GetPositionColor(Position2dColorInformation ci);
	}
}