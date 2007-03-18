
namespace Daple.Plotting {

	/// <summary>
	/// Extension of ArrayList for storage of AxisLabels.
	/// </summary>
	public class AxisLabelCollection : System.Collections.ArrayList {

		public new AxisLabel this[int x] {
			get {
				return (AxisLabel)base[x];
			}
		}
	}
}
