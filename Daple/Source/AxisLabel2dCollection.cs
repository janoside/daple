
namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for AxisLabel2dCollection.
	/// </summary>
	public class AxisLabel2dCollection : AxisLabelCollection {

		public new AxisLabel2d this[int x] {
			get {
				return (AxisLabel2d)base[x];
			}
		}
	}
}
