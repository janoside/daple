using D3 = Microsoft.DirectX.Direct3D;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for CartesianSpace.
	/// </summary>
	public class CartesianSpace : IRenderable {

		protected Axis3d fXAxis;
		
		protected Axis3d fYAxis;

		protected Axis3d fZAxis;

		protected D3.Device fDevice;
		
		protected D3.Font fFont;

		public CartesianSpace(D3.Device d) {
			this.fDevice = d;
			this.fXAxis = new Axis3d(this.fDevice,WorldAxis.X,-5,5);
			this.fYAxis = new Axis3d(this.fDevice,WorldAxis.Y,-5,5);
			this.fZAxis = new Axis3d(this.fDevice,WorldAxis.Z,-5,5);
			this.fFont = new D3.Font(
				this.fDevice,
				AxisLabel.Font);
		}

		public void DeviceReset() {
			this.fXAxis.DeviceReset();
			this.fYAxis.DeviceReset();
			this.fZAxis.DeviceReset();
		}

		public Axis3d pXAxis {
			get {
				return this.fXAxis;
			}
		}

		public Axis3d pYAxis {
			get {
				return this.fYAxis;
			}
		}

		public Axis3d pZAxis {
			get {
				return this.fZAxis;
			}
		}

		public void Render() {
			this.fXAxis.Render();
			this.fYAxis.Render();
			this.fZAxis.Render();
		//	this.fFont.DrawText(
		//		null,
		//		"Working",
		//		new System.Drawing.Rectangle(0,0,200,50),
		//		D3.DrawTextFormat.Center | D3.DrawTextFormat.VerticalCenter,
		//		System.Drawing.Color.Red);
		}
	}
}
