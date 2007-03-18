using System;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for SolidColorSetter.
	/// </summary>
	public class SolidColorSetter : ColorSetter {

		public SolidColorSetter() {
		}

		public override System.Drawing.Color GetColor(ColorInformation ci) {
			return this.fColors[0];
		}
	}
}
