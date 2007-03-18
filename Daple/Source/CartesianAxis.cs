using System.Drawing;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for Axis.
	/// </summary>
	public abstract class CartesianAxis : Axis {

		protected static readonly double [] IncrementValues = {   0.0001, 0.0002, 0.0005, 0.001,   0.002,  0.005,  
																  0.01,   0.02,  0.05,  0.1,   0.2, 0.5, 
																  1, 2,  5,  10, 20,  50,  
																  100, 200,  500, 1000, 2000, 5000, 
																  10000, 20000, 50000, 100000, 200000, 500000, 
																  1000000, 2000000, 5000000, 10000000, 20000000, 50000000};

		protected static readonly double [] Thresholds =      {   0.0008, 0.002,  0.004,  0.00801, 0.0201, 0.0401, 
																  0.0801, 0.201, 0.401, 0.801, 2,   4,   
																  8, 20, 40, 80, 200, 400, 
																  800, 2000, 4000, 8000, 20000, 40000, 
																  80000, 200000, 400000, 800000, 2000000, 4000000,
																  8000000, 20000000, 40000000, 80000000};

		/// <summary>
		/// An approximate value for the number of pixels
		/// that span a length of 1 (one) on the Axis.
		/// </summary>
		protected double fUnitSize;

		/// <summary>
		/// The mathematical length in graph units (not pixels)
		/// of each divison along the Axis.
		/// </summary>
		protected double fDivisionSize;

		/// <summary>
		/// The number of subdivisions within each major axis division.
		/// </summary>
		protected int fMinorPerMajor;

		/// <summary>
		/// Whether or not the major axis division marks 
		/// are drawn.
		/// </summary>
		protected bool fAreMajorTicksDrawn;

		/// <summary>
		/// Whether or not the minor axis division marks 
		/// are drawn between the major axis divisions.
		/// </summary>
		protected bool fAreMinorTicksDrawn;

		/// <summary>
		/// Constructs a new Axis controlled by the specified
		/// CartesianPlane, spanning from the specified minimum
		/// to the specified maximum.
		/// </summary>
		/// <param name="p">The controlling CartesianPlane.</param>
		/// <param name="min">The minimum axis value.</param>
		/// <param name="max">The maximum axis value.</param>
		public CartesianAxis(double min, double max) : base(min,max) {
			this.fAreMajorTicksDrawn = true;
			this.fAreMinorTicksDrawn = true;
			this.fMinorPerMajor = 5;
		}

		public double pDivisionSize {
			get {
				return this.fDivisionSize;
			}
		}

		public double pUnitSize {
			get {
				return this.fUnitSize;
			}
		}

		public int pMinorPerMajor {
			get {
				return this.fMinorPerMajor;
			}
			set {
				if ( value >= 0 ) {
					this.fMinorPerMajor = value;
				}
			}
		}

		public bool pAreMajorTicksDrawn {
			get {
				return this.fAreMajorTicksDrawn;
			}
			set {
				this.fAreMajorTicksDrawn = value;
			}
		}

		public bool pAreMinorTicksDrawn {
			get {
				return this.fAreMinorTicksDrawn;
			}
			set {
				this.fAreMinorTicksDrawn = value;
			}
		}

		

	//	public abstract void Draw(Graphics g);

	//	protected abstract void DrawTicks(Graphics g);

		protected virtual void CalculateDivisions() {
			this.CalculatePositiveTicks();
			this.CalculateNegativeTicks();
		}

	//	protected abstract void DrawMainAxis(Graphics g);

		protected abstract void CalculatePositiveTicks();

		protected abstract void CalculateNegativeTicks();

	//	protected abstract void SetTickLineType();

		/// <summary>
		/// Method that automatically calculates the axis 'unit size',
		/// that is, the (approximate) size in pixels that one
		/// mathematical unit spans on the screen.  Using this value,
		/// the Axis will choose the axis division that is most 
		/// appropriate based on a set of pre-defined threshold values.
		/// </summary>
		protected abstract void CalculateIncrements();

		public override void ForceUpdate() {
			this.fLabels.Clear();
			this.CalculateIncrements();
			this.CalculateDivisions();
			this.fIsOutdated = false;
		}
	}
}