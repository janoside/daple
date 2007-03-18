using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for HorizontalLine.
	/// </summary>
	public class HorizontalLine : Line {

		public HorizontalLine() : base() {
		}

		public HorizontalLine(int len) : base(len) {
		}

		public override void DrawPositioned(Graphics g, Pen p, Line.Type t, int x, int y) {
			switch ( t ) {
				case Line.Type.Left:
					g.DrawLine(
						p,
						x,
						y,
						x - this.fLength,
						y);
					break;
				case Line.Type.Right:
					g.DrawLine(
						p,
						x,
						y,
						x + this.fLength,
						y);
					break;
				case Line.Type.Center:
					g.DrawLine(
						p,
						x - this.fLength / 2,
						y,
						x + this.fLength / 2,
						y);
					break;
				default:
					this.DrawPositioned(g,p,Line.Type.Right,x,y);
					break;
			}
		}
	}
}
