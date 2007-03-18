
namespace Daple {

	/// <summary>
	/// Summary description for Interval.
	/// </summary>
	public class Interval {

		double fMin;

		double fMax;

		public Interval(double min, double max) {
			this.fMin = min;
			this.fMax = max;
		}

		public double pMin {
			get {
				return this.fMin;
			}
			set {
				if ( value < this.fMax ) {
					this.fMin = value;
				}
			}
		}

		public double pMax {
			get {
				return this.fMax;
			}
			set {
				if ( value > this.fMin ) {
					this.fMax = value;
				}
			}
		}
	}
}
