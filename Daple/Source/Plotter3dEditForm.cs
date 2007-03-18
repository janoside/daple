using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using D3 = Microsoft.DirectX.Direct3D;

using Daple.Plotting;

namespace Daple.Plotting.ThreeD {
	/// <summary>
	/// Summary description for Plotter3dEditForm.
	/// </summary>
	public class Plotter3dEditForm : System.Windows.Forms.Form {
		private System.Windows.Forms.NumericUpDown fGBox;
		private System.Windows.Forms.NumericUpDown fBBox;
		private System.Windows.Forms.NumericUpDown fRBox;
		private System.Windows.Forms.Button fAddColorButton;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox fColorComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button fCloseButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button fShowAnalysisButton;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox fExpressionBox;
		private System.Windows.Forms.Button fApplyButton;
		private System.Windows.Forms.Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private GraphPanel3d fGraphPanel;
		private Daple.Plotting.ColorPreviewControl fColorPreview;
		private System.Windows.Forms.NumericUpDown fYPointsCalculated;
		private System.Windows.Forms.NumericUpDown fXPointsCalculated;
		private Daple.Plotting.ColorSchemePreviewControl fColorSchemePreviewControl;
		private System.Windows.Forms.ListBox fRGBBox;
		private System.Windows.Forms.Button fRemoveColorButton;
		private System.Windows.Forms.Button fMoveUpButton;
		private System.Windows.Forms.Button fMoveDownButton;
		private System.Windows.Forms.ContextMenu fLoadMenu;
		private System.Windows.Forms.Button fLoadButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private Plotter3d fPlotter;
		private System.Windows.Forms.TextBox fColorExpressionBox;
		private System.Windows.Forms.ComboBox fRenderModeCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label12;

		private Color [] fColors;

		public Plotter3dEditForm(GraphPanel3d gp) {
			this.fGraphPanel = gp;
			InitializeComponent();
			this.CreateContextMenu();
			this.fRemoveColorButton.Enabled = false;
		}

		public void SetPlotter(Plotter3d p) {
			this.fPlotter = p;
		}

		public new void Show() {
			base.Show();
			this.SetPlotterValues();
		}

		private void SetPlotterValues() {
			this.fExpressionBox.Text = this.fPlotter.pExpression.ToString();
			this.fXPointsCalculated.Value = this.fPlotter.pXPoints;
			this.fYPointsCalculated.Value = this.fPlotter.pYPoints;
			if ( this.fPlotter.pFillMode == D3.FillMode.Solid ) {
				this.fRenderModeCombo.SelectedIndex = 0;
			} else if ( this.fPlotter.pFillMode == D3.FillMode.WireFrame ) {
				this.fRenderModeCombo.SelectedIndex = 1;
			} else {
				this.fRenderModeCombo.SelectedIndex = 2;
			}
		}

		private void ApplyToPlotter() {
			this.fPlotter.pExpression = new Daple.Expressions.Expression(this.fExpressionBox.Text);
			this.fPlotter.pXPoints = (int)this.fXPointsCalculated.Value;
			this.fPlotter.pYPoints = (int)this.fYPointsCalculated.Value;
			if ( this.fRenderModeCombo.SelectedIndex == 0 ) {
				this.fPlotter.pFillMode = D3.FillMode.Solid;
			} else if ( this.fRenderModeCombo.SelectedIndex == 1 ) {
				this.fPlotter.pFillMode = D3.FillMode.WireFrame;
			} else if ( this.fRenderModeCombo.SelectedIndex == 2 ) {
				this.fPlotter.pFillMode = D3.FillMode.Point;
			}
			switch ( this.fColorComboBox.SelectedIndex ) {
				case 0:
					this.SetElevationColor();
					break;
				case 1:
					this.SetExpressionColor();
					break;
				case 2:
					this.SetXPositionColor();
					break;
				case 3:
					this.SetYPositionColor();
					break;
				case 4:
					this.SetXYPositionColor();
					break;
				case 5:
					this.SetXYZPositionColor();
					break;
			}
		}

		private void SetElevationColor() {
			Daple.Expressions.Evaluator e = new Daple.Expressions.Evaluator(this.fPlotter.pExpression);
			float min = (float)e.Min(-5,5,-5,5);
			float max = (float)e.Max(-5,5,-5,5);
			this.fPlotter.pColorSetter = new ZPosition3dColorSetter(min,max);
			this.fPlotter.pColorSetter.pColors = this.fColors;
		}

		private void SetExpressionColor() {
			if ( this.fColorExpressionBox.Text.Equals("") ) {
				
			} else {
				this.fPlotter.pColorSetter = new Expression3dColorSetter(
					this.fColorExpressionBox.Text,
					-5,
					5,
					-5,
					5);
				this.fPlotter.pColorSetter.pColors = this.fColors;
			}
		}

		private void SetXPositionColor() {
			this.fPlotter.pColorSetter = new Expression3dColorSetter(
				"x+y*0",
				-5,
				5,
				-5,
				5);
			this.fPlotter.pColorSetter.pColors = this.fColors;
		}

		private void SetYPositionColor() {
			this.fPlotter.pColorSetter = new Expression3dColorSetter(
				"x*0+y",
				-5,
				5,
				-5,
				5);
			this.fPlotter.pColorSetter.pColors = this.fColors;
		}

		private void SetXYPositionColor() {
			this.fPlotter.pColorSetter = new Expression3dColorSetter(
				"x+y",
				-5,
				5,
				-5,
				5);
			this.fPlotter.pColorSetter.pColors = this.fColors;
		}

		private void SetXYZPositionColor() {
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
			this.fRGBBox = new System.Windows.Forms.ListBox();
			this.fColorSchemePreviewControl = new Daple.Plotting.ColorSchemePreviewControl();
			this.fColorPreview = new Daple.Plotting.ColorPreviewControl();
			this.fRemoveColorButton = new System.Windows.Forms.Button();
			this.fLoadButton = new System.Windows.Forms.Button();
			this.fGBox = new System.Windows.Forms.NumericUpDown();
			this.fBBox = new System.Windows.Forms.NumericUpDown();
			this.fRBox = new System.Windows.Forms.NumericUpDown();
			this.fAddColorButton = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.fColorComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.fCloseButton = new System.Windows.Forms.Button();
			this.fYPointsCalculated = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.fXPointsCalculated = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.fShowAnalysisButton = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.fExpressionBox = new System.Windows.Forms.TextBox();
			this.fApplyButton = new System.Windows.Forms.Button();
			this.fMoveUpButton = new System.Windows.Forms.Button();
			this.fMoveDownButton = new System.Windows.Forms.Button();
			this.fLoadMenu = new System.Windows.Forms.ContextMenu();
			this.fColorExpressionBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.fRenderModeCombo = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fGBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fBBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fYPointsCalculated)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fXPointsCalculated)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fRGBBox
			// 
			this.fRGBBox.Location = new System.Drawing.Point(248, 184);
			this.fRGBBox.Name = "fRGBBox";
			this.fRGBBox.Size = new System.Drawing.Size(160, 95);
			this.fRGBBox.TabIndex = 26;
			this.fRGBBox.SelectedIndexChanged += new System.EventHandler(this.fRGBBox_SelectedIndexChanged);
			// 
			// fColorSchemePreviewControl
			// 
			this.fColorSchemePreviewControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.fColorSchemePreviewControl.Location = new System.Drawing.Point(456, 48);
			this.fColorSchemePreviewControl.Name = "fColorSchemePreviewControl";
			this.fColorSchemePreviewControl.Size = new System.Drawing.Size(56, 272);
			this.fColorSchemePreviewControl.TabIndex = 25;
			// 
			// fColorPreview
			// 
			this.fColorPreview.BackColor = System.Drawing.Color.White;
			this.fColorPreview.Location = new System.Drawing.Point(24, 256);
			this.fColorPreview.Name = "fColorPreview";
			this.fColorPreview.Size = new System.Drawing.Size(160, 32);
			this.fColorPreview.TabIndex = 24;
			// 
			// fRemoveColorButton
			// 
			this.fRemoveColorButton.Location = new System.Drawing.Point(112, 312);
			this.fRemoveColorButton.Name = "fRemoveColorButton";
			this.fRemoveColorButton.Size = new System.Drawing.Size(72, 23);
			this.fRemoveColorButton.TabIndex = 23;
			this.fRemoveColorButton.Text = "Remove";
			this.fRemoveColorButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// fLoadButton
			// 
			this.fLoadButton.Location = new System.Drawing.Point(248, 312);
			this.fLoadButton.Name = "fLoadButton";
			this.fLoadButton.Size = new System.Drawing.Size(80, 23);
			this.fLoadButton.TabIndex = 22;
			this.fLoadButton.Text = "Load";
			this.fLoadButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// fGBox
			// 
			this.fGBox.Location = new System.Drawing.Point(80, 224);
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
			this.fGBox.ValueChanged += new System.EventHandler(this.fGBox_ValueChanged);
			// 
			// fBBox
			// 
			this.fBBox.Location = new System.Drawing.Point(136, 224);
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
			this.fBBox.ValueChanged += new System.EventHandler(this.fBBox_ValueChanged);
			// 
			// fRBox
			// 
			this.fRBox.Location = new System.Drawing.Point(24, 224);
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
			this.fRBox.ValueChanged += new System.EventHandler(this.fRBox_ValueChanged);
			// 
			// fAddColorButton
			// 
			this.fAddColorButton.Location = new System.Drawing.Point(24, 312);
			this.fAddColorButton.Name = "fAddColorButton";
			this.fAddColorButton.Size = new System.Drawing.Size(72, 23);
			this.fAddColorButton.TabIndex = 18;
			this.fAddColorButton.Text = "Add";
			this.fAddColorButton.Click += new System.EventHandler(this.fAddColorButton_Click);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(136, 208);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "B";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(80, 208);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "G";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "R";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(248, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Color Scheme";
			// 
			// fColorComboBox
			// 
			this.fColorComboBox.Items.AddRange(new object[] {
																"Elevation",
																"Expression",
																"X Value",
																"Y Value",
																"XY Value",
																"XYZ Value"});
			this.fColorComboBox.Location = new System.Drawing.Point(24, 104);
			this.fColorComboBox.Name = "fColorComboBox";
			this.fColorComboBox.Size = new System.Drawing.Size(121, 21);
			this.fColorComboBox.TabIndex = 9;
			this.fColorComboBox.Text = "Elevation";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Type";
			// 
			// fCloseButton
			// 
			this.fCloseButton.Location = new System.Drawing.Point(320, 512);
			this.fCloseButton.Name = "fCloseButton";
			this.fCloseButton.TabIndex = 16;
			this.fCloseButton.Text = "Close";
			this.fCloseButton.Click += new System.EventHandler(this.fCloseButton_Click);
			// 
			// fYPointsCalculated
			// 
			this.fYPointsCalculated.Location = new System.Drawing.Point(224, 296);
			this.fYPointsCalculated.Maximum = new System.Decimal(new int[] {
																			   125,
																			   0,
																			   0,
																			   0});
			this.fYPointsCalculated.Minimum = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			this.fYPointsCalculated.Name = "fYPointsCalculated";
			this.fYPointsCalculated.Size = new System.Drawing.Size(96, 20);
			this.fYPointsCalculated.TabIndex = 3;
			this.fYPointsCalculated.Value = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(216, 280);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "Y Points Calculated";
			// 
			// fXPointsCalculated
			// 
			this.fXPointsCalculated.Location = new System.Drawing.Point(224, 248);
			this.fXPointsCalculated.Maximum = new System.Decimal(new int[] {
																			   125,
																			   0,
																			   0,
																			   0});
			this.fXPointsCalculated.Minimum = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			this.fXPointsCalculated.Name = "fXPointsCalculated";
			this.fXPointsCalculated.Size = new System.Drawing.Size(96, 20);
			this.fXPointsCalculated.TabIndex = 1;
			this.fXPointsCalculated.Value = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(216, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "X Points Calculated";
			// 
			// fShowAnalysisButton
			// 
			this.fShowAnalysisButton.Location = new System.Drawing.Point(312, 32);
			this.fShowAnalysisButton.Name = "fShowAnalysisButton";
			this.fShowAnalysisButton.Size = new System.Drawing.Size(88, 23);
			this.fShowAnalysisButton.TabIndex = 13;
			this.fShowAnalysisButton.Text = "Show Analysis";
			this.fShowAnalysisButton.Click += new System.EventHandler(this.fShowAnalysisButton_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(56, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 16);
			this.label10.TabIndex = 3;
			this.label10.Text = "Coordinate System";
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "Euclidean",
														   "Polar"});
			this.comboBox1.Location = new System.Drawing.Point(56, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.Text = "Euclidean";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Expression";
			// 
			// fExpressionBox
			// 
			this.fExpressionBox.Location = new System.Drawing.Point(8, 32);
			this.fExpressionBox.Name = "fExpressionBox";
			this.fExpressionBox.Size = new System.Drawing.Size(280, 20);
			this.fExpressionBox.TabIndex = 10;
			this.fExpressionBox.Text = "";
			// 
			// fApplyButton
			// 
			this.fApplyButton.Location = new System.Drawing.Point(184, 512);
			this.fApplyButton.Name = "fApplyButton";
			this.fApplyButton.TabIndex = 9;
			this.fApplyButton.Text = "Apply";
			this.fApplyButton.Click += new System.EventHandler(this.fApplyButton_Click);
			// 
			// fMoveUpButton
			// 
			this.fMoveUpButton.Enabled = false;
			this.fMoveUpButton.Location = new System.Drawing.Point(336, 312);
			this.fMoveUpButton.Name = "fMoveUpButton";
			this.fMoveUpButton.Size = new System.Drawing.Size(32, 23);
			this.fMoveUpButton.TabIndex = 27;
			this.fMoveUpButton.Text = "Up";
			this.fMoveUpButton.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// fMoveDownButton
			// 
			this.fMoveDownButton.Enabled = false;
			this.fMoveDownButton.Location = new System.Drawing.Point(376, 312);
			this.fMoveDownButton.Name = "fMoveDownButton";
			this.fMoveDownButton.Size = new System.Drawing.Size(32, 23);
			this.fMoveDownButton.TabIndex = 28;
			this.fMoveDownButton.Text = "Dn";
			this.fMoveDownButton.Click += new System.EventHandler(this.button3_Click);
			// 
			// fColorExpressionBox
			// 
			this.fColorExpressionBox.Location = new System.Drawing.Point(24, 168);
			this.fColorExpressionBox.Name = "fColorExpressionBox";
			this.fColorExpressionBox.Size = new System.Drawing.Size(160, 20);
			this.fColorExpressionBox.TabIndex = 29;
			this.fColorExpressionBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 30;
			this.label2.Text = "Expression";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 80);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(568, 424);
			this.tabControl1.TabIndex = 18;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.fXPointsCalculated);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.fYPointsCalculated);
			this.tabPage1.Controls.Add(this.fRenderModeCombo);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(560, 398);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Plotting";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 17;
			this.label4.Text = "Render Mode";
			// 
			// fRenderModeCombo
			// 
			this.fRenderModeCombo.Items.AddRange(new object[] {
																  "Solid",
																  "Wireframe",
																  "Point"});
			this.fRenderModeCombo.Location = new System.Drawing.Point(48, 112);
			this.fRenderModeCombo.Name = "fRenderModeCombo";
			this.fRenderModeCombo.Size = new System.Drawing.Size(121, 21);
			this.fRenderModeCombo.TabIndex = 0;
			this.fRenderModeCombo.Text = "Solid";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.fAddColorButton);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.fColorExpressionBox);
			this.tabPage2.Controls.Add(this.fColorSchemePreviewControl);
			this.tabPage2.Controls.Add(this.fBBox);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.fRBox);
			this.tabPage2.Controls.Add(this.fColorComboBox);
			this.tabPage2.Controls.Add(this.fRGBBox);
			this.tabPage2.Controls.Add(this.fMoveUpButton);
			this.tabPage2.Controls.Add(this.fColorPreview);
			this.tabPage2.Controls.Add(this.fRemoveColorButton);
			this.tabPage2.Controls.Add(this.fLoadButton);
			this.tabPage2.Controls.Add(this.fGBox);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.fMoveDownButton);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(560, 398);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Coloring";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(456, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 31;
			this.label12.Text = "Preview";
			// 
			// Plotter3dEditForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 542);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.fCloseButton);
			this.Controls.Add(this.fShowAnalysisButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fExpressionBox);
			this.Controls.Add(this.fApplyButton);
			this.Name = "Plotter3dEditForm";
			this.Text = "Plotter3dEditForm";
			((System.ComponentModel.ISupportInitialize)(this.fGBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fBBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fYPointsCalculated)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fXPointsCalculated)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
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

		private void fRBox_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview.SetColor((int)this.fRBox.Value,(int)this.fGBox.Value,(int)this.fBBox.Value);
		}

		private void fGBox_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview.SetColor((int)this.fRBox.Value,(int)this.fGBox.Value,(int)this.fBBox.Value);
		}

		private void fBBox_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview.SetColor((int)this.fRBox.Value,(int)this.fGBox.Value,(int)this.fBBox.Value);
		}

		private void fAddColorButton_Click(object sender, System.EventArgs e) {
	//		ColorPreviewControl cpc = new ColorPreviewControl();
	//		cpc.SetColor((int)this.fRBox.Value,(int)this.fGBox.Value,(int)this.fBBox.Value);
		//	this.fColorSchemePreviewControl.AddColor(
		//		(int)this.fRBox.Value,
		//		(int)this.fGBox.Value,
		//		(int)this.fBBox.Value);
			string r = ((int)this.fRBox.Value).ToString();
			r = this.FillString(r,3);
			string g = ((int)this.fGBox.Value).ToString();
			g = this.FillString(g,3);
			string b = ((int)this.fBBox.Value).ToString();
			b = this.FillString(b,3);
			this.fRGBBox.Items.Add("rgb["+r+","+g+","+b+"]");
			this.UpdateColorScheme();
		}

		private Color ParseRGB(string s) {
		//	Console.WriteLine("CHEEEEEEESE:"+s.Substring(4,3));
			return Color.FromArgb(
				int.Parse(s.Substring(4,3)),
				int.Parse(s.Substring(8,3)),
				int.Parse(s.Substring(12,3)));
		}

		private string FillString(string s, int length) {
			while ( s.Length < length ) {
				s += " ";
			}
			return s;
		}

		private void UpdateColorScheme() {
			Color [] c = new Color[this.fRGBBox.Items.Count];
			for ( int i = 0; i < this.fRGBBox.Items.Count; i++ ) {
				c[i] = this.ParseRGB((string)this.fRGBBox.Items[i]);
			}
			this.fColors = c;
			this.fColorSchemePreviewControl.SetColors(c);
			this.fColorSchemePreviewControl.Invalidate();
		}

		private void button2_Click(object sender, System.EventArgs e) {
			int x = this.fRGBBox.SelectedIndex;
			this.fRGBBox.Items.Remove(this.fRGBBox.SelectedItem);
			if ( x == this.fRGBBox.Items.Count ) {
				this.fRGBBox.SelectedIndex = x-1;
			} else {
				this.fRGBBox.SelectedIndex = x;
			}
			this.UpdateColorScheme();
		}

		private void fRGBBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			if ( this.fRGBBox.SelectedItem == null ) {
				this.fRemoveColorButton.Enabled = false;
				this.fMoveUpButton.Enabled = false;
				this.fMoveDownButton.Enabled = false;
			} else {
				this.fRemoveColorButton.Enabled = true;
				this.fMoveUpButton.Enabled = true;
				this.fMoveDownButton.Enabled = true;
			}
		}

		private void button2_Click_1(object sender, System.EventArgs e) {
			if ( this.fRGBBox.SelectedIndex >= 1 ) {
				int x = this.fRGBBox.SelectedIndex;
				object o1 = this.fRGBBox.SelectedItem;
				object o2 = this.fRGBBox.Items[x-1];
				
				this.fRGBBox.Items[x]   = o2;
				this.fRGBBox.Items[x-1] = o1;
				this.fRGBBox.SelectedIndex = x-1;
				this.UpdateColorScheme();
			}
		}

		private void button3_Click(object sender, System.EventArgs e) {
			if ( this.fRGBBox.SelectedIndex <= this.fRGBBox.Items.Count-2 ) {
				int x = this.fRGBBox.SelectedIndex;
				object o1 = this.fRGBBox.SelectedItem;
				object o2 = this.fRGBBox.Items[x+1];
				
				this.fRGBBox.Items[x]   = o2;
				this.fRGBBox.Items[x+1] = o1;
				this.fRGBBox.SelectedIndex = x+1;
				this.UpdateColorScheme();
			}
		}

		private void CreateContextMenu() {
			MenuItem m = new MenuItem("Existing");
			MenuItem m0 = new MenuItem("Rainbow",new EventHandler(this.LoadRainbow));
			MenuItem m1 = new MenuItem("Stripes",new EventHandler(this.LoadStripes));
			m.MenuItems.Add(m0);
			m.MenuItems.Add(m1);
			this.fLoadMenu.MenuItems.Add(m);
		}

		private void LoadRainbow(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.Rainbow);
		}

		private void LoadColorArray(Color [] c) {
			this.fRGBBox.Items.Clear();
			for ( int i = 0; i < c.Length; i++ ) {
				string r = c[i].R.ToString();
				r = this.FillString(r,3);
				string g = c[i].G.ToString();
				g = this.FillString(g,3);
				string b = c[i].B.ToString();
				b = this.FillString(b,3);
				this.fRGBBox.Items.Add("rgb["+r+","+g+","+b+"]");
			}
			this.UpdateColorScheme();
		}

		private void LoadStripes(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.Stripes);
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.fLoadMenu.Show(this.tabControl1,new Point(this.fLoadButton.Location.X+4+this.fLoadButton.Width,this.fLoadButton.Location.Y-2+this.fLoadButton.Height));
		}
	}
}
