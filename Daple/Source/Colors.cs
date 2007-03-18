using System.Drawing;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for Colors.
	/// </summary>
	public class Colors {

		public static readonly Color [] Rainbow = {Color.Purple,Color.Blue,Color.FromArgb(0,200,0),Color.Yellow,Color.Orange,Color.Red};
		public static readonly Color [] Stripes = {Color.White,Color.Black,Color.White,Color.Black,Color.White,Color.Black,Color.White,Color.Black,Color.White,Color.Black,Color.White,Color.Black,Color.White,Color.Black,Color.White};
		public static readonly Color [] America = {Color.Blue,Color.White,Color.Red};
		public static readonly Color [] BlackWhite = {Color.Black,Color.White};
		public static readonly Color [] RGB = {Color.Blue,Color.FromArgb(0,255,0),Color.Red};
		public static readonly Color [] Tips = {Color.White,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.White};

		private static readonly int [] RedValues = {227,220,212,205,200,192,185,178,171,164,157,151,144,137,130,122,115,108,101,95,88,81,74,67,60,52,45,40,32,25,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,25,32,40,45,52,60,67,74,81,88,95,101,108,115,122,130,137,144,151,157,164,171,178,185,192,200,205,212,220,227,234,241,248,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255};
		private static readonly int [] BlueValues = {18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,25,32,40,45,52,60,67,74,81,88,95,101,108,115,122,130,137,144,151,157,164,171,178,185,192,200,205,212,220,227,234,241,248,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,248,241,234,227,220,212,205,200,192,185,178,171,164,157,151,144,137,130,122,115,108,101,95,88,81,74,67,60,52,45,40,32,25};
		private static readonly int [] GreenValues = {255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,248,241,234,227,220,212,205,200,192,185,178,171,164,157,151,144,137,130,122,115,108,101,95,88,81,74,67,60,52,45,40,32,25,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18};

		public static Color Hue(float percent) {
			int x = (int)(Colors.RedValues.Length*percent);
			if ( x < 0 ) {
				x = 0;
			} else if ( x > Colors.RedValues.Length ) {
				x = Colors.RedValues.Length;
			}
			try {
				return Color.FromArgb(
					Colors.RedValues[x],
					Colors.GreenValues[x],
					Colors.BlueValues[x]);
			} catch ( System.Exception ) {
				return Color.White;
			}
		}

		public static Color Lerp(System.Collections.ArrayList a, float percent) {
			Color [] c = new Color[a.Count];
			for ( int i = 0; i < a.Count; i++ ) {
				c[i] = (Color)a[i];
			}
			return Colors.Lerp(c,percent);
		}

		public static Color RainbowColor(float percent) {
			return Colors.Lerp(Colors.Rainbow,1-percent);
		}

		public static Color StripesColor(float percent) {
			return Colors.Lerp(Colors.Stripes,percent);
		}

		public static Color Opposite(Color c) {
			return Color.FromArgb(255-c.R,255-c.G,255-c.B);
		}

		public static Color Lerp(Color [] colors, float percent) {
			if ( colors.Length == 1 ) {
				return colors[0];
			}
			if ( percent < 0 ) {
				return colors[0];
			} else if ( percent > 1 ) {
				return colors[colors.Length-1];
			}
			Color c0 = Color.Red;
			Color c1 = Color.Orange;

			int r = 0;
			int g = 0;
			int b = 0;

			int index = 0;
			float x = 0;
			float divide = 1.0f / (colors.Length-1);
			for ( int i = 0; i < colors.Length-1; i++ ) {
				if ( percent > x && percent < x + divide ) {
					c0 = colors[i];
					c1 = colors[i+1];
					break;
				}
				x += divide;
				index++;
			}
			x = (percent-index*divide)/divide;

			r = (int)(c0.R*(1-x) + c1.R*x);
			g = (int)(c0.G*(1-x) + c1.G*x);
			b = (int)(c0.B*(1-x) + c1.B*x);

			try {
				return Color.FromArgb(r,g,b);
			} catch ( System.ArgumentException ) {
				//System.Console.WriteLine("x="+x);
				return Color.White;
			}
		}
	}
}
