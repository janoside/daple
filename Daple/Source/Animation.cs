using Daple.Plotting;

namespace Daple.Animation {

	/// <summary>
	/// Summary description for Animation.
	/// </summary>
	public class Animation : Sequence {

		protected Interval fInterval;

		protected int fNumberOfSteps;

		public Animation(GraphPanel p, TimeManager tm) : base(p,tm) {
			this.fInterval = new Interval(-10,10);
			this.fNumberOfSteps = 15;
		}

		public Interval pInterval {
			get {
				return this.fInterval;
			}
		}
	}
}
