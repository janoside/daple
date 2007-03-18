
namespace Daple.Animation {

	/// <summary>
	/// Summary description for TimeManager.
	/// </summary>
	public class TimeManager {

		protected DXTimer fTimer;

		protected float fCurrentTime;

		public TimeManager() {
			this.fTimer = new DXTimer();
			this.fTimer.Init();

			this.fCurrentTime = 0;
		}

		public float pTime {
			get {
				this.fCurrentTime += (float)this.fTimer.GetElapsedMilliseconds();

				return this.fCurrentTime;
			}
		}
	}
}
