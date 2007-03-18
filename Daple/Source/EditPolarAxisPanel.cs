using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {
	
	/// <summary>
	/// Summary description for EditPolarAxisPanel.
	/// </summary>
	public class EditPolarAxisPanel : System.Windows.Forms.UserControl {
		
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.NumericUpDown fAngularFont;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Button fAngularLabelColor;
		private System.Windows.Forms.CheckBox fAngularLabelBool;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.Button fAngularLineColor;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.NumericUpDown fAngularLineThickness;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.NumericUpDown fAngularDivisions;
		private System.Windows.Forms.CheckBox fAngularBool;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Button fRadialLineColor;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.NumericUpDown fRadialLineThickness;
		private System.Windows.Forms.CheckBox fRadialBool;
		private System.Windows.Forms.CheckBox fPolarAxisBool;

		private PolarAxis fAxis;
		private ColorDialog fColorDialog;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditPolarAxisPanel(PolarAxis p, ColorDialog cd) {
			this.fAxis = p;
			this.fColorDialog = cd;
			InitializeComponent();
		}

		public void UpdateFromAxis() {
			this.fPolarAxisBool.Checked = this.fAxis.pIsVisible;
			this.fRadialBool.Checked = this.fAxis.pAreRadialDivisionsDrawn;
			this.fRadialLineColor.BackColor = this.fAxis.pRadialPen.Color;
			this.fRadialLineThickness.Value = (decimal)this.fAxis.pRadialPen.Width;
			this.fAngularBool.Checked = this.fAxis.pAreAngularDivisionsDrawn;
		}

		public void ApplyToAxis() {
			this.fAxis.pIsVisible = this.fPolarAxisBool.Checked;
			this.fAxis.pAreRadialDivisionsDrawn = this.fRadialBool.Checked;
			this.fAxis.pAreAngularDivisionsDrawn = this.fAngularBool.Checked;
			this.fAxis.pAngularPen.Width = (int)this.fAngularLineThickness.Value;
			this.fAxis.pAngularPen.Color = this.fAngularLineColor.BackColor;
			this.fAxis.pRadialPen.Width = (int)this.fRadialLineThickness.Value;
			this.fAxis.pRadialPen.Color = this.fRadialLineColor.BackColor;
			this.fAxis.pAngularDivisions = (int)this.fAngularDivisions.Value;
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
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.label79 = new System.Windows.Forms.Label();
			this.fAngularFont = new System.Windows.Forms.NumericUpDown();
			this.label80 = new System.Windows.Forms.Label();
			this.fAngularLabelColor = new System.Windows.Forms.Button();
			this.fAngularLabelBool = new System.Windows.Forms.CheckBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.fAngularLineColor = new System.Windows.Forms.Button();
			this.label81 = new System.Windows.Forms.Label();
			this.label82 = new System.Windows.Forms.Label();
			this.fAngularLineThickness = new System.Windows.Forms.NumericUpDown();
			this.label78 = new System.Windows.Forms.Label();
			this.fAngularDivisions = new System.Windows.Forms.NumericUpDown();
			this.fAngularBool = new System.Windows.Forms.CheckBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.fRadialLineColor = new System.Windows.Forms.Button();
			this.label76 = new System.Windows.Forms.Label();
			this.label77 = new System.Windows.Forms.Label();
			this.fRadialLineThickness = new System.Windows.Forms.NumericUpDown();
			this.fRadialBool = new System.Windows.Forms.CheckBox();
			this.fPolarAxisBool = new System.Windows.Forms.CheckBox();
			this.groupBox14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fAngularFont)).BeginInit();
			this.groupBox13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fAngularLineThickness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fAngularDivisions)).BeginInit();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fRadialLineThickness)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.label79);
			this.groupBox14.Controls.Add(this.fAngularFont);
			this.groupBox14.Controls.Add(this.label80);
			this.groupBox14.Controls.Add(this.fAngularLabelColor);
			this.groupBox14.Controls.Add(this.fAngularLabelBool);
			this.groupBox14.Location = new System.Drawing.Point(8, 328);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(240, 100);
			this.groupBox14.TabIndex = 9;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Labels";
			// 
			// label79
			// 
			this.label79.Location = new System.Drawing.Point(32, 72);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(72, 16);
			this.label79.TabIndex = 25;
			this.label79.Text = "Label Color";
			// 
			// fAngularFont
			// 
			this.fAngularFont.Location = new System.Drawing.Point(136, 48);
			this.fAngularFont.Maximum = new System.Decimal(new int[] {
																		 30,
																		 0,
																		 0,
																		 0});
			this.fAngularFont.Minimum = new System.Decimal(new int[] {
																		 6,
																		 0,
																		 0,
																		 0});
			this.fAngularFont.Name = "fAngularFont";
			this.fAngularFont.Size = new System.Drawing.Size(80, 20);
			this.fAngularFont.TabIndex = 24;
			this.fAngularFont.Value = new System.Decimal(new int[] {
																	   6,
																	   0,
																	   0,
																	   0});
			// 
			// label80
			// 
			this.label80.Location = new System.Drawing.Point(32, 48);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(88, 16);
			this.label80.TabIndex = 23;
			this.label80.Text = "Label Font Size";
			// 
			// fAngularLabelColor
			// 
			this.fAngularLabelColor.Location = new System.Drawing.Point(136, 72);
			this.fAngularLabelColor.Name = "fAngularLabelColor";
			this.fAngularLabelColor.Size = new System.Drawing.Size(80, 16);
			this.fAngularLabelColor.TabIndex = 22;
			this.fAngularLabelColor.Text = "...";
			this.fAngularLabelColor.Click += new System.EventHandler(this.fAngularLabelColor_Click);
			// 
			// fAngularLabelBool
			// 
			this.fAngularLabelBool.Location = new System.Drawing.Point(52, 16);
			this.fAngularLabelBool.Name = "fAngularLabelBool";
			this.fAngularLabelBool.Size = new System.Drawing.Size(136, 24);
			this.fAngularLabelBool.TabIndex = 0;
			this.fAngularLabelBool.Text = "Show Angular Labels";
			this.fAngularLabelBool.CheckedChanged += new System.EventHandler(this.fAngularLabelBool_CheckedChanged);
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.fAngularLineColor);
			this.groupBox13.Controls.Add(this.label81);
			this.groupBox13.Controls.Add(this.label82);
			this.groupBox13.Controls.Add(this.fAngularLineThickness);
			this.groupBox13.Controls.Add(this.label78);
			this.groupBox13.Controls.Add(this.fAngularDivisions);
			this.groupBox13.Controls.Add(this.fAngularBool);
			this.groupBox13.Location = new System.Drawing.Point(8, 184);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(240, 128);
			this.groupBox13.TabIndex = 8;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Angular Divisions";
			// 
			// fAngularLineColor
			// 
			this.fAngularLineColor.Location = new System.Drawing.Point(136, 96);
			this.fAngularLineColor.Name = "fAngularLineColor";
			this.fAngularLineColor.Size = new System.Drawing.Size(80, 16);
			this.fAngularLineColor.TabIndex = 29;
			this.fAngularLineColor.Text = "...";
			this.fAngularLineColor.Click += new System.EventHandler(this.fAngularLineColor_Click);
			// 
			// label81
			// 
			this.label81.Location = new System.Drawing.Point(24, 96);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(80, 16);
			this.label81.TabIndex = 28;
			this.label81.Text = "Line Color";
			// 
			// label82
			// 
			this.label82.Location = new System.Drawing.Point(24, 72);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(88, 16);
			this.label82.TabIndex = 27;
			this.label82.Text = "Line Thickness";
			// 
			// fAngularLineThickness
			// 
			this.fAngularLineThickness.Location = new System.Drawing.Point(136, 72);
			this.fAngularLineThickness.Maximum = new System.Decimal(new int[] {
																				  10,
																				  0,
																				  0,
																				  0});
			this.fAngularLineThickness.Minimum = new System.Decimal(new int[] {
																				  1,
																				  0,
																				  0,
																				  0});
			this.fAngularLineThickness.Name = "fAngularLineThickness";
			this.fAngularLineThickness.Size = new System.Drawing.Size(80, 20);
			this.fAngularLineThickness.TabIndex = 26;
			this.fAngularLineThickness.Value = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				0});
			// 
			// label78
			// 
			this.label78.Location = new System.Drawing.Point(24, 48);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(72, 16);
			this.label78.TabIndex = 20;
			this.label78.Text = "Divisions";
			// 
			// fAngularDivisions
			// 
			this.fAngularDivisions.Location = new System.Drawing.Point(136, 48);
			this.fAngularDivisions.Maximum = new System.Decimal(new int[] {
																			  10,
																			  0,
																			  0,
																			  0});
			this.fAngularDivisions.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.fAngularDivisions.Name = "fAngularDivisions";
			this.fAngularDivisions.Size = new System.Drawing.Size(80, 20);
			this.fAngularDivisions.TabIndex = 19;
			this.fAngularDivisions.Value = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			// 
			// fAngularBool
			// 
			this.fAngularBool.Location = new System.Drawing.Point(52, 16);
			this.fAngularBool.Name = "fAngularBool";
			this.fAngularBool.Size = new System.Drawing.Size(148, 24);
			this.fAngularBool.TabIndex = 1;
			this.fAngularBool.Text = "Show Angular Divisions";
			this.fAngularBool.CheckedChanged += new System.EventHandler(this.fAngularBool_CheckedChanged);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.fRadialLineColor);
			this.groupBox12.Controls.Add(this.label76);
			this.groupBox12.Controls.Add(this.label77);
			this.groupBox12.Controls.Add(this.fRadialLineThickness);
			this.groupBox12.Controls.Add(this.fRadialBool);
			this.groupBox12.Location = new System.Drawing.Point(8, 64);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(240, 104);
			this.groupBox12.TabIndex = 7;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Radial Divisions";
			// 
			// fRadialLineColor
			// 
			this.fRadialLineColor.Location = new System.Drawing.Point(136, 72);
			this.fRadialLineColor.Name = "fRadialLineColor";
			this.fRadialLineColor.Size = new System.Drawing.Size(80, 16);
			this.fRadialLineColor.TabIndex = 21;
			this.fRadialLineColor.Text = "...";
			this.fRadialLineColor.Click += new System.EventHandler(this.fRadialLineColor_Click);
			// 
			// label76
			// 
			this.label76.Location = new System.Drawing.Point(24, 72);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(80, 16);
			this.label76.TabIndex = 20;
			this.label76.Text = "Line Color";
			// 
			// label77
			// 
			this.label77.Location = new System.Drawing.Point(24, 48);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(88, 16);
			this.label77.TabIndex = 19;
			this.label77.Text = "Line Thickness";
			// 
			// fRadialLineThickness
			// 
			this.fRadialLineThickness.Location = new System.Drawing.Point(136, 48);
			this.fRadialLineThickness.Maximum = new System.Decimal(new int[] {
																				 10,
																				 0,
																				 0,
																				 0});
			this.fRadialLineThickness.Minimum = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.fRadialLineThickness.Name = "fRadialLineThickness";
			this.fRadialLineThickness.Size = new System.Drawing.Size(80, 20);
			this.fRadialLineThickness.TabIndex = 18;
			this.fRadialLineThickness.Value = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			// 
			// fRadialBool
			// 
			this.fRadialBool.Location = new System.Drawing.Point(52, 16);
			this.fRadialBool.Name = "fRadialBool";
			this.fRadialBool.Size = new System.Drawing.Size(136, 24);
			this.fRadialBool.TabIndex = 0;
			this.fRadialBool.Text = "Show Radial Divisions";
			this.fRadialBool.CheckedChanged += new System.EventHandler(this.fRadialBool_CheckedChanged);
			// 
			// fPolarAxisBool
			// 
			this.fPolarAxisBool.Checked = true;
			this.fPolarAxisBool.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fPolarAxisBool.Location = new System.Drawing.Point(88, 24);
			this.fPolarAxisBool.Name = "fPolarAxisBool";
			this.fPolarAxisBool.Size = new System.Drawing.Size(80, 24);
			this.fPolarAxisBool.TabIndex = 6;
			this.fPolarAxisBool.Text = "Visible";
			this.fPolarAxisBool.CheckedChanged += new System.EventHandler(this.fPolarAxisBool_CheckedChanged);
			// 
			// EditPolarAxisPanel
			// 
			this.Controls.Add(this.groupBox14);
			this.Controls.Add(this.groupBox13);
			this.Controls.Add(this.groupBox12);
			this.Controls.Add(this.fPolarAxisBool);
			this.Name = "EditPolarAxisPanel";
			this.Size = new System.Drawing.Size(256, 438);
			this.groupBox14.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fAngularFont)).EndInit();
			this.groupBox13.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fAngularLineThickness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fAngularDivisions)).EndInit();
			this.groupBox12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fRadialLineThickness)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void fPolarAxisBool_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fPolarAxisBool.Checked;

			this.fRadialBool.Enabled = b;
			this.fRadialLineColor.Enabled = b && this.fRadialBool.Checked;
			this.fRadialLineThickness.Enabled = b && this.fRadialBool.Checked;
			this.fAngularBool.Enabled = b;
			this.fAngularDivisions.Enabled = b && this.fAngularBool.Checked;
			this.fAngularFont.Enabled = b && this.fAngularLabelBool.Checked && this.fAngularBool.Checked;
			this.fAngularLabelBool.Enabled = b && this.fAngularBool.Checked;
			this.fAngularLineColor.Enabled = b && this.fAngularBool.Checked;
			this.fAngularLineThickness.Enabled = b && this.fAngularBool.Checked;
		}

		private void fRadialBool_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fRadialBool.Checked;

			this.fRadialLineColor.Enabled = b;
			this.fRadialLineThickness.Enabled = b;
		}

		private void fAngularBool_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fAngularBool.Checked;

			this.fAngularLabelBool.Enabled = b;
			this.fAngularLabelColor.Enabled = b && this.fAngularLabelBool.Checked;
			this.fAngularFont.Enabled = b && this.fAngularLabelBool.Checked;
			this.fAngularDivisions.Enabled = b;
			this.fAngularLineColor.Enabled = b && this.fAngularBool.Checked;
			this.fAngularLineThickness.Enabled = b && this.fAngularBool.Checked;
		}

		private void fAngularLabelBool_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.fAngularLabelBool.Checked;

			this.fAngularFont.Enabled = b;
			this.fAngularLabelColor.Enabled = b;
		}

		private void fRadialLineColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fRadialLineColor.BackColor = this.fColorDialog.Color;
		}

		private void fAngularLineColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fAngularLineColor.BackColor = this.fColorDialog.Color;
		}

		private void fAngularLabelColor_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fAngularLabelColor.BackColor = this.fColorDialog.Color;
		}
	}
}
