using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for Axis.
	/// </summary>
	public abstract class Axis2d : CartesianAxis, IDrawable {

		/// <summary>
		/// The CartesianPlane that controls the Axis.
		/// </summary>
		protected CartesianPlane fCartesianPlane;

		/// <summary>
		/// The collection of Points for the major axis
		/// divisions.
		/// </summary>
		protected PointCollection fMajorTickPoints;

		/// <summary>
		/// The collection of Points for the minor axis
		/// divisions.
		/// </summary>
		protected PointCollection fMinorTickPoints;

		/// <summary>
		/// Line used to draw the minor axis division tick marks.
		/// </summary>
		protected Line fMinorTickLine;

		/// <summary>
		/// The Line type to use when drawing axis division tick
		/// marks.
		/// </summary>
		protected Line.Type fTickLineType;

		/// <summary>
		/// The format for positioning axis labels in the x direction.
		/// </summary>
		protected AxisLabel2d.HorizontalFormat fHorizontalLabelFormat;

		/// <summary>
		/// The format for positioning axis labels in the y direction.
		/// </summary>
		protected AxisLabel2d.VerticalFormat fVerticalLabelFormat;

		/// <summary>
		/// The Pen used for the main parts of the Axis.
		/// drawing.
		/// </summary>
		protected Pen fPen;

		/// <summary>
		/// The Pen used for the Axis grid.
		/// </summary>
		protected Pen fGridPen;

		/// <summary>
		/// The Line used to draw the Axis grid.
		/// </summary>
		protected Line fGridLine;

		/// <summary>
		/// Line used to draw the major axis division tick marks.
		/// </summary>
		protected Line fMajorTickLine;

		/// <summary>
		/// Font used for the AxisLabels.
		/// </summary>
		protected Font fLabelFont;

		/// <summary>
		/// Color that the AxisLabels will be drawn with.
		/// </summary>
		protected Color fLabelColor;

		/// <summary>
		/// The length of the axis in pixels.
		/// </summary>
		protected int fLength;

		/// <summary>
		/// The size of the margin on both sides of the Axis
		/// between the sides of the associated GraphPanel.
		/// </summary>
		protected short fMarginSize;

		/// <summary>
		/// Whether or not the grid is drawn.
		/// </summary>
		protected bool fIsGridDrawn;

		/// <summary>
		/// Constructs a new Axis controlled by the specified
		/// CartesianPlane, spanning from the specified minimum
		/// to the specified maximum.
		/// </summary>
		/// <param name="p">The controlling CartesianPlane.</param>
		/// <param name="min">The minimum axis value.</param>
		/// <param name="max">The maximum axis value.</param>
		public Axis2d(CartesianPlane p, double min, double max) : base(min,max) {
			this.fCartesianPlane = p;
			this.fLabelFont = Manager.Font;
			this.fLabelColor = Color.Black;
			this.fIsGridDrawn = true;
			this.fPen = new Pen(Color.Black);
			this.fGridPen = new Pen(Color.LightGray);
			this.fLabels = new AxisLabelCollection();
			this.fMajorTickPoints = new PointCollection();
			this.fMarginSize = 40;
			this.fTickLineType = Line.Type.Center;
			this.fMinorTickPoints = new PointCollection();
			this.pLabelFontSize = 10;
			this.fLength = 100;
		}

		public Pen pPen {
			get {
				return this.fPen;
			}
		}

		public Pen pGridPen {
			get {
				return this.fGridPen;
			}
		}

		public int pLabelFontSize {
			get {
				return (int)this.fLabelFont.Size;
			}
			set {
				this.fLabelFont = new Font(this.fLabelFont.Name,value);
			}
		}

		public Color pLabelColor {
			get {
				return this.fLabelColor;
			}
			set {
				this.fLabelColor = value;
			}
		}

		public int pMarginSize {
			get {
				return this.fMarginSize;
			}
			set {
				this.fMarginSize = (short)value;
				this.fIsOutdated = true;
				this.fCartesianPlane.SetOutdated();
			}
		}
		
		public int pLength {
			get {
				return this.fLength;
			}
			set {
				if ( value > 0 ) {
					this.fLength = value;
					this.fGridLine.pLength = this.fLength - 2*this.fMarginSize;
				}
			}
		}

		public int pMinorTickLength {
			get {
				return this.fMinorTickLine.pLength;
			}
			set {
				this.fMinorTickLine.pLength = value;
			}
		}

		public int pMajorTickLength {
			get {
				return this.fMajorTickLine.pLength;
			}
			set {
				this.fMajorTickLine.pLength = value;
			}
		}

		public bool pIsGridDrawn {
			get {
				return this.fIsGridDrawn;
			}
			set {
				this.fIsGridDrawn = value;
			}
		}

		public AxisLabel2d.HorizontalFormat pHorizontalLabelFormat {
			set {
				this.fHorizontalLabelFormat = value;
			}
		}

		public AxisLabel2d.VerticalFormat pVerticalLabelFormat {
			set {
				this.fVerticalLabelFormat = value;
			}
		}

		protected override void CalculateDivisions() {
			base.CalculateDivisions();
			foreach ( AxisLabel2d al in this.fLabels ) {
				al.SetFormats(this.fHorizontalLabelFormat,this.fVerticalLabelFormat);
			}
		}

		protected void DrawLabels(Graphics g) {
			foreach ( AxisLabel2d al in this.fLabels ) {
				al.Draw(g,this.fLabelFont,this.fLabelColor);
			}
		}

		public override void SetOutdated() {
			base.SetOutdated();
			this.fCartesianPlane.SetOutdated();
		}
		
		public void Draw(Graphics g) {
			if ( this.fIsVisible ) {
				this.Update();
				this.DrawMainAxis(g);
			
				if ( this.fAreMajorTicksDrawn ) {
					this.DrawMajorTicks(g);
				}
				if ( this.fAreMinorTicksDrawn ) {
					this.DrawMinorTicks(g);
				}
				if ( this.fAreLabelsDrawn ) {
					this.DrawLabels(g);
				}
			}
		}

		protected abstract void DrawMainAxis(Graphics g);

		protected abstract void SetTickLineType();

		protected override void CalculateIncrements() {
			double range = this.fMax - this.fMin;
			this.fUnitSize = (this.fLength - 2*this.fMarginSize) / range;

			for ( int i = 0; i < CartesianAxis.Thresholds.Length; i++ ) {
				if ( range <= CartesianAxis.Thresholds[i] ) {
					this.fDivisionSize = CartesianAxis.IncrementValues[i];
					break;
				}
			}
		}

		protected void DrawMajorTicks(Graphics g) {
			foreach ( Point p in this.fMajorTickPoints ) {
				this.fMajorTickLine.DrawPositioned(g,this.fPen,this.fTickLineType,p);
			}
		}

		protected void DrawMinorTicks(Graphics g) {
			foreach ( Point p in this.fMinorTickPoints ) {
				this.fMinorTickLine.DrawPositioned(g,this.fPen,this.fTickLineType,p);
			}
		}

		public abstract void DrawGrid(Graphics g);

		public override void ForceUpdate() {
			this.fMajorTickPoints.Clear();
			this.fMinorTickPoints.Clear();
			this.fLabels.Clear();
			this.CalculateIncrements();
			this.CalculateDivisions();
			this.SetTickLineType();
			this.fIsOutdated = false;
		}
	}
}