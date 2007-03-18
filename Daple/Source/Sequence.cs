using System.Threading;

using Daple.Plotting;

namespace Daple.Animation {

	/// <summary>
	/// Summary description for Sequence.
	/// </summary>
	public class Sequence {

		protected Thread fThread;

		protected TimeManager fTimeManager;

		protected SequenceStepCollection fSteps;

		protected GraphPanel fGraphPanel;

		protected float fCurrentTime;

		protected int fIndex;

		protected bool fIsForwardAdvancing,
					   fIsContinuous,
					   fIsWrapping,
					   fIsActive;

		public Sequence(GraphPanel p, TimeManager tm) {
			this.fGraphPanel = p;
			this.fTimeManager = tm;
			this.fSteps = new SequenceStepCollection();
			this.fIsForwardAdvancing = true;
			this.fIsContinuous = true;
			this.fIsWrapping = true;
			this.fIsActive = false;
			this.fCurrentTime = 0;
			this.fThread = new Thread(new ThreadStart(this.Run));
		}

		public void Start(float time) {
			this.fCurrentTime = 0;
			this.fIndex = 0;
			this.fIsActive = true;
			this.fSteps[0].Start(time);
		}

		public void Add(SequenceStep s) {
			this.fSteps.Add(s);
		}

		public void Remove(SequenceStep s) {
			this.fSteps.Remove(s);
		}

		public void Clear() {
			this.fSteps.Clear();
		}

		public void Run() {
			this.fIsActive = true;
			this.Start(this.fTimeManager.pTime);
			while ( true ) {
				this.Update(this.fTimeManager.pTime);
			//	Thread.Sleep(20);
			//	this.fGraphPanel.Invalidate();
			}
		}

		public virtual void Update(float time) {
			if ( this.fIsActive ) {
				this.fSteps[this.fIndex].Update(time);
				if ( this.fSteps[this.fIndex].IsFinished() ) {
					this.Advance();
				//	System.Console.WriteLine((decimal)time);
			//		this.fGraphPanel.Invalidate();
				}
				this.fCurrentTime = time;
			}
		}

		public virtual void Advance() {
			if ( this.fIsForwardAdvancing ) {
				this.fIndex++;
			} else {
				this.fIndex--;
			}
			if ( this.fIndex == this.fSteps.Count ) {
				if ( this.fIsContinuous ) {
					if ( this.fIsWrapping ) {
						this.fIndex = 0;
					} else {
						this.fIsForwardAdvancing = !this.fIsForwardAdvancing;
						this.fIndex = this.fIndex - 2;
					}
				} else {
					this.fIsActive = false;
					return;
				}
			} else if ( this.fIndex == -1 ) {
				if ( this.fIsContinuous ) {
					if ( this.fIsWrapping ) {
						this.fIndex = this.fSteps.Count - 1;
					} else {
						this.fIsForwardAdvancing = !this.fIsForwardAdvancing;
						this.fIndex = 1;
					}
				} else {
					this.fIsActive = false;
					return;
				}
			}
			this.fSteps[this.fIndex].Start(this.fCurrentTime);
		}

		public void Flip() {
			this.fIsForwardAdvancing = !this.fIsForwardAdvancing;
		}
	}
}