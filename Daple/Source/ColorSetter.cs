
namespace Daple.Plotting {

	/// <summary>
	/// Summary description for ColorSetter.
	/// </summary>
	public abstract class ColorSetter {

		protected System.Drawing.Color [] fColors;

		public ColorSetter() {
			this.fColors = new System.Drawing.Color[3];
			this.fColors[0] = System.Drawing.Color.Red;
			this.fColors[1] = System.Drawing.Color.FromArgb(0,255,0);
			this.fColors[2] = System.Drawing.Color.Blue;
		}

		public System.Drawing.Color [] pColors {
			get {
				return this.fColors;
			}
			set {
				this.fColors = value;
			}
		}

		public abstract System.Drawing.Color GetColor(ColorInformation ci);
	}
}
