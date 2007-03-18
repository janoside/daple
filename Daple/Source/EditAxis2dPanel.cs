using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {
	/// <summary>
	/// Summary description for EditAxis2dPanel.
	/// </summary>
	public class EditAxis2dPanel : System.Windows.Forms.UserControl {

		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.NumericUpDown fLabelFontSize;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Button fLabelColor;
		private System.Windows.Forms.CheckBox fLabelBool;
		private System.Windows.Forms.CheckBox fVisibility;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button fColor;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.NumericUpDown fLineThickness;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.NumericUpDown fMinorLength;
		private System.Windows.Forms.NumericUpDown fMajorLength;
		private System.Windows.Forms.CheckBox fMajorBool;
		private System.Windows.Forms.CheckBox fMinorBool;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button fGridColor;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.NumericUpDown fGridThickness;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.ComboBox fGridType;
		private System.Windows.Forms.CheckBox fGridBool;

		private Axis2d fAxis;
		private ColorDialog fColorDialog;
		private System.Windows.Forms.NumericUpDown fMinorPerMajor;
		private Daple.FunctionParseField fMax;
		private Daple.FunctionParseField fMin;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditAxis2dPanel(Axis2d a, ColorDialog cd) {
			this.fAxis = a;
			this.fColorDialog = cd;
			InitializeComponent();
		}

		public void UpdateFromAxis() {
			this.fMin.Value = (float)this.fAxis.pMin;
			this.fMax.Value = (float)this.fAxis.pMax;
			this.fLineThickness.Value = (int)this.fAxis.pPen.Width;
			this.fColor.BackColor = this.fAxis.pPen.Color;
			this.fMajorBool.Checked = this.fAxis.pAreMajorTicksDrawn;
			this.fMinorBool.Checked = this.fAxis.pAreMinorTicksDrawn;
			this.fMinorLength.Value = this.fAxis.pMinorTickLength;
			this.fGridColor.BackColor = this.fAxis.pGridPen.Color;
			this.fGridThickness.Value = (decimal)this.fAxis.pGridPen.Width;
			this.fGridBool.Checked = this.fAxis.pIsGridDrawn;
			this.fLabelColor.BackColor = this.fAxis.pLabelColor;
			this.fLabelBool.Checked = this.fAxis.pAreLabelsDrawn;
			this.fLabelFontSize.Value = this.fAxis.pLabelFontSize;
			this.fMinorPerMajor.Value = this.fAxis.pMinorPerMajor;
		}

		public void ApplyToAxis() {
			this.fAxis.pIsVisible = this.fVisibility.Checked;
			this.fAxis.pMin = (double)this.fMin.Value;
			this.fAxis.pMax = (double)this.fMax.Value;
			this.fAxis.pPen.Width = (int)this.fLineThickness.Value;
			this.fAxis.pPen.Color = this.fColor.BackColor;
			this.fAxis.pAreMajorTicksDrawn = this.fMajorBool.Checked;
			this.fAxis.pAreMinorTicksDrawn = this.fMinorBool.Checked;
			this.fAxis.pMinorTickLength = (int)this.fMinorLength.Value;
			this.fAxis.pGridPen.Color = this.fGridColor.BackColor;
			this.fAxis.pGridPen.Width = (int)this.fGridThickness.Value;
			this.fAxis.pIsGridDrawn = this.fGridBool.Checked;
			this.fAxis.pLabelColor = this.fLabelColor.BackColor;
			this.fAxis.pAreLabelsDrawn = this.fLabelBool.Checked;
			this.fAxis.pLabelFontSize = (int)this.fLabelFontSize.Value;
			this.fAxis.pMinorPerMajor = (int)this.fMinorPerMajor.Value;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label65 = new System.Windows.Forms.Label();
			this.fLabelFontSize = new System.Windows.Forms.NumericUpDown();
			this.label66 = new System.Windows.Forms.Label();
			this.fLabelColor = new System.Windows.Forms.Button();
			this.fLabelBool = new System.Windows.Forms.CheckBox();
			this.fVisibility = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.fMin = new Daple.FunctionParseField();
			this.fMax = new Daple.FunctionParseField();
			this.fColor = new System.Windows.Forms.Button();
			this.label52 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.fLineThickness = new System.Windows.Forms.NumericUpDown();
			this.label49 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label51 = new System.Windows.Forms.Label();
			this.fMinorPerMajor = new System.Windows.Forms.NumericUpDown();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.fMinorLength = new System.Windows.Forms.NumericUpDown();
			this.fMajorLength = new System.Windows.Forms.NumericUpDown();
			this.fMajorBool = new System.Windows.Forms.CheckBox();
			this.fMinorBool = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fGridColor = new System.Windows.Forms.Button();
			this.label47 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.fGridThickness = new System.Windows.Forms.NumericUpDown();
			this.label45 = new System.Windows.Forms.Label();
			this.fGridType = new System.Windows.Forms.ComboBox();
			this.fGridBool = new System.Windows.Forms.CheckBox();
			this.panel3.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fLabelFontSize)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fLineThickness)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fMinorPerMajor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fMinorLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fMajorLength)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fGridThickness)).BeginInit();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.AutoScrollMargin = new System.Drawing.Size(0, 20);
			this.panel3.Controls.Add(this.groupBox9);
			this.panel3.Controls.Add(this.fVisibility);
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(256, 430);
			this.panel3.TabIndex = 17;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.label65);
			this.groupBox9.Controls.Add(this.fLabelFontSize);
			this.groupBox9.Controls.Add(this.label66);
			this.groupBox9.Controls.Add(this.fLabelColor);
			this.groupBox9.Controls.Add(this.fLabelBool);
			this.groupBox9.Location = new System.Drawing.Point(8, 456);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(224, 96);
			this.groupBox9.TabIndex = 21;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Labels";
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(16, 72);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(72, 16);
			this.label65.TabIndex = 21;
			this.label65.Text = "Label Color";
			// 
			// fLabelFontSize
			// 
			this.fLabelFontSize.Location = new System.Drawing.Point(120, 48);
			this.fLabelFontSize.Maximum = new System.Decimal(new int[] {
																		   30,
																		   0,
																		   0,
																		   0});
			this.fLabelFontSize.Minimum = new System.Decimal(new int[] {
																		   6,
																		   0,
																		   0,
																		   0});
			this.fLabelFontSize.Name = "fLabelFontSize";
			this.fLabelFontSize.Size = new System.Drawing.Size(80, 20);
			this.fLabelFontSize.TabIndex = 20;
			this.fLabelFontSize.Value = new System.Decimal(new int[] {
																		 6,
																		 0,
																		 0,
																		 0});
			// 
			// label66
			// 
			this.label66.Location = new System.Drawing.Point(16, 48);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(72, 16);
			this.label66.TabIndex = 19;
			this.label66.Text = "Font Size";
			// 
			// fLabelColor
			// 
			this.fLabelColor.Location = new System.Drawing.Point(120, 72);
			this.fLabelColor.Name = "fLabelColor";
			this.fLabelColor.Size = new System.Drawing.Size(80, 16);
			this.fLabelColor.TabIndex = 18;
			this.fLabelColor.Text = "...";
			this.fLabelColor.Click += new System.EventHandler(this.fLabelColor_Click);
			// 
			// fLabelBool
			// 
			this.fLabelBool.Checked = true;
			this.fLabelBool.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fLabelBool.Location = new System.Drawing.Point(64, 16);
			this.fLabelBool.Name = "fLabelBool";
			this.fLabelBool.Size = new System.Drawing.Size(88, 24);
			this.fLabelBool.TabIndex = 0;
			this.fLabelBool.Text = "Show Labels";
			// 
			// fVisibility
			// 
			this.fVisibility.Checked = true;
			this.fVisibility.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fVisibility.Location = new System.Drawing.Point(88, 16);
			this.fVisibility.Name = "fVisibility";
			this.fVisibility.Size = new System.Drawing.Size(80, 24);
			this.fVisibility.TabIndex = 0;
			this.fVisibility.Text = "Visible";
			this.fVisibility.CheckedChanged += new System.EventHandler(this.fVisibility_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.fMin);
			this.groupBox3.Controls.Add(this.fMax);
			this.groupBox3.Controls.Add(this.fColor);
			this.groupBox3.Controls.Add(this.label52);
			this.groupBox3.Controls.Add(this.label50);
			this.groupBox3.Controls.Add(this.fLineThickness);
			this.groupBox3.Controls.Add(this.label49);
			this.groupBox3.Controls.Add(this.label48);
			this.groupBox3.Location = new System.Drawing.Point(8, 56);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(224, 120);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Configuration";
			// 
			// fMin
			// 
			this.fMin.Location = new System.Drawing.Point(120, 24);
			this.fMin.Name = "fMin";
			this.fMin.Size = new System.Drawing.Size(80, 20);
			this.fMin.TabIndex = 18;
			this.fMin.Value = 0F;
			// 
			// fMax
			// 
			this.fMax.Location = new System.Drawing.Point(120, 48);
			this.fMax.Name = "fMax";
			this.fMax.Size = new System.Drawing.Size(80, 20);
			this.fMax.TabIndex = 17;
			this.fMax.Value = 0F;
			// 
			// fColor
			// 
			this.fColor.Location = new System.Drawing.Point(120, 96);
			this.fColor.Name = "fColor";
			this.fColor.Size = new System.Drawing.Size(80, 16);
			this.fColor.TabIndex = 16;
			this.fColor.Text = "...";
			this.fColor.Click += new System.EventHandler(this.fColor_Click);
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(16, 96);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(80, 16);
			this.label52.TabIndex = 15;
			this.label52.Text = "Line Color";
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(16, 72);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(88, 16);
			this.label50.TabIndex = 11;
			this.label50.Text = "Line Thickness";
			// 
			// fLineThickness
			// 
			this.fLineThickness.Location = new System.Drawing.Point(120, 72);
			this.fLineThickness.Name = "fLineThickness";
			this.fLineThickness.Size = new System.Drawing.Size(80, 20);
			this.fLineThickness.TabIndex = 10;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(16, 48);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(80, 16);
			this.label49.TabIndex = 9;
			this.label49.Text = "Maximum";
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(16, 24);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(80, 16);
			this.label48.TabIndex = 8;
			this.label48.Text = "Minimum";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label51);
			this.groupBox1.Controls.Add(this.fMinorPerMajor);
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.label43);
			this.groupBox1.Controls.Add(this.fMinorLength);
			this.groupBox1.Controls.Add(this.fMajorLength);
			this.groupBox1.Controls.Add(this.fMajorBool);
			this.groupBox1.Controls.Add(this.fMinorBool);
			this.groupBox1.Location = new System.Drawing.Point(8, 184);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 136);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tick Marks";
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(16, 104);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(88, 16);
			this.label51.TabIndex = 17;
			this.label51.Text = "Minor / Major";
			// 
			// fMinorPerMajor
			// 
			this.fMinorPerMajor.Location = new System.Drawing.Point(120, 104);
			this.fMinorPerMajor.Maximum = new System.Decimal(new int[] {
																		   50,
																		   0,
																		   0,
																		   0});
			this.fMinorPerMajor.Name = "fMinorPerMajor";
			this.fMinorPerMajor.Size = new System.Drawing.Size(80, 20);
			this.fMinorPerMajor.TabIndex = 16;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(16, 80);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(80, 16);
			this.label44.TabIndex = 15;
			this.label44.Text = "Minor Length";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(16, 56);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(80, 16);
			this.label43.TabIndex = 14;
			this.label43.Text = "Major Length";
			// 
			// fMinorLength
			// 
			this.fMinorLength.Increment = new System.Decimal(new int[] {
																		   2,
																		   0,
																		   0,
																		   0});
			this.fMinorLength.Location = new System.Drawing.Point(120, 80);
			this.fMinorLength.Name = "fMinorLength";
			this.fMinorLength.Size = new System.Drawing.Size(80, 20);
			this.fMinorLength.TabIndex = 13;
			this.fMinorLength.Value = new System.Decimal(new int[] {
																	   2,
																	   0,
																	   0,
																	   0});
			// 
			// fMajorLength
			// 
			this.fMajorLength.Location = new System.Drawing.Point(120, 56);
			this.fMajorLength.Name = "fMajorLength";
			this.fMajorLength.Size = new System.Drawing.Size(80, 20);
			this.fMajorLength.TabIndex = 12;
			// 
			// fMajorBool
			// 
			this.fMajorBool.Checked = true;
			this.fMajorBool.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fMajorBool.Location = new System.Drawing.Point(24, 24);
			this.fMajorBool.Name = "fMajorBool";
			this.fMajorBool.Size = new System.Drawing.Size(88, 24);
			this.fMajorBool.TabIndex = 10;
			this.fMajorBool.Text = "Major Ticks";
			this.fMajorBool.CheckedChanged += new System.EventHandler(this.fMajorBool_CheckedChanged);
			// 
			// fMinorBool
			// 
			this.fMinorBool.Checked = true;
			this.fMinorBool.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fMinorBool.Location = new System.Drawing.Point(120, 24);
			this.fMinorBool.Name = "fMinorBool";
			this.fMinorBool.Size = new System.Drawing.Size(88, 24);
			this.fMinorBool.TabIndex = 11;
			this.fMinorBool.Text = "Minor Ticks";
			this.fMinorBool.CheckedChanged += new System.EventHandler(this.fMinorBool_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.fGridColor);
			this.groupBox2.Controls.Add(this.label47);
			this.groupBox2.Controls.Add(this.label46);
			this.groupBox2.Controls.Add(this.fGridThickness);
			this.groupBox2.Controls.Add(this.label45);
			this.groupBox2.Controls.Add(this.fGridType);
			this.groupBox2.Controls.Add(this.fGridBool);
			this.groupBox2.Location = new System.Drawing.Point(8, 328);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 120);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Grid";
			// 
			// fGridColor
			// 
			this.fGridColor.Location = new System.Drawing.Point(120, 96);
			this.fGridColor.Name = "fGridColor";
			this.fGridColor.Size = new System.Drawing.Size(80, 16);
			this.fGridColor.TabIndex = 17;
			this.fGridColor.Text = "...";
			this.fGridColor.Click += new System.EventHandler(this.fGridColor_Click);
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(16, 96);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(80, 16);
			this.label47.TabIndex = 14;
			this.label47.Text = "Grid Color";
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(16, 72);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(88, 16);
			this.label46.TabIndex = 13;
			this.label46.Text = "Line Thickness";
			// 
			// fGridThickness
			// 
			this.fGridThickness.Location = new System.Drawing.Point(120, 72);
			this.fGridThickness.Maximum = new System.Decimal(new int[] {
																		   10,
																		   0,
																		   0,
																		   0});
			this.fGridThickness.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.fGridThickness.Name = "fGridThickness";
			this.fGridThickness.Size = new System.Drawing.Size(80, 20);
			this.fGridThickness.TabIndex = 12;
			this.fGridThickness.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(16, 48);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(64, 16);
			this.label45.TabIndex = 11;
			this.label45.Text = "Type";
			// 
			// fGridType
			// 
			this.fGridType.Items.AddRange(new object[] {
														   "Major Tick",
														   "Minor Tick"});
			this.fGridType.Location = new System.Drawing.Point(120, 48);
			this.fGridType.Name = "fGridType";
			this.fGridType.Size = new System.Drawing.Size(80, 21);
			this.fGridType.TabIndex = 10;
			this.fGridType.Text = "Major Tick";
			// 
			// fGridBool
			// 
			this.fGridBool.Checked = true;
			this.fGridBool.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fGridBool.Location = new System.Drawing.Point(72, 16);
			this.fGridBool.Name = "fGridBool";
			this.fGridBool.Size = new System.Drawing.Size(80, 24);
			this.fGridBool.TabIndex = 9;
			this.fGridBool.Text = "Show Grid";
			// 
			// EditAxis2dPanel
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.panel3);
			this.Name = "EditAxis2dPanel";
			this.Size = new System.Drawing.Size(256, 430);
			this.panel3.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fLabelFontSize)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fLineThickness)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fMinorPerMajor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fMinorLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fMajorLength)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fGridThickness)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void fVisibility_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fVisibility.Checked;

			this.fColor.Enabled = b;
			this.fGridBool.Enabled = b;
			this.fGridColor.Enabled = b && this.fGridBool.Checked;
			this.fGridThickness.Enabled = b && this.fGridBool.Checked;
			this.fGridType.Enabled = b && this.fGridBool.Checked;
			this.fLabelBool.Enabled = b;
			this.fLabelColor.Enabled = b && this.fLabelBool.Checked;
			this.fLabelFontSize.Enabled = b && this.fLabelBool.Checked;
			this.fLineThickness.Enabled = b;
			this.fMajorBool.Enabled = b;
			this.fMinorBool.Enabled = b;
			this.fMin.Enabled = b;
			this.fMax.Enabled = b;
			this.fMajorLength.Enabled = b && this.fMajorBool.Checked;
			this.fMinorLength.Enabled = b && this.fMinorBool.Checked;
			this.fMinorPerMajor.Enabled = b && this.fMinorBool.Checked;
		}

		private void fMajorBool_CheckedChanged(object sender, System.EventArgs e) {
			this.fMajorLength.Enabled = this.fMajorBool.Checked;
		}

		private void fMinorBool_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fMinorBool.Checked;

			this.fMinorLength.Enabled = b;
			this.fMinorPerMajor.Enabled = b;
		}

		private void fColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fColor.BackColor = this.fColorDialog.Color;
		}

		private void fGridColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fGridColor.BackColor = this.fColorDialog.Color;
		}

		private void fLabelColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fLabelColor.BackColor = this.fColorDialog.Color;
		}
	}
}
