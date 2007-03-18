using System.Drawing;

using Daple.Expressions;
using Daple.Animation;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for Plotter.
	/// </summary>
	public abstract class Plotter : SequenceStep {

		protected Expression fExpression;

		protected ColorSetter fColorSetter;

		protected ColorInformation fColorInformation;

		protected int fNumberXPoints;

		protected bool fNeedsFunctionCalculation;

		protected bool fNeedsScreenCalculation;

		protected bool fIsVisible;

		protected bool fIsAxisLockedBounds;

		public Plotter() {
			this.fExpression = null;
			this.fNeedsFunctionCalculation = true;
			this.fNeedsScreenCalculation = true;
			this.fIsVisible = true;
			this.fIsAxisLockedBounds = true;
			this.fNumberXPoints = 200;
			this.fDuration = 100;
		}

		public void Invalidate() {
			this.fNeedsFunctionCalculation = true;
			this.fNeedsScreenCalculation = true;
		}

		protected abstract void UpdateFromAxis();

		public ColorSetter pColorSetter {
			get {
				return this.fColorSetter;
			}
			set {
				this.fColorSetter = value;
			}
		}

		public Expression pExpression {
			get {
				return this.fExpression;
			}
			set {
				this.fExpression = value;
				this.fNeedsFunctionCalculation = true;
			}
		}

		public int pXPoints {
			get {
				return this.fNumberXPoints;
			}
			set {
				if ( value > 0 ) {
					this.fNumberXPoints = value;
					this.fNeedsFunctionCalculation = true;
					this.fNeedsScreenCalculation = true;
				}
			}
		}

		public bool pIsAxisLockedBounds {
			get {
				return this.fIsAxisLockedBounds;
			}
			set {
				this.fIsAxisLockedBounds = value;
				if ( this.fIsAxisLockedBounds ) {
					this.UpdateFromAxis();
				}
			}
		}

		public bool pIsVisible {
			get {
				return this.fIsVisible;
			}
			set {
				this.fIsVisible = value;
			}
		}

		public override void Apply() {

		}

		protected abstract void CalculateFunctionPoints();
	}
}
