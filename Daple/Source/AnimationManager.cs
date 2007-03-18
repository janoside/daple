using System.Threading;
using System.Collections;

namespace Daple.Animation {

	/// <summary>
	/// Summary description for AnimationManager.
	/// </summary>
	public class AnimationManager : TimeManager {

		protected ArrayList fSequences;

		public AnimationManager() {
			this.fTimer = new DXTimer();
			this.fTimer.Init();

			this.fCurrentTime = 0;

			this.fSequences = new ArrayList();
		}

		public void Add(Sequence s) {
			this.fSequences.Add(s);
		}

		public void Update() {
			foreach ( Sequence s in this.fSequences ) {
				s.Update(this.fCurrentTime);
			}
		}
	}
}
