
namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Extension of ArrayList for storage of IDrawables.
	/// </summary>
	public class DrawableCollection : System.Collections.ArrayList {

		public new IDrawable this[int x] {
			get {
				return (IDrawable)base[x];
			}
		}
	}
}
