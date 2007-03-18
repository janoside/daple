using System.Drawing;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for AxisLabel.
	/// </summary>
	public abstract class AxisLabel {

		public static Font Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

		protected float fValue;

		protected int fXPosition;

		protected int fYPosition;

		public AxisLabel() {
		}

		public AxisLabel(float val, int x, int y) {
			this.fValue = val;
			this.fXPosition = x;
			this.fYPosition = y;
		}

		public float pValue {
			get {
				return this.fValue;
			}
			set {
				this.fValue = value;
			}
		}
	}
}
