using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for AxisLabel.
	/// </summary>
	public class AxisLabel2d : AxisLabel {

		public enum VerticalFormat {
			Above,
			Below,
			Centered
		};

		public enum HorizontalFormat {
			Right,
			Left,
			Centered
		};

		protected static readonly int Correction = 3;

		protected static Brush Brush = new SolidBrush(Color.Black);

		/// <summary>
		/// Value used to center the AxisLabel on the
		/// axis position desired.
		/// </summary>
		protected int fXCorrection;

		/// <summary>
		/// Value used to center the AxisLabel on the 
		/// axis position desired.
		/// </summary>
		protected int fYCorrection;

		public AxisLabel2d() {
		}

		public AxisLabel2d(float val, int x, int y) : base(val,x,y) {
			this.fXCorrection = 0;
			this.fYCorrection = 0;
		}

		public void SetFormats(AxisLabel2d.HorizontalFormat hf, AxisLabel2d.VerticalFormat vf) {
			int x = 10*this.fValue.ToString().Length;
			int y = AxisLabel.Font.Height;

			switch ( hf ) {
				case AxisLabel2d.HorizontalFormat.Left:
					this.fXCorrection = -x - AxisLabel2d.Correction;
					break;
				case AxisLabel2d.HorizontalFormat.Right:
					this.fXCorrection = AxisLabel2d.Correction;
					break;
				case AxisLabel2d.HorizontalFormat.Centered:
					this.fXCorrection = -x/2;
					break;
			}

			switch ( vf ) {
				case AxisLabel2d.VerticalFormat.Above:
					this.fYCorrection = -y - AxisLabel2d.Correction;
					break;
				case AxisLabel2d.VerticalFormat.Below:
					this.fYCorrection = AxisLabel2d.Correction;
					break;
				case AxisLabel2d.VerticalFormat.Centered:
					this.fYCorrection = -y/2;
					break;
			}
		}

		public void Draw(Graphics g, Font f, Color c) {
			g.DrawString(
				this.fValue.ToString(),
				f,
				new SolidBrush(c),
				this.fXPosition + this.fXCorrection,
				this.fYPosition + this.fYCorrection);
		}
	}
}