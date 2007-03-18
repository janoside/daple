using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for VerticalLine.
	/// </summary>
	public class VerticalLine : Line {

		public VerticalLine() : base() {
		}

		public VerticalLine(int len) : base(len) {
		}

		public override void DrawPositioned(Graphics g, Pen p, Line.Type t, int x, int y) {
			switch ( t ) {
				case Line.Type.Up:
					g.DrawLine(
						p,
						x,
						y,
						x,
						y - this.fLength);
					break;
				case Line.Type.Down:
					g.DrawLine(
						p,
						x,
						y,
						x,
						y + this.fLength);
					break;
				case Line.Type.Center:
					g.DrawLine(
						p,
						x,
						y - this.fLength / 2,
						x,
						y + this.fLength / 2);
					break;
				default:
					this.DrawPositioned(g,p,Line.Type.Down,x,y);
					break;
			}
		}
	}
}
