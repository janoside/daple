using System;
using System.Drawing;
using System.Windows.Forms;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for ColorSchemePreviewControl.
	/// </summary>
	public class ColorSchemePreviewControl : UserControl {

		private Color [] fColors;

		public ColorSchemePreviewControl() {
			this.fColors = new Color[1];
			this.fColors[0] = Color.White;
		}

		public void SetColors(Color [] c) {
			this.fColors = c;
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			this.Draw(e.Graphics);
		}

		private void Draw(Graphics g) {
			int h = (int)(this.Height / (float)this.fColors.Length);
			for ( int i = 0; i < this.fColors.Length-1; i++ ) {
				g.FillRectangle(
					new SolidBrush(this.fColors[i]),
					0,
					h*i,
					this.Width,
					h);
			}
			if ( this.fColors.Length > 0 ) {
				g.FillRectangle(
					new SolidBrush(this.fColors[this.fColors.Length-1]),
					0,
					h*(this.fColors.Length-1),
					this.Width,
					this.Height-h*(this.fColors.Length-1));
			}
			g.DrawRectangle(
				new Pen(Color.Black,1),
				0,
				0,
				this.Width-1,
				this.Height-1);
		}
	}
}
