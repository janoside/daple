using System.Drawing;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for IPlottable.
	/// </summary>
	public interface IPlottable {
		
		void Plot(Graphics g);

		void SetPlotBounds(int w, int h);
	}
}
