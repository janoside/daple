using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for CartesianPlane.
	/// </summary>
	public class CartesianPlane : IDrawable {

		protected HorizontalAxis fHorizontalAxis;

		protected VerticalAxis fVerticalAxis;

		protected PolarAxis fPolarAxis;

		protected AxisOrigin fOrigin;

		protected Brush fBackgroundBrush;

		protected Rectangle fClipRectangle;

		protected bool fIsOutdated;

		public CartesianPlane() {
			this.fHorizontalAxis = new HorizontalAxis(this,-10,10);
			this.fVerticalAxis = new VerticalAxis(this,-10,10);
			this.fPolarAxis = new PolarAxis(this);
			this.fOrigin = new AxisOrigin();
			this.SetOriginPosition();
		}

		public Rectangle pClipRectangle {
			get {
				return this.fClipRectangle;
			}
		}

		public AxisOrigin pOrigin {
			get {
				return this.fOrigin;
			}
		}

		public HorizontalAxis pXAxis {
			get {
				return this.fHorizontalAxis;
			}
		}

		public VerticalAxis pYAxis {
			get {
				return this.fVerticalAxis;
			}
		}

		public PolarAxis pPolarAxis {
			get {
				return this.fPolarAxis;
			}
		}

		public Brush pBackgroundBrush {
			get {
				return this.fBackgroundBrush;
			}
			set {
				this.fBackgroundBrush = value;
			}
		}

		public void SetOutdated() {
			this.fIsOutdated = true;
		}

		public PointF ToScreen(PointF p) {
			float x = p.X;
			float y = p.Y;

			float unitX = (float)this.fHorizontalAxis.pUnitSize;
			float unitY = (float)this.fVerticalAxis.pUnitSize;

			return new PointF(
				this.fOrigin.pXPos - this.fOrigin.pXValue*unitX + x*unitX,
				this.fOrigin.pYPos + this.fOrigin.pYValue*unitY - y*unitY);
		}

		public void Draw(Graphics g) {
			this.Update();

			this.fHorizontalAxis.DrawGrid(g);
			this.fVerticalAxis.DrawGrid(g);
			this.fPolarAxis.DrawGrid(g);

			this.fHorizontalAxis.Draw(g);
			this.fVerticalAxis.Draw(g);
			this.fPolarAxis.Draw(g);
		}

		private void CalculateClipRectangle() {
			this.fClipRectangle = new Rectangle(
				this.fHorizontalAxis.pMarginSize,
				this.fVerticalAxis.pMarginSize,
				this.fHorizontalAxis.pLength - 2*this.fHorizontalAxis.pMarginSize,
				this.fVerticalAxis.pLength - 2*this.fVerticalAxis.pMarginSize);
		}

		public void SetPlotBounds(int w, int h) {
			this.fHorizontalAxis.pLength = w;
			this.fVerticalAxis.pLength = h;

			this.fHorizontalAxis.Update();
			this.fVerticalAxis.Update();
		//	this.fPolarAxis.Update();

			this.SetOriginPosition();

			this.fHorizontalAxis.ForceUpdate();
			this.fVerticalAxis.ForceUpdate();
		//	this.fPolarAxis.ForceUpdate();

			this.CalculateClipRectangle();
		}

		public void SetOriginPosition() {
			int xMargin = this.fHorizontalAxis.pMarginSize;
			int yMargin = this.fVerticalAxis.pMarginSize;

			double x0 = this.fHorizontalAxis.pMin;
			double x1 = this.fHorizontalAxis.pMax;
			double y0 = this.fVerticalAxis.pMin;
			double y1 = this.fVerticalAxis.pMax;

			int x = (int)(-x0*this.fHorizontalAxis.pUnitSize) + xMargin;
			int y = (int)( y1*this.fVerticalAxis.pUnitSize) + yMargin;

			if ( x < xMargin ) {
				x = xMargin;
				this.fOrigin.pXValue = (float)x0;
			} else if ( x > this.fHorizontalAxis.pLength - xMargin ) {
				x = this.fHorizontalAxis.pLength - xMargin;
				this.fOrigin.pXValue = (float)x1;
			}

			if ( y < yMargin ) {
				y = yMargin;
				this.fOrigin.pYValue = (float)y1;
				System.Console.WriteLine("here="+y1);
			} else if ( y > this.fVerticalAxis.pLength - yMargin ) {
				y = this.fVerticalAxis.pLength - yMargin;
				this.fOrigin.pYValue = (float)y0;
				System.Console.WriteLine("there="+y0+", y="+y);
			}

			this.fOrigin.pXPos = x;
			this.fOrigin.pYPos = y;
		}

		public void Update() {
			if ( this.fIsOutdated ) {
				this.SetPlotBounds(
					this.fHorizontalAxis.pLength,
					this.fVerticalAxis.pLength);
			}
		}
	}
}
