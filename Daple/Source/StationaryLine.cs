using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for StationaryLine.
	/// </summary>
	public class StationaryLine : Line {

		protected Point fPosition;

		public StationaryLine() {
			this.fPosition = new Point(0,0);
		}

		public Point pPosition {
			get {
				return this.fPosition;
			}
			set {
				this.fPosition = value;
			}
		}

		public override void DrawPositioned(Graphics g, Pen p, Line.Type t, int x, int y) {
			g.DrawLine(
				p,
				this.fPosition.X,
				this.fPosition.Y,
				x,
				y);
		}
	}
}
