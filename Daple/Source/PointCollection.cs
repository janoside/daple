using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Extension of ArrayList for storage of Points.
	/// </summary>
	public class PointCollection : System.Collections.ArrayList {

		public new Point this[int x] {
			get {
				return (Point)base[x];
			}
		}
	}
}
