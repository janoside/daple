using System.Drawing;
using System.Drawing.Drawing2D;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for PolarAxis.
	/// </summary>
	public class PolarAxis : Axis2d {

		protected Pen fRadialPen;

		protected Pen fAngularPen;

		protected int fAngularDivisions;

		protected bool fAreRadialDivisionsDrawn;

		protected bool fAreAngularDivisionsDrawn;

		public PolarAxis(CartesianPlane p)
			: base(p, 0, 2 * MathUtil.Pi) {
			this.fAngularDivisions = 8;
			this.fAreRadialDivisionsDrawn = true;
			this.fAreAngularDivisionsDrawn = true;
			this.fRadialPen = new Pen(Color.LightGray,1);
			this.fAngularPen = new Pen(Color.Black,1);
			this.fMajorTickLine = new StationaryLine();
		}

		public Pen pRadialPen {
			get {
				return this.fRadialPen;
			}
		}

		public Pen pAngularPen {
			get {
				return this.fAngularPen;
			}
		}

		public int pAngularDivisions {
			get {
				return this.fAngularDivisions;
			}
			set {
				if ( value >= 0 ) {
					this.fAngularDivisions = value;
				}
			}
		}

		public bool pAreRadialDivisionsDrawn {
			get {
				return this.fAreRadialDivisionsDrawn;
			}
			set {
				this.fAreRadialDivisionsDrawn = value;
			}
		}

		public bool pAreAngularDivisionsDrawn {
			get {
				return this.fAreAngularDivisionsDrawn;
			}
			set {
				this.fAreAngularDivisionsDrawn = value;
			}
		}

	//	public override void ForceUpdate() {
//
//		}

		protected override void CalculateNegativeTicks() {
		}

		protected override void CalculatePositiveTicks() {
			this.fMin = 0;
			this.fMax = MathUtil.Max(
				MathUtil.Abs(this.fCartesianPlane.pXAxis.pMax),
				MathUtil.Abs(this.fCartesianPlane.pYAxis.pMax),
				MathUtil.Abs(this.fCartesianPlane.pXAxis.pMin),
				MathUtil.Abs(this.fCartesianPlane.pYAxis.pMin));
		}

		protected override void DrawMainAxis(Graphics g) {

		}

		public override void DrawGrid(Graphics g) {
			if ( this.fIsVisible && this.fAreRadialDivisionsDrawn ) {
				GraphicsPath p = new GraphicsPath();
				p.AddRectangle(this.fCartesianPlane.pClipRectangle);
				g.SetClip(p,CombineMode.Replace);

				float radius = 0;

				double unitX = this.fCartesianPlane.pXAxis.pUnitSize;
				double unitY = this.fCartesianPlane.pYAxis.pUnitSize;
				int ox = this.fCartesianPlane.pOrigin.pXPos;
				int oy = this.fCartesianPlane.pOrigin.pYPos;

				if ( this.fAreRadialDivisionsDrawn ) {
					while ( radius < this.fMax ) {
						g.SmoothingMode = SmoothingMode.HighQuality;
						g.DrawEllipse(
							this.fRadialPen,
							(float)(ox - radius*unitX),
							(float)(oy - radius*unitY),
							(float)(2*radius*unitX),
							(float)(2*radius*unitY));

						radius += (float)MathUtil.Max(
							this.fCartesianPlane.pXAxis.pDivisionSize,
							this.fCartesianPlane.pYAxis.pDivisionSize);
					}
				}

				g.ResetClip();
			}
		}

		protected override void SetTickLineType() {
		}




	/*	protected override void CalculateDivisions() {
			this.fMin = 0;
			this.fMax = Math.Max(
				Math.Abs(this.fCartesianPlane.pXAxis.pMax),
				Math.Abs(this.fCartesianPlane.pYAxis.pMax),
				Math.Abs(this.fCartesianPlane.pXAxis.pMin),
				Math.Abs(this.fCartesianPlane.pYAxis.pMin));

			System.Console.WriteLine("max="+this.fMax);
		}

		public override void Draw(Graphics g) {
			this.DrawTicks(g);
		}*/

	/*	public override void DrawGrid(Graphics g) {
			
		}*/

	/*	protected override void DrawTicks(Graphics g) {

		}*/
	}
}
