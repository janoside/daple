using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for Line.
	/// </summary>
	public abstract class Line {

		protected static Pen DefaultPen = new Pen(Color.Black);

		public enum Type {
			Left,
			Right,
			Up,
			Down,
			Center
		};

		protected int fLength;

		public Line(int length) {
			this.fLength = length;
		}
		
		public Line() : this(25) {
		}

		public int pLength {
			get {
				return this.fLength;
			}
			set {
				this.fLength = value;
			}
		}

		public abstract void DrawPositioned(Graphics g, Pen p, Line.Type t, int x, int y);

		public void DrawPositioned(Graphics g, Pen pen, Line.Type t, Point p) {
			this.DrawPositioned(g,pen,t,p.X,p.Y);
		}
	}
}
