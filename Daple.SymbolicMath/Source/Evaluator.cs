using System;

namespace Daple.Expressions {

	/// <summary>
	/// Summary description for Evaluator.
	/// </summary>
	public class Evaluator {

		protected Expression fExpression;

		public Evaluator() {
			this.fExpression = new Expression("0");
		}

		public Evaluator(Expression e) {
			this.fExpression = e;
		}

		public Expression pExpression {
			set {
				this.fExpression = value;
			}
		}

		#region Minimum Calculations

		/// <summary>
		/// Returns the minimum value of the stored Expression
		/// over the interval specified by the min and max values.
		/// This may not find the actual minimum (or even a close
		/// approximation) because the Expression is only evaluated
		/// at evenly spaced points along the interval which may not
		/// pass through a point of extreme downward slope.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <param name="steps">The number of points to calculate.</param>
		/// <returns>The minimum of the calculated values.</returns>
		public double Min(double min, double max, int steps) {
			double Min = Double.MaxValue;
			double x = min;
			double val = 0;
			while ( x <= max ) {
				val = this.fExpression.Evaluate(x);
				if ( val < Min ) {
					Min = val;
				}
				x += (max-min) / (double)steps;
			}
			return Min;
		}

		/// <summary>
		/// Returns the minimum value of the stored Expression
		/// over the interval specified by the min and max values
		/// using 100 calculation points.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <returns>The minimum of the calculated values.</returns>
		public double Min(double min, double max) {
			return this.Min(min,max,100);
		}

		/// <summary>
		/// Returns the minimum value of the stored Expression
		/// over the region specified by the min and max values.
		/// This may not find the actual minimum (or even a close
		/// approximation) because the Expression is only evaluated
		/// at evenly spaced points inside the region which may not
		/// pass through a point of extreme downward slope.
		/// </summary>
		/// <param name="minX">The minimum 'x' value.</param>
		/// <param name="maxX">The maximum 'x' value.</param>
		/// <param name="minY">The minimum 'y' value.</param>
		/// <param name="maxY">The maximum 'y' value.</param>
		/// <param name="xSteps">The number of divisions along the 'x' axis.</param>
		/// <param name="ySteps">The number of divisions along the 'y' axis.</param>
		/// <returns>The minimum of the calculated values.</returns>
		public double Min(double minX, double maxX, double minY, double maxY, int xSteps, int ySteps) {
			double xValue = minX;
			double yValue = minY;
			double minValue = Double.MaxValue;
			double evaluation = 0;
			double xStep = (maxX-minX) / (double)xSteps;
			double yStep = (maxY-minY) / (double)ySteps;
		
			while ( xValue < maxX ) {
				while ( yValue < maxY ) {
					evaluation = this.fExpression.Evaluate(xValue,yValue);
					if ( evaluation < minValue ) {
						minValue = evaluation;	
					}
					yValue += yStep;
				}
				xValue += xStep;
				yValue  = minY;
			}
			return minValue;	
		}

		/// <summary>
		/// Returns the minimum value of the stored Expression
		/// over the region specified by the min and max values
		/// using 25 calculation points along each axis.
		/// </summary>
		/// <param name="x0">The minimum 'x' value.</param>
		/// <param name="x1">The maximum 'x' value.</param>
		/// <param name="y0">The minimum 'y' value.</param>
		/// <param name="y1">The maximum 'y' value.</param>
		/// <returns>The minimum of the calculated values.</returns>
		public double Min(double x0, double x1, double y0, double y1) {
			return this.Min(x0,x1,y0,y1,25,25);
		}

		#endregion

		#region Maximum Calculations

		/// <summary>
		/// Returns the maximum value of the stored Expression
		/// over the interval specified by the min and max values.
		/// This may not find the actual maximum (or even a close
		/// approximation) because the Expression is only evaluated
		/// at evenly spaced points along the interval which may not
		/// pass through a point of extreme upward slope.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <param name="steps">The number of points to calculate.</param>
		/// <returns>The maximum of the calculated values.</returns>
		public double Max(double min, double max, int steps) {
			double Max = Double.MinValue;
			double x = min;
			double val = 0;
			while ( x <= max ) {
				val = this.fExpression.Evaluate(x);
				if ( val > Max ) {
					Max = val;
				}
				x += (max-min) / (double)steps;
			}
			return Max;
		}

		/// <summary>
		/// Returns the maximum value of the stored Expression
		/// over the interval specified by the min and max values
		/// using 100 calculation points.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <returns>The maximum of the calculated values.</returns>
		public double Max(double min, double max) {
			return this.Max(min,max,100);
		}

		/// <summary>
		/// Returns the maximum value of the stored Expression
		/// over the region specified by the min and max values.
		/// This may not find the actual maximum (or even a close
		/// approximation) because the Expression is only evaluated
		/// at evenly spaced points inside the region which may not
		/// pass through a point of extreme upward slope.
		/// </summary>
		/// <param name="minX">The minimum 'x' value.</param>
		/// <param name="maxX">The maximum 'x' value.</param>
		/// <param name="minY">The minimum 'y' value.</param>
		/// <param name="maxY">The maximum 'y' value.</param>
		/// <param name="xSteps">The number of divisions along the 'x' axis.</param>
		/// <param name="ySteps">The number of divisions along the 'y' axis.</param>
		/// <returns>The maximum of the calculated values.</returns>
		public double Max(double minX, double maxX, double minY, double maxY, int xSteps, int ySteps) {
			double xValue = minX;
			double yValue = minY;
			double maxValue = Double.MinValue;
			double evaluation = 0;
			double xStep = (maxX-minX) / (double)xSteps;
			double yStep = (maxY-minY) / (double)ySteps;
		
			while ( xValue < maxX ) {
				while ( yValue < maxY ) {
					evaluation = this.fExpression.Evaluate(xValue,yValue);
					if ( evaluation > maxValue ) {
						maxValue = evaluation;	
					}
					yValue += yStep;
				}
				xValue += xStep;
				yValue  = minY;
			}
			return maxValue;
		}

		/// <summary>
		/// Returns the maximum value of the stored Expression
		/// over the region specified by the min and max values
		/// using 25 calculation points along each axis.
		/// </summary>
		/// <param name="x0">The minimum 'x' value.</param>
		/// <param name="x1">The maximum 'x' value.</param>
		/// <param name="y0">The minimum 'y' value.</param>
		/// <param name="y1">The maximum 'y' value.</param>
		/// <returns>The maximum of the calculated values.</returns>
		public double Max(double x0, double x1, double y0, double y1) {
			return this.Max(x0,x1,y0,y1,25,25);
		}

		#endregion
		
		#region Numeric Calculus Calculations

		/// <summary>
		/// Returns the numeric derivative of the Expression at the specified 
		/// independent-variable value.
		/// </summary>
		/// <param name="x">The independent-variable value.</param>
		/// <returns>The numeric derivative.</returns>
		public double Derivative(double x) {
			return this.AverageSlope(x,x+0.0000001);
		}

		/// <summary>
		/// Calculates the Riemann sum of the function over the specified interval.  This
		/// is the sum of the areas of rectangles of equal widths and heights defined
		/// by the Expression value.  Different values will be obtained using different
		/// EvaluationPoints which choose the point along the width of the rectangles where
		/// the Expression will be evaluated.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <param name="intervals">The number of rectangles to calculate.</param>
		/// <param name="p">The EvaluationPoints in the calculated rectangles.</param>
		/// <returns>The Riemann sum.</returns>
		public double RiemannSum(double min, double max, int intervals, EvaluationPoint p) {
			double deltaX = (max-min)/((double)intervals);
			double sum = 0;
			double x = min;

			if ( p == EvaluationPoint.Center ) {
				x = min + 0.5*deltaX;
			} else if ( p == EvaluationPoint.Right ) {
				x = min + deltaX;	
			}
		
			for ( int i = 0; i < intervals; i++ ) {
				sum += deltaX*this.fExpression.Evaluate(x);
				x += deltaX;
			}
			return sum;
		}
		
		/// <summary>
		/// Similar to the RiemannSum method, but trapezoids are used instead of
		/// rectangles.
		/// </summary>
		/// <param name="min">The minimum interval value.</param>
		/// <param name="max">The maximum interval value.</param>
		/// <param name="intervals">The number of trapezoids.</param>
		/// <returns>The sum of the areas of the trapezoids.</returns>
		public double TrapezoidalRule(double min, double max, int intervals) {
			double deltaX = (max - min)/intervals;
			double approximation = 0;
		
			for ( int i = 1; i < intervals; i++ ) {
				approximation += ((this.fExpression.Evaluate(min+deltaX*i) 
					+ this.fExpression.Evaluate(min+deltaX*(i-1)))/(2.0))*deltaX;
			}
			return approximation;
		}

		/// <summary>
		/// Calculates Simpson's approximation of the definate integral of
		/// the stored Expression over the specified interval using the 
		/// specified number of divisions.
		/// </summary>
		/// <param name="min">The interval minimum.</param>
		/// <param name="max">The interval maximum.</param>
		/// <param name="intervals">The number of divisions.</param>
		/// <returns>The definate-integral approximation.</returns>
		public double SimpsonsRule(double min, double max, int intervals) {
			double deltaX   = (max-min)/(intervals);
			double multiple = (max-min)/(3*intervals);
			double approximation = 0;
		
			approximation += this.fExpression.Evaluate(min)*multiple;
			approximation += this.fExpression.Evaluate(max)*multiple;
		
			for ( int i = 1; i < intervals; i++ ) {
				if ( (i % 2) == 0 ) {
					approximation += 2*multiple*this.fExpression.Evaluate(min+deltaX*i);
				} else {
					approximation += 4*multiple*this.fExpression.Evaluate(min+deltaX*i);
				}
			}
			return approximation;
		}
		
		/// <summary>
		/// Uses Simpson's method to approximate the definite integral
		/// of the stored Expression over the specified interval.
		/// </summary>
		/// <param name="min">The interval minimum.</param>
		/// <param name="max">The interval maximum.</param>
		/// <returns>The definite-integral approximation.</returns>
		public double Integrate(double min, double max) {
			return this.SimpsonsRule(min,max,1000);
		}

		#endregion

		public double Range(double min, double max) {
			return this.Max(min,max) - this.Min(min,max);
		}

		public double Range(double minX, double maxX, double minY, double maxY) {
			return this.Max(minX,maxX,minY,maxY) - this.Min(minX,maxX,minY,maxY);
		}
	
		public double AverageSlope(double x1, double x2) {
			return (this.fExpression.Evaluate(x2)-this.fExpression.Evaluate(x1))/(x2-x1);
		}
	
		public double AverageValue(double min, double max) {
			return (1/(max-min))*this.SimpsonsRule(min,max,1000);
		}
	}
}
