using Dx = Microsoft.DirectX;
using D3 = Microsoft.DirectX.Direct3D;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for Plotter3d.
	/// </summary>
	public abstract class Plotter3d : Plotter, IRenderable {

		protected D3.Device fDevice;

		protected D3.VertexBuffer fVertexBuffer;

		protected D3.VertexBuffer fVertexBuffer2;

		protected D3.IndexBuffer fIndexBuffer;

		protected CartesianSpace fCartesianSpace;

		protected D3.FillMode fFillMode;

		protected float fMinX;

		protected float fMaxX;

		protected float fMinY;

		protected float fMaxY;

		protected int fNumberYPoints;

		protected bool fIsGridVisible;

		public Plotter3d(D3.Device d, CartesianSpace s) {
			this.fDevice = d;
			this.fCartesianSpace = s;
			this.fNumberYPoints = this.fNumberXPoints;
			this.fFillMode = D3.FillMode.Solid;
			this.fIsGridVisible = false;
			this.fMinX = -5;
			this.fMaxX = 5;
			this.fMinY = -5;
			this.fMaxY = 5;
		}

		public D3.FillMode pFillMode {
			get {
				return this.fFillMode;
			}
			set {
				this.fFillMode = value;
			}
		}

		public float pMinX {
			get {
				return this.fMinX;
			}
			set {
				if ( value < this.fMaxX ) {
					this.fMinX = value;
					this.Invalidate();
				}
			}
		}

		public float pMaxX {
			get {
				return this.fMaxX;
			}
			set {
				if ( value > this.fMinX ) {
					this.fMaxX = value;
					this.Invalidate();
				}
			}
		}

		public float pMinY {
			get {
				return this.fMinY;
			}
			set {
				if ( value < this.fMaxY ) {
					this.fMinY = value;
					this.Invalidate();
				}
			}
		}

		public float pMaxY {
			get {
				return this.fMaxY;
			}
			set {
				if ( value > this.fMinY ) {
					this.fMaxY = value;
					this.Invalidate();
				}
			}
		}

		public int pYPoints {
			get {
				return this.fNumberYPoints;
			}
			set {
				this.fNumberYPoints = value;
				this.fNeedsFunctionCalculation = true;
				this.fNeedsScreenCalculation = true;
			}
		}

		public bool pIsGridVisible {
			get {
				return this.fIsGridVisible;
			}
			set {
				this.fIsGridVisible = value;
			}
		}

		public abstract void Render();

		public abstract void DeviceReset();
	}
}
