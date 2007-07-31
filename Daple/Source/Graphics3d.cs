using Dx = Microsoft.DirectX;
using D3 = Microsoft.DirectX.Direct3D;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for Graphics3d.
	/// </summary>
	public class Graphics3d {

		protected D3.PresentParameters fPresentParameters;

		protected D3.Device fDevice;

		protected GraphPanel3d fGraphPanel;

		protected RenderableCollection fRenderables;

		protected System.Drawing.Color fClearColor;

		protected float fFieldOfView;

		protected int fYRotation;

		protected int fXRotation;

		protected int fMouseX;

		protected int fMouseY;

		public Graphics3d(GraphPanel3d c) {
			this.fGraphPanel = c;
			this.fClearColor = System.Drawing.Color.Black;
			this.fRenderables = new RenderableCollection();
			this.fFieldOfView = (float)MathUtil.Pi / 4.0f;
			this.InitializeGraphics();
		}

		public D3.Device pDevice {
			get {
				return this.fDevice;
			}
		}

		public RenderableCollection pRenderables {
			get {
				return this.fRenderables;
			}
		}

		public void Add(IRenderable ir) {
			this.fRenderables.Add(ir);
		}

		public void DragMouse(int x, int y) {
			int dx = x - this.fMouseX;
			int dy = y - this.fMouseY;

			this.fYRotation -= (int)(dx/1);
			this.fXRotation += (int)(dy/1);

			this.fMouseX = x;
			this.fMouseY = y;
		}

		public void MouseWheel(int x) {
			x /= 120;
			this.fFieldOfView -= (float)(MathUtil.Pi * x / 64.0);
			if ( this.fFieldOfView < (MathUtil.Pi / 32.0) ) {
				this.fFieldOfView = (float)(MathUtil.Pi / 32.0);
			} else if ( this.fFieldOfView > (2 * MathUtil.Pi) ) {
				this.fFieldOfView = (float)(2 * MathUtil.Pi);
			}
		}

		public void SetMousePosition(int x, int y) {
			this.fMouseX = x;
			this.fMouseY = y;
		}

		private void InitializeGraphics() {
			this.fPresentParameters = new D3.PresentParameters();
			this.fPresentParameters.AutoDepthStencilFormat = D3.DepthFormat.D16;
			this.fPresentParameters.EnableAutoDepthStencil = true;
			this.fPresentParameters.Windowed = true;
			this.fPresentParameters.SwapEffect = D3.SwapEffect.Discard;
			this.fPresentParameters.PresentationInterval = D3.PresentInterval.Immediate;
			this.fPresentParameters.MultiSample = D3.MultiSampleType.NonMaskable;

			this.fDevice = new D3.Device(
				0,
				D3.DeviceType.Hardware,
				this.fGraphPanel,
				D3.CreateFlags.HardwareVertexProcessing,
				this.fPresentParameters);

			this.fDevice.DeviceReset += new System.EventHandler(fDevice_DeviceReset);
			this.fDevice_DeviceReset(null,null);
		//	this.fDevice.DeviceLost += new System.EventHandler(fDevice_DeviceLost);
		//	this.fDevice.DeviceLost += new System.EventHandler(fDevice_DeviceLost);
		}

		private void PostDeviceCreation() {
			this.fDevice.RenderState.CullMode = D3.Cull.None;
			System.Console.WriteLine("hahahahahahhahahhahohohohoh");
		//	this.fDevice.RenderState.FillMode = D3.FillMode.WireFrame;
			this.fDevice.RenderState.Lighting = true;
			//this.fDevice.RenderState.Ambient = System.Drawing.Color.White;
			D3.Material m = new D3.Material();
			m.Diffuse = System.Drawing.Color.White;
			m.Ambient = System.Drawing.Color.White;
			this.fDevice.Material = m;
		}

		private void SetupMatrices() {
			Dx.Matrix m = Dx.Matrix.Identity;
		//	Dx.Matrix m = Dx.Matrix.RotationY((float)Math.ToRadians(this.fYRotation));
		//	m *= Dx.Matrix.RotationX((float)Math.ToRadians(this.fXRotation));
			m *= Dx.Matrix.RotationYawPitchRoll(
				(float)MathUtil.ToRadians(this.fYRotation),
				(float)MathUtil.ToRadians(this.fXRotation),
				0);
			this.fDevice.Transform.World = m;

			this.fDevice.Transform.View = Dx.Matrix.LookAtLH(
				new Dx.Vector3(20,6,0),			// position of the camera
				new Dx.Vector3(0,0,0),			// camera target
				new Dx.Vector3(0,1,0));			// camera up vector

			this.fDevice.Transform.Projection = Dx.Matrix.PerspectiveFovLH(
				this.fFieldOfView,		// angle of field of view
				1,							// aspect ratio of the viewport	
				1.0f,						// nearest view plane
				1000.0f);
		}

		public void Render() {
			this.fDevice.Clear(
				D3.ClearFlags.Target | D3.ClearFlags.ZBuffer,
				this.fClearColor.ToArgb(),
				1.0f,
				0);
			
			this.fDevice.BeginScene();

			this.SetupMatrices();

			for ( int i = this.fRenderables.Count-1; i >= 0; i-- ) {
				this.fRenderables[i].Render();
			}

			this.fDevice.EndScene();

			this.fDevice.Present();
		}

		private void fDevice_DeviceReset(object sender, System.EventArgs e) {
			this.PostDeviceCreation();
			foreach ( IRenderable ir in this.fRenderables ) {
				ir.DeviceReset();
			}
		}

		private void fDevice_DeviceLost(object sender, System.EventArgs e) {
			this.InitializeGraphics();
		}
	}
}
