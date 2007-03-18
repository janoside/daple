using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Extension of ArrayList for storage of Points.
	/// </summary>
	public class PointFCollection : System.Collections.ArrayList {

		public new PointF this[int x] {
			get {
				return (PointF)base[x];
			}
		}
	}
}
