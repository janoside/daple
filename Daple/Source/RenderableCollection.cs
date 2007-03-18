
namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for RenderableCollection.
	/// </summary>
	public class RenderableCollection : System.Collections.ArrayList {

		public new IRenderable this[int x] {
			get {
				return (IRenderable)base[x];
			}
		}
	}
}
