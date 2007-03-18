using System;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for PlotterCollection.
	/// </summary>
	public class PlotterCollection : System.Collections.ArrayList {

		public new IPlottable this[int x] {
			get {
				return (IPlottable)base[x];
			}
		}
	}
}
