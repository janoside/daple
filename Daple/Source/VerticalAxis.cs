using System.Drawing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for VerticalAxis.
	/// </summary>
	public class VerticalAxis : Axis2d {

		public VerticalAxis(CartesianPlane p, double min, double max) : base(p,min,max) {
			this.fMajorTickLine = new HorizontalLine(10);
			this.fMinorTickLine = new HorizontalLine(2);
			this.fGridLine = new HorizontalLine(this.fLength - 2*this.fMarginSize);
			this.fHorizontalLabelFormat = AxisLabel2d.HorizontalFormat.Left;
			this.fVerticalLabelFormat = AxisLabel2d.VerticalFormat.Centered;
		}

		protected override void SetTickLineType() {
			HorizontalAxis x = this.fCartesianPlane.pXAxis;
			if ( x.pMin > 0 ) {
				this.fTickLineType = Line.Type.Right;
			} else if ( x.pMax < 0 ) {
				this.fTickLineType = Line.Type.Left;
			} else {
				this.fTickLineType = Line.Type.Center;
			}
		}

		public override void DrawGrid(Graphics g) {
			if ( this.fIsVisible && this.fIsGridDrawn ) {
				HorizontalAxis x = this.fCartesianPlane.pXAxis;
				foreach ( Point p in this.fMajorTickPoints ) {
					this.fGridLine.DrawPositioned(
						g,
						this.fGridPen,
						Line.Type.Right,
						x.pMarginSize,
						p.Y);
				}
			}
		}

		protected override void DrawMainAxis(Graphics g) {
			g.DrawLine(
				this.fPen,
				this.fCartesianPlane.pOrigin.pXPos,
				this.fMarginSize,
				this.fCartesianPlane.pOrigin.pXPos,
				this.fLength - this.fMarginSize);
		}

		protected override void CalculatePositiveTicks() {
			HorizontalAxis x = this.fCartesianPlane.pXAxis;
			if ( this.fMax > 0 ) {
				x.pVerticalLabelFormat = AxisLabel2d.VerticalFormat.Below;

				double unit = this.fUnitSize;
				double dy = this.fDivisionSize;
				int ox = this.fCartesianPlane.pOrigin.pXPos;
				int oy = this.fCartesianPlane.pOrigin.pYPos + (int)(this.fCartesianPlane.pOrigin.pYValue*unit);
				double min = this.fCartesianPlane.pYAxis.pMin;
				double max = this.fCartesianPlane.pYAxis.pMax;

				bool firstVisible = true;

				int i = 0;
				double y = 0;

				while ( y < this.fMax ) {
					if ( MathUtil.IsBetween(y, min, max) ) {
						if ( firstVisible ) {
							double yy = y;
							for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
								if ( MathUtil.IsBetween(yy, min, max) ) {
									this.fMinorTickPoints.Add(new Point(ox,(int)(oy-i*dy*unit+j*unit*dy/this.fMinorPerMajor)));
								}
								yy -= dy / this.fMinorPerMajor;
							}
							firstVisible = false;
						}
						for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
							if ( MathUtil.IsBetween(y, min, max) ) {
								this.fMinorTickPoints.Add(new Point(ox,(int)(oy-i*dy*unit-j*unit*dy/this.fMinorPerMajor)));
							}
							y += dy / this.fMinorPerMajor;
						}

						this.fMajorTickPoints.Add(new Point(ox,(int)(oy-i*dy*unit)));
						this.fLabels.Add(new AxisLabel2d(
							(float)(i*dy),
							ox,
							(int)(oy-i*dy*unit)));

					} else {
						y += dy;
					}
					i++;
				}
				System.Console.WriteLine("y=="+y+", max="+this.fMax);
				if ( y == this.fMax ) {
					this.fMajorTickPoints.Add(new Point(ox,(int)(oy-this.fMax*unit)));
					this.fLabels.Add(new AxisLabel2d(
						(float)(i*dy+this.fCartesianPlane.pOrigin.pYValue),
						ox,
						(int)(oy-this.fMax*unit)));
				}
			} else {
				x.pVerticalLabelFormat = AxisLabel2d.VerticalFormat.Above;
			}
		}

		protected override void CalculateNegativeTicks() {
			HorizontalAxis x = this.fCartesianPlane.pXAxis;
			if ( this.fMin < 0 ) {
				x.pVerticalLabelFormat = AxisLabel2d.VerticalFormat.Below;

				double unit = this.fUnitSize;
				double dy = this.fDivisionSize;
				int ox = this.fCartesianPlane.pOrigin.pXPos;
				int oy = this.fCartesianPlane.pOrigin.pYPos + (int)(this.fCartesianPlane.pOrigin.pYValue*unit);
				double min = this.fCartesianPlane.pYAxis.pMin;
				double max = this.fCartesianPlane.pYAxis.pMax;

				bool firstVisible = true;

				int i = 0;
				double y = 0;

				while ( y > this.fMin ) {
					if ( MathUtil.IsBetween(y, min, max) ) {
						if ( firstVisible ) {
							double yy = y;
							for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
								if ( MathUtil.IsBetween(yy, min, max) ) {
									this.fMinorTickPoints.Add(new Point(ox,(int)(oy+i*dy*unit-j*unit*dy/this.fMinorPerMajor)));
								}
								yy += dy / this.fMinorPerMajor;
							}
							firstVisible = false;
						}
						for ( int j = 0; j < this.fMinorPerMajor; j++ ) {
							if ( MathUtil.IsBetween(y, min, max) ) {
								this.fMinorTickPoints.Add(new Point(ox,(int)(oy+i*dy*unit+j*unit*dy/this.fMinorPerMajor)));
							}
							y -= dy / this.fMinorPerMajor;
						}

						this.fMajorTickPoints.Add(new Point(ox,(int)(oy+i*dy*unit)));
						this.fLabels.Add(new AxisLabel2d(
							(float)(-i*dy),
							ox,
							(int)(oy+i*dy*unit)));

					} else {
						y -= dy;
					}
					i++;
				}
				if ( y == this.fMin ) {
					this.fMajorTickPoints.Add(new Point(ox,(int)(oy-this.fMin*unit)));
					this.fLabels.Add(new AxisLabel2d(
						(float)(-i*dy+this.fCartesianPlane.pOrigin.pYValue),
						ox,
						(int)(oy-this.fMin*unit)));
				}
			} else {
				x.pVerticalLabelFormat = AxisLabel2d.VerticalFormat.Below;
			}
		}
	}
}
