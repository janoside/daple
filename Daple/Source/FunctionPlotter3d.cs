using Dx = Microsoft.DirectX;
using D3 = Microsoft.DirectX.Direct3D;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for FunctionPlotter3d.
	/// </summary>
	public class FunctionPlotter3d : Plotter3d {

		protected D3.CustomVertex.PositionNormalColored [] fVertices;

		public FunctionPlotter3d(D3.Device d, CartesianSpace s) : base(d,s) {
			this.fNumberXPoints = 100;
			this.fNumberYPoints = 100;
			this.CreateBuffers();
			this.fExpression = new Daple.Expressions.Expression("5*sin(x/5)*cos(y/5)");
			this.fNeedsFunctionCalculation = true;
			this.fColorSetter = new ZPosition3dColorSetter(-1,1);
		}

		public override void DeviceReset() {
			this.CreateBuffers();
			this.fNeedsFunctionCalculation = true;
		}

		protected override void UpdateFromAxis() {
			this.fMinX = (float)this.fCartesianSpace.pXAxis.pMin;
			this.fMaxX = (float)this.fCartesianSpace.pXAxis.pMax;
			this.fMinY = (float)this.fCartesianSpace.pYAxis.pMin;
			this.fMaxY = (float)this.fCartesianSpace.pYAxis.pMax;
		}

		private void CreateBuffers() {
			this.fVertexBuffer = new D3.VertexBuffer(
				typeof(D3.CustomVertex.PositionNormalColored),
				this.fNumberXPoints*this.fNumberYPoints,
				this.fDevice,
				D3.Usage.WriteOnly,
				D3.CustomVertex.PositionNormalColored.Format,
				D3.Pool.Default);

			this.fVertexBuffer2 = new D3.VertexBuffer(
				typeof(D3.CustomVertex.PositionNormalColored),
				this.fNumberXPoints*this.fNumberYPoints,
				this.fDevice,
				D3.Usage.WriteOnly,
				D3.CustomVertex.PositionNormalColored.Format,
				D3.Pool.Default);

			this.fIndexBuffer = new D3.IndexBuffer(
				typeof(short),
				6*(this.fNumberXPoints-1)*(this.fNumberYPoints-1),
				this.fDevice,
				D3.Usage.WriteOnly,
				D3.Pool.Default);
		}

		protected override void CalculateFunctionPoints() {
		//	Expressions.Evaluator e = new MathWorks.Expressions.Evaluator();
		//	e.pExpression = this.fExpression;
			this.fVertices = new D3.CustomVertex.PositionNormalColored[this.fNumberXPoints*this.fNumberYPoints];
			Dx.GraphicsStream stream = this.fVertexBuffer.Lock(0,0,0);
			Dx.GraphicsStream stream2 = this.fVertexBuffer2.Lock(0,0,0);

			System.Drawing.Color [] tempColors = new System.Drawing.Color[this.fVertices.Length];

			Axis3d xAxis = this.fCartesianSpace.pXAxis;
			Axis3d yAxis = this.fCartesianSpace.pYAxis;
			Axis3d zAxis = this.fCartesianSpace.pZAxis;
			
	//		double min = e.Min(xAxis.pMin,xAxis.pMax,zAxis.pMin,zAxis.pMax,5,5);
	//		double max = e.Max(xAxis.pMin,xAxis.pMax,zAxis.pMin,zAxis.pMax,5,5);
		//	this.fColorSetter = new Expression3dColorSetter(xAxis.pMin,xAxis.pMax,yAxis.pMin,yAxis.pMax);
	//		this.fColorSetter = new ZPosition3dColorSetter((float)min,(float)max);

			for ( int z = 0; z < this.fNumberYPoints; z++ ) {
				for ( int x = 0; x < this.fNumberXPoints; x++ ) {

					int index = z*(this.fNumberXPoints)+x;
					
					float xPos = (float)(this.fMinX + (this.fMaxX-this.fMinX)*((float)x)/((float)(this.fNumberXPoints-1)));
					float zPos = (float)(this.fMinY + (this.fMaxY-this.fMinY)*((float)z)/((float)(this.fNumberYPoints-1)));
					float yPos = (float)this.fExpression.Evaluate(xPos,zPos);

					this.fColorInformation = new Position3dColorInformation(new Dx.Vector3(xPos,zPos,yPos));

				//	xPos += this.fMovementState.pPosition.X;
				//	yPos += this.fMovementState.pPosition.Y;
				//	zPos += this.fMovementState.pPosition.Z;

					this.fVertices[index].Position = new Dx.Vector3(xPos,yPos,zPos);
					this.fVertices[index].Normal = new Dx.Vector3(0,1,0);
					this.fVertices[index].Color = System.Drawing.Color.Black.ToArgb();
					
					tempColors[index] = this.fColorSetter.GetColor(this.fColorInformation);//Colors.RainbowColor((float)((float)(yPos-min)/(float)(max-min)));
				}
			}

			// write the vertices to the stream
			stream2.Write(this.fVertices);

			for ( int i = 0; i < this.fVertices.Length; i++ ) {
				this.fVertices[i].Color = tempColors[i].ToArgb();
			}
			stream.Write(this.fVertices);

			// unlock the vertex buffer when done
			this.fVertexBuffer.Unlock();
			this.fVertexBuffer2.Unlock();
		}

		private void SetIndices() {
			Dx.GraphicsStream stream = this.fIndexBuffer.Lock(0,0,0);
			short [] indices = new short[6*(this.fNumberXPoints-1)*(this.fNumberYPoints-1)];

			for ( int z = 0; z < this.fNumberYPoints-1; z++ ) {
				for ( int x = 0; x < this.fNumberXPoints-1; x++ ) {
					int i = z*(this.fNumberXPoints-1)+x;

					indices[6*i  ] = (short)(i+z);
					indices[6*i+1] = (short)(i + this.fNumberXPoints+z);
					indices[6*i+2] = (short)(i + this.fNumberXPoints + 1+z);
					indices[6*i+3] = (short)(i+z);
					indices[6*i+4] = (short)(i +z+ this.fNumberXPoints + 1);
					indices[6*i+5] = (short)(i + 1+z);
				}
			}
			stream.Write(indices);
			this.fIndexBuffer.Unlock();
		}

		public void Update() {
			if ( this.fNeedsFunctionCalculation ) {
				this.CreateBuffers();
				this.CalculateFunctionPoints();
				this.SetIndices();
				this.fNeedsFunctionCalculation = false;
			}
		}

		public override void Render() {
			this.Update();

			this.fDevice.VertexFormat = D3.CustomVertex.PositionNormalColored.Format;
			this.fDevice.SetStreamSource(0,this.fVertexBuffer,0);
			this.fDevice.Indices = this.fIndexBuffer;
		//	this.fDevice.RenderState.CullMode = D3.Cull.;
			this.fDevice.RenderState.FillMode = this.fFillMode;
			this.fDevice.RenderState.Lighting = false;

			this.fDevice.DrawIndexedPrimitives(
				D3.PrimitiveType.TriangleList,
				0,
				0,
				6*(this.fNumberXPoints-1)*(this.fNumberYPoints-1),
				0,
				2*(this.fNumberXPoints-1)*(this.fNumberYPoints-1));

			if ( this.fFillMode == D3.FillMode.Solid && this.fIsGridVisible ) {
				this.fDevice.SetStreamSource(0,this.fVertexBuffer2,0);
				this.fDevice.RenderState.FillMode = D3.FillMode.WireFrame;

				this.fDevice.DrawIndexedPrimitives(
					D3.PrimitiveType.TriangleList,
					0,
					0,
					6*(this.fNumberXPoints-1)*(this.fNumberYPoints-1),
					0,
					2*(this.fNumberXPoints-1)*(this.fNumberYPoints-1));
			}
		}
	}
}
