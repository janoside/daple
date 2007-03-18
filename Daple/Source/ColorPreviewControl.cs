using System;
using System.Drawing;
using System.Windows.Forms;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for ColorPreviewControl.
	/// </summary>
	public class ColorPreviewControl : UserControl {

		public ColorPreviewControl() {
			this.BackColor = Color.White;
		}

		public void SetColor(int r, int g, int b) {
			this.BackColor = Color.FromArgb(r,g,b);
		}
	}
}
