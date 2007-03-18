using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// This is actually not the origin of the coordinate
	/// system.  It is merely the screen coordinates of the
	/// intersection of the x and y axes.  If either the x
	/// or the y axis does not span through zero (i.e. the min
	/// and max have the same sign), the AxisOrigin will not be
	/// the true origin but merely a graphical placeholder.
	/// </summary>
	public class AxisOrigin {
		
		/// <summary>
		/// The actual screen coordinates of the quasi-origin.
		/// </summary>
		private Point fPoint;

		/// <summary>
		/// The mathematical value of this actual point.  If the
		/// AxisOrigin is the real coordinate system origin, this
		/// is Point(0,0), otherwise it keeps track of the actual
		/// location.
		/// </summary>
		private PointF fValue;

		public AxisOrigin() {
			this.fPoint = new Point(0,0);
			this.fValue = new PointF(0,0);
		}

		public static implicit operator System.Drawing.Point (AxisOrigin o) {
			return o.fPoint;
		}

		public int pXPos {
			get {
				return this.fPoint.X;
			}
			set {
				this.fPoint.X = value;
			}
		}

		public int pYPos {
			get {
				return this.fPoint.Y;
			}
			set {
				this.fPoint.Y = value;
			}
		}

		public float pXValue {
			get {
				return this.fValue.X;
			}
			set {
				this.fValue.X = value;
			}
		}

		public float pYValue {
			get {
				return this.fValue.Y;
			}
			set {
				this.fValue.Y = value;
			}
		}
	}
}
