using System.Collections;

using Dx = Microsoft.DirectX;
using D3 = Microsoft.DirectX.Direct3D;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for Axis3d.
	/// </summary>
	public class Axis3d : CartesianAxis, IRenderable {

		protected D3.Device fDevice;

		protected D3.VertexBuffer fVertexBuffer;

		protected ArrayList fLabelPositions;

		protected System.Drawing.Color fColor;

		protected WorldAxis fWorldAxis;

		public Axis3d(D3.Device d, WorldAxis wa, double min, double max) : base(min,max) {
			this.fDevice = d;
			this.fWorldAxis = wa;
			this.fColor = System.Drawing.Color.White;
			this.fLabelPositions = new ArrayList();
			this.Initialize();
		}

		public void DeviceReset() {
			this.Initialize();
		}

		public new double pMin {
			get {
				return this.fMin;
			}
			set {
				this.fMin = value;
				this.SetVertices();
			}
		}

		public new double pMax {
			get {
				return this.fMax;
			}
			set {
				this.fMax = value;
				this.SetVertices();
			}
		}

		protected void Initialize() {
			this.fVertexBuffer = new D3.VertexBuffer(
				typeof(D3.CustomVertex.PositionColored),
				2,
				this.fDevice,
				D3.Usage.WriteOnly,
				D3.CustomVertex.PositionColored.Format,
				D3.Pool.Default);

			this.SetVertices();
		}

		protected void SetVertices() {
			Dx.GraphicsStream stream = this.fVertexBuffer.Lock(0,0,0);
			D3.CustomVertex.PositionColored [] vertices = new D3.CustomVertex.PositionColored[2];

			switch ( this.fWorldAxis ) {
				case WorldAxis.X:
					vertices[0].Position = new Dx.Vector3((float)this.fMin,0,0);
					vertices[1].Position = new Dx.Vector3((float)this.fMax,0,0);
					break;
				case WorldAxis.Y:
					vertices[0].Position = new Dx.Vector3(0,(float)this.fMin,0);
					vertices[1].Position = new Dx.Vector3(0,(float)this.fMax,0);
					break;
				case WorldAxis.Z:
					vertices[0].Position = new Dx.Vector3(0,0,(float)this.fMin);
					vertices[1].Position = new Dx.Vector3(0,0,(float)this.fMax);
					break;
			}
			vertices[0].Color = this.fColor.ToArgb();
			vertices[1].Color = this.fColor.ToArgb();

			stream.Write(vertices);
			this.fVertexBuffer.Unlock();
		}

		protected override void CalculateIncrements() {
		}

		protected override void CalculateNegativeTicks() {
		}

		protected override void CalculatePositiveTicks() {
		}

		public void Render() {
			this.fDevice.SetStreamSource(0,this.fVertexBuffer,0);
			this.fDevice.VertexFormat = D3.CustomVertex.PositionColored.Format;
			D3.Compare oldCompare = this.fDevice.RenderState.ZBufferFunction;
			this.fDevice.RenderState.ZBufferFunction = D3.Compare.Always;

			this.fDevice.DrawPrimitives(
				D3.PrimitiveType.LineList,
				0,
				1);

			this.fDevice.RenderState.ZBufferFunction = oldCompare;
		}
	}
}
