using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Daple.Plotting.TwoD {
	/// <summary>
	/// Summary description for Plotter2dEditForm.
	/// </summary>
	public class Plotter2dEditForm : System.Windows.Forms.Form {

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button fApplyButton;
		private System.Windows.Forms.TextBox fExpressionBox;
		private System.Windows.Forms.Button fShowAnalysisButton;
		private System.Windows.Forms.ComboBox fLineQuality;
		private System.Windows.Forms.NumericUpDown fLineThickness;
		private System.Windows.Forms.NumericUpDown fPointsCalculated;
		private System.Windows.Forms.Button fCloseButton;
		private System.Windows.Forms.Button fAddColorButton;
		private System.Windows.Forms.ComboBox fColorComboBox;
		private System.Windows.Forms.NumericUpDown fRBox;
		private System.Windows.Forms.NumericUpDown fBBox;
		private System.Windows.Forms.NumericUpDown fGBox;

		private GraphPanel2d fGraphPanel;
		private System.Windows.Forms.GroupBox fCoordinateSystems;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox fCoordinateSystemComboBox;

		private Plotter2d fPlotter;

		public Plotter2dEditForm(GraphPanel2d gp) {
			this.fGraphPanel = gp;
			InitializeComponent();
		}

		public void SetPlotter(Plotter2d p) {
			this.fPlotter = p;
		}

		public new void Show() {
			base.Show();
			this.SetPlotterValues();
		}

		private void SetPlotterValues() {
			if ( this.fPlotter is FunctionPlotter ) {
				this.fCoordinateSystemComboBox.SelectedIndex = 0;
			} else if ( this.fPlotter is PolarPlotter ) {
				this.fCoordinateSystemComboBox.SelectedIndex = 1;
			}
			this.fPointsCalculated.Value = this.fPlotter.pXPoints;
			this.fLineThickness.Value = (decimal)this.fPlotter.pPen.Width;
			this.fExpressionBox.Text = this.fPlotter.pExpression.ToString();
			if ( this.fPlotter.pLineQuality == SmoothingMode.HighSpeed ) {
				this.fLineQuality.SelectedIndex = 2;
			} else if ( this.fPlotter.pLineQuality == SmoothingMode.AntiAlias ) {
				this.fLineQuality.SelectedIndex = 1;
			} else if ( this.fPlotter.pLineQuality == SmoothingMode.HighQuality ) {
				this.fLineQuality.SelectedIndex = 0;
			}
		}

		private void ApplyToPlotter() {
			this.fPlotter.pExpression = new Daple.Expressions.Expression(this.fExpressionBox.Text);
			this.fPlotter.pXPoints = (int)this.fPointsCalculated.Value;
			this.fPlotter.pPen.Width = (float)this.fLineThickness.Value;
			if ( this.fLineQuality.SelectedIndex == 0 ) {
				this.fPlotter.pLineQuality = SmoothingMode.HighQuality;
			} else if ( this.fLineQuality.SelectedIndex == 1 ) {
				this.fPlotter.pLineQuality = SmoothingMode.AntiAlias;
			} else if ( this.fLineQuality.SelectedIndex == 2 ) {
				this.fPlotter.pLineQuality = SmoothingMode.HighSpeed;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.fApplyButton = new System.Windows.Forms.Button();
			this.fExpressionBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.fCoordinateSystems = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.fCoordinateSystemComboBox = new System.Windows.Forms.ComboBox();
			this.fShowAnalysisButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fLineQuality = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fLineThickness = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.fPointsCalculated = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.fCloseButton = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.fGBox = new System.Windows.Forms.NumericUpDown();
			this.fBBox = new System.Windows.Forms.NumericUpDown();
			this.fRBox = new System.Windows.Forms.NumericUpDown();
			this.fAddColorButton = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.fColorComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.fCoordinateSystems.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fLineThickness)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fPointsCalculated)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fGBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fBBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox)).BeginInit();
			this.SuspendLayout();
			// 
			// fApplyButton
			// 
			this.fApplyButton.Location = new System.Drawing.Point(152, 352);
			this.fApplyButton.Name = "fApplyButton";
			this.fApplyButton.TabIndex = 0;
			this.fApplyButton.Text = "Apply";
			this.fApplyButton.Click += new System.EventHandler(this.fApplyButton_Click);
			// 
			// fExpressionBox
			// 
			this.fExpressionBox.Location = new System.Drawing.Point(16, 32);
			this.fExpressionBox.Name = "fExpressionBox";
			this.fExpressionBox.Size = new System.Drawing.Size(280, 20);
			this.fExpressionBox.TabIndex = 1;
			this.fExpressionBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Expression";
			// 
			// fCoordinateSystems
			// 
			this.fCoordinateSystems.Controls.Add(this.label10);
			this.fCoordinateSystems.Controls.Add(this.fCoordinateSystemComboBox);
			this.fCoordinateSystems.Location = new System.Drawing.Point(16, 88);
			this.fCoordinateSystems.Name = "fCoordinateSystems";
			this.fCoordinateSystems.Size = new System.Drawing.Size(136, 112);
			this.fCoordinateSystems.TabIndex = 3;
			this.fCoordinateSystems.TabStop = false;
			this.fCoordinateSystems.Text = "Plotting";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 16);
			this.label10.TabIndex = 3;
			this.label10.Text = "Coordinate System";
			// 
			// fCoordinateSystemComboBox
			// 
			this.fCoordinateSystemComboBox.Items.AddRange(new object[] {
																		   "Euclidean",
																		   "Polar"});
			this.fCoordinateSystemComboBox.Location = new System.Drawing.Point(16, 48);
			this.fCoordinateSystemComboBox.Name = "fCoordinateSystemComboBox";
			this.fCoordinateSystemComboBox.Size = new System.Drawing.Size(96, 21);
			this.fCoordinateSystemComboBox.TabIndex = 2;
			this.fCoordinateSystemComboBox.Text = "Euclidean";
			// 
			// fShowAnalysisButton
			// 
			this.fShowAnalysisButton.Location = new System.Drawing.Point(320, 32);
			this.fShowAnalysisButton.Name = "fShowAnalysisButton";
			this.fShowAnalysisButton.Size = new System.Drawing.Size(88, 23);
			this.fShowAnalysisButton.TabIndex = 4;
			this.fShowAnalysisButton.Text = "Show Analysis";
			this.fShowAnalysisButton.Click += new System.EventHandler(this.fShowAnalysisButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.fLineQuality);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.fLineThickness);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(168, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(312, 80);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Appearance";
			// 
			// fLineQuality
			// 
			this.fLineQuality.Items.AddRange(new object[] {
															  "High",
															  "Medium",
															  "Low"});
			this.fLineQuality.Location = new System.Drawing.Point(168, 40);
			this.fLineQuality.Name = "fLineQuality";
			this.fLineQuality.Size = new System.Drawing.Size(104, 21);
			this.fLineQuality.TabIndex = 3;
			this.fLineQuality.Text = "High";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(168, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Line Quality";
			// 
			// fLineThickness
			// 
			this.fLineThickness.Location = new System.Drawing.Point(40, 40);
			this.fLineThickness.Name = "fLineThickness";
			this.fLineThickness.Size = new System.Drawing.Size(96, 20);
			this.fLineThickness.TabIndex = 1;
			this.fLineThickness.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Line Thickness";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.fPointsCalculated);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(16, 216);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 112);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Accuracy";
			// 
			// fPointsCalculated
			// 
			this.fPointsCalculated.Location = new System.Drawing.Point(16, 48);
			this.fPointsCalculated.Maximum = new System.Decimal(new int[] {
																			  1000,
																			  0,
																			  0,
																			  0});
			this.fPointsCalculated.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.fPointsCalculated.Name = "fPointsCalculated";
			this.fPointsCalculated.Size = new System.Drawing.Size(96, 20);
			this.fPointsCalculated.TabIndex = 1;
			this.fPointsCalculated.Value = new System.Decimal(new int[] {
																			200,
																			0,
																			0,
																			0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Points Calculated";
			// 
			// fCloseButton
			// 
			this.fCloseButton.Location = new System.Drawing.Point(272, 352);
			this.fCloseButton.Name = "fCloseButton";
			this.fCloseButton.TabIndex = 7;
			this.fCloseButton.Text = "Close";
			this.fCloseButton.Click += new System.EventHandler(this.fCloseButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.fGBox);
			this.groupBox4.Controls.Add(this.fBBox);
			this.groupBox4.Controls.Add(this.fRBox);
			this.groupBox4.Controls.Add(this.fAddColorButton);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.listBox1);
			this.groupBox4.Controls.Add(this.fColorComboBox);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Location = new System.Drawing.Point(168, 176);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(312, 155);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Coloring";
			// 
			// fGBox
			// 
			this.fGBox.Location = new System.Drawing.Point(72, 88);
			this.fGBox.Maximum = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fGBox.Name = "fGBox";
			this.fGBox.Size = new System.Drawing.Size(48, 20);
			this.fGBox.TabIndex = 21;
			this.fGBox.Value = new System.Decimal(new int[] {
																255,
																0,
																0,
																0});
			// 
			// fBBox
			// 
			this.fBBox.Location = new System.Drawing.Point(132, 88);
			this.fBBox.Maximum = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fBBox.Name = "fBBox";
			this.fBBox.Size = new System.Drawing.Size(48, 20);
			this.fBBox.TabIndex = 20;
			this.fBBox.Value = new System.Decimal(new int[] {
																255,
																0,
																0,
																0});
			// 
			// fRBox
			// 
			this.fRBox.Location = new System.Drawing.Point(16, 88);
			this.fRBox.Maximum = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fRBox.Name = "fRBox";
			this.fRBox.Size = new System.Drawing.Size(48, 20);
			this.fRBox.TabIndex = 19;
			this.fRBox.Value = new System.Decimal(new int[] {
																255,
																0,
																0,
																0});
			// 
			// fAddColorButton
			// 
			this.fAddColorButton.Location = new System.Drawing.Point(64, 120);
			this.fAddColorButton.Name = "fAddColorButton";
			this.fAddColorButton.Size = new System.Drawing.Size(72, 23);
			this.fAddColorButton.TabIndex = 18;
			this.fAddColorButton.Text = "Add";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(128, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "B";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(72, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "G";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "R";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(192, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Color(s)";
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(192, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(106, 108);
			this.listBox1.TabIndex = 10;
			// 
			// fColorComboBox
			// 
			this.fColorComboBox.Items.AddRange(new object[] {
																"Solid Color",
																"Elevation",
																"X Value"});
			this.fColorComboBox.Location = new System.Drawing.Point(40, 40);
			this.fColorComboBox.Name = "fColorComboBox";
			this.fColorComboBox.Size = new System.Drawing.Size(121, 21);
			this.fColorComboBox.TabIndex = 9;
			this.fColorComboBox.Text = "Solid Color";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(40, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Coloring";
			// 
			// Plotter2dEditForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 382);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.fCloseButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.fShowAnalysisButton);
			this.Controls.Add(this.fCoordinateSystems);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fExpressionBox);
			this.Controls.Add(this.fApplyButton);
			this.Name = "Plotter2dEditForm";
			this.Text = "2D Plotter";
			this.fCoordinateSystems.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fLineThickness)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fPointsCalculated)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fGBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fBBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void fCloseButton_Click(object sender, System.EventArgs e) {
			this.Hide();
		}

		private void fApplyButton_Click(object sender, System.EventArgs e) {
			this.ApplyToPlotter();
			this.fGraphPanel.Invalidate();
		}

		private void fShowAnalysisButton_Click(object sender, System.EventArgs e) {
			Manager.Instance.ShowAnalysis(this.fExpressionBox.Text);
		}
	}
}
