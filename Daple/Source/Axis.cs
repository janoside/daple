using System.Drawing;

namespace Daple.Plotting {

	/// <summary>
	/// Abstract base class for all types of axes.
	/// </summary>
	public abstract class Axis {

		/// <summary>
		/// Collection for the labels on the Axis.
		/// </summary>
		protected AxisLabelCollection fLabels;

		/// <summary>
		/// The minimum mathematical value that the Axis
		/// will display.
		/// </summary>
		protected double fMin;

		/// <summary>
		/// The maximum mathematical value that the Axis
		/// will display.
		/// </summary>
		protected double fMax;

		/// <summary>
		/// Whether or not the Axis needs to be Updated.
		/// </summary>
		protected bool fIsOutdated;

		/// <summary>
		/// Whether or not the Axis labels are drawn.
		/// </summary>
		protected bool fAreLabelsDrawn;

		/// <summary>
		/// Whether or not the Axis is visible.
		/// </summary>
		protected bool fIsVisible;

		/// <summary>
		/// Constructs a new Axis controlled by the specified
		/// CartesianPlane, spanning from the specified minimum
		/// to the specified maximum.
		/// </summary>
		/// <param name="p">The controlling CartesianPlane.</param>
		/// <param name="min">The minimum axis value.</param>
		/// <param name="max">The maximum axis value.</param>
		public Axis(double min, double max) {
			this.fMin = min;
			this.fMax = max;
			this.fIsOutdated = true;
			this.fAreLabelsDrawn = true;
			this.fIsVisible = true;
			this.fLabels = new AxisLabelCollection();
		}

		public double pMin {
			get {
				return this.fMin;
			}
			set {
				if ( value < this.fMax ) {
					this.fMin = value;
				}
				this.SetOutdated();
			}
		}

		public double pMax {
			get {
				return this.fMax;
			}
			set {
				if ( value > this.fMin ) {
					this.fMax = value;
				}
				this.SetOutdated();
			}
		}

		public bool pIsVisible {
			get {
				return this.fIsVisible;
			}
			set {
				this.fIsVisible = value;
			}
		}

		public bool pAreLabelsDrawn {
			get {
				return this.fAreLabelsDrawn;
			}
			set {
				this.fAreLabelsDrawn = value;
			}
		}

		public virtual void SetOutdated() {
			this.fIsOutdated = true;
		}

		public abstract void ForceUpdate();

		public void Update() {
			if ( this.fIsOutdated ) {
				this.ForceUpdate();
			}
		}
	}
}
