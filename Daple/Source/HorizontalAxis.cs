using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for XAxis.
	/// </summary>
	public class HorizontalAxis : Axis2d {

		public HorizontalAxis(CartesianPlane p, double min, double max) : base(p,min,max) {
			this.fMajorTickLine = new VerticalLine(10);
			this.fMinorTickLine = new VerticalLine(2);
			this.fGridLine = new VerticalLine(this.fLength - 2*this.fMarginSize);
			this.fHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Centered;
			this.fVerticalLabelFormat = AxisLabel2d.VerticalFormat.Below;
		}

		protected override void DrawMainAxis(Graphics g) {
			g.DrawLine(
				this.fPen,
				this.fMarginSize,
				this.fCartesianPlane.pOrigin.pYPos,
				this.fLength - this.fMarginSize,
				this.fCartesianPlane.pOrigin.pYPos);
		}

		public override void DrawGrid(Graphics g) {
			if ( this.fIsVisible && this.fIsGridDrawn ) {
				VerticalAxis y = this.fCartesianPlane.pYAxis;
				foreach ( Point p in this.fMajorTickPoints ) {
					this.fGridLine.DrawPositioned(
						g,
						this.fGridPen,
						Line.Type.Down,
						p.X,
						y.pMarginSize);
				}
			}
		}

		protected override void SetTickLineType() {
			VerticalAxis y = this.fCartesianPlane.pYAxis;
			if ( y.pMin > 0 ) {
				this.fTickLineType = Line.Type.Up;
			} else if ( y.pMax < 0 ) {
				this.fTickLineType = Line.Type.Down;
			} else {
				this.fTickLineType = Line.Type.Center;
			}
		}

		protected override void CalculatePositiveTicks() {
			VerticalAxis y = this.fCartesianPlane.pYAxis;
			if ( this.fMax > 0 ) {
				y.pHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Left;

				double unit = this.fUnitSize;
				double dx = this.fDivisionSize;
				int ox = this.fCartesianPlane.pOrigin.pXPos - (int)(this.fCartesianPlane.pOrigin.pXValue*unit);
				int oy = this.fCartesianPlane.pOrigin.pYPos;
				double min = this.fCartesianPlane.pXAxis.pMin;
				double max = this.fCartesianPlane.pXAxis.pMax;

				bool firstVisible = true;

				int i = 0;
				double x = 0;

				while ( x < this.fMax ) {
					if ( MathUtil.IsBetween(x, min, max) ) {
						if ( firstVisible ) {
							double xx = x;
							for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
								if ( MathUtil.IsBetween(xx, min, max) ) {
									this.fMinorTickPoints.Add(new Point((int)(ox+i*dx*unit-j*unit*dx/this.fMinorPerMajor),oy));
								}
								xx -= dx / this.fMinorPerMajor;
							}
							firstVisible = false;
						}
						for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
							if ( MathUtil.IsBetween(x, min, max) ) {
								this.fMinorTickPoints.Add(new Point((int)(ox+i*dx*unit+j*unit*dx/this.fMinorPerMajor),oy));
							}
							x += dx / this.fMinorPerMajor;
						}

						this.fMajorTickPoints.Add(new Point((int)(ox+i*dx*unit),oy));
						this.fLabels.Add(new AxisLabel2d(
							(float)(i*dx),
							(int)(ox+i*dx*unit),
							oy));

					} else {
						x += dx;
					}
					i++;
				}
				if ( x == this.fMin ) {
					this.fMajorTickPoints.Add(new Point((int)(ox+i*dx*unit),oy));
					this.fLabels.Add(new AxisLabel2d(
						(float)(i*dx+this.fCartesianPlane.pOrigin.pXValue),
						(int)(ox+i*dx*unit),
						oy));
				}
			} else {
				y.pHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Right;
			}
		}

		protected override void CalculateNegativeTicks() {
			VerticalAxis y = this.fCartesianPlane.pYAxis;
			if ( this.fMin < 0 ) {
				y.pHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Left;

				double unit = this.fUnitSize;
				double dx = this.fDivisionSize;
				int ox = this.fCartesianPlane.pOrigin.pXPos - (int)(this.fCartesianPlane.pOrigin.pXValue*unit);
				int oy = this.fCartesianPlane.pOrigin.pYPos;
				double min = this.fCartesianPlane.pXAxis.pMin;
				double max = this.fCartesianPlane.pXAxis.pMax;

				bool firstVisible = true;

				int i = 0;
				double x = 0;

				while ( x > this.fMin ) {
					if ( MathUtil.IsBetween(x, min, max) ) {
						if ( firstVisible ) {
							double xx = x;
							for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
								if ( MathUtil.IsBetween(xx, min, max) ) {
									this.fMinorTickPoints.Add(new Point((int)(ox-i*dx*unit+j*unit*dx/this.fMinorPerMajor),oy));
								}
								xx += dx / this.fMinorPerMajor;
							}
							firstVisible = false;
						}
						for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
							if ( MathUtil.IsBetween(x, min, max) ) {
								this.fMinorTickPoints.Add(new Point((int)(ox-i*dx*unit-j*unit*dx/this.fMinorPerMajor),oy));
							}
							x -= dx / this.fMinorPerMajor;
						}

						this.fMajorTickPoints.Add(new Point((int)(ox-i*dx*unit),oy));
						this.fLabels.Add(new AxisLabel2d(
							(float)(-i*dx),
							(int)(ox-i*dx*unit),
							oy));

					} else {
						x -= dx;
					}
					i++;
				}
				if ( x == this.fMin ) {
					this.fMajorTickPoints.Add(new Point((int)(ox-i*dx*unit),oy));
					this.fLabels.Add(new AxisLabel2d(
						(float)(-i*dx+this.fCartesianPlane.pOrigin.pXValue),
						(int)(ox-i*dx*unit),
						oy));
				}
			} else {
				y.pHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Left;
			}
		}
	}
}
