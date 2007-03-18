
namespace Daple.Animation {

	/// <summary>
	/// Summary description for SequenceStep.
	/// </summary>
	public abstract class SequenceStep {//: IUpdatable {

		protected float fDuration,
						fCurrentTime,
						fStartTime,
						fTimeSinceLastUpdate;

		protected bool fIsContinuous;

		public SequenceStep() {
			this.fDuration = 10000;
			this.fIsContinuous = false;
		}

		public bool IsFinished() {
			return this.fCurrentTime >= this.fDuration;
		}

		public float pDuration {
			get {
				return this.fDuration;
			}
			set {
				this.fDuration = value;
			}
		}

		public void Start(float startTime) {
		//	System.Console.WriteLine("what tht sadlkjgh: "+startTime);
			this.fCurrentTime = 0;
			this.fStartTime = startTime;
			this.fTimeSinceLastUpdate = 0;
			this.Apply();
		}

		public virtual void Update(float time) {
		//	System.Console.WriteLine("hasofiashd: "+this.fCurrentTime+", "+time+", "+this.fDuration+", "+this.fStartTime);
			this.fTimeSinceLastUpdate = time - this.fCurrentTime;
			this.fCurrentTime = time - this.fStartTime;
			if ( this.fIsContinuous ) {
				this.Apply();
			}
		}

		public abstract void Apply();
	}
}
