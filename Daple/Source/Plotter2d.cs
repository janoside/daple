using System.Drawing;
using System.Drawing.Drawing2D;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for Plotter2d.
	/// </summary>
	public abstract class Plotter2d : Plotter, IDrawable {

		protected CartesianPlane fCartesianPlane;

		protected PointFCollection fPoints;

		protected Color [] fColors;

		protected SmoothingMode fSmoothingMode;

		protected Pen fPen;

		protected double fMinX;

		protected double fMaxX;

		public Plotter2d(CartesianPlane p) {
			this.fCartesianPlane = p;
			this.fPoints = new PointFCollection();
			this.fPen = new Pen(Color.Black,1);
			this.fSmoothingMode = SmoothingMode.HighQuality;
			this.fColors = new Color[0];
			this.fColorSetter = new SolidColorSetter();
			this.fColorSetter.pColors = new Color[]{Color.Red};
			this.fMinX = this.fCartesianPlane.pXAxis.pMin;
			this.fMaxX = this.fCartesianPlane.pXAxis.pMax;
		}

		public SmoothingMode pLineQuality {
			get {
				return this.fSmoothingMode;
			}
			set {
				if ( value == SmoothingMode.HighSpeed ||
					value == SmoothingMode.HighQuality ||
					value == SmoothingMode.AntiAlias ) {
					
					this.fSmoothingMode = value;
				}
			}
		}

		public Pen pPen {
			get {
				return this.fPen;
			}
		}

		public double pMinX {
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

		public double pMaxX {
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

		public void Draw(Graphics g) {
			if ( this.fIsVisible ) {
				if ( this.fNeedsFunctionCalculation ) {
					this.CalculateFunctionPoints();
					this.CalculateScreenPoints();
				}
				if ( this.fNeedsScreenCalculation ) {
					this.CalculateScreenPoints();
				}
				g.SmoothingMode = this.fSmoothingMode;
				GraphicsPath p = new GraphicsPath();
				p.AddRectangle(this.fCartesianPlane.pClipRectangle);
				g.SetClip(p,CombineMode.Replace);

				for ( int i = 0; i < this.fPoints.Count-1; i++ ) {
					this.fPen.Color = this.fColors[i];
					g.DrawLine(
						this.fPen,
						this.fPoints[i],
						this.fPoints[i+1]);
				}

				g.ResetClip();
			}
		}

		protected void CalculateScreenPoints() {
			this.fColors = new Color[this.fPoints.Count];
			int x = 0;
			PointFCollection pcNew = new PointFCollection();
			foreach ( PointF p in this.fPoints ) {
				this.fColorInformation = new Position2dColorInformation(new Microsoft.DirectX.Vector2(p.X,p.Y));
				this.fColors[x++] = this.fColorSetter.GetColor(this.fColorInformation);
				pcNew.Add(this.fCartesianPlane.ToScreen(p));
			}
			this.fPoints = pcNew;
			this.fNeedsScreenCalculation = false;
		}
	}
}
