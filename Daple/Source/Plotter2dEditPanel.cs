using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Daple.Expressions;

namespace Daple.Plotting.TwoD.Controls {

	/// <summary>
	/// Summary description for Plotter2dEditPanel.
	/// </summary>
	public class Plotter2dEditPanel : System.Windows.Forms.UserControl {
		
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.NumericUpDown fXPointsCalculated2d;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown fEditLineThickness2d;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.ComboBox fEditLineQuality2d;
		private System.Windows.Forms.Label label28;
		protected System.Windows.Forms.CheckBox checkBox1;
		protected System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox fEditExpressionBox2d;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected ListBox fExpressionList;
		protected Plotter2d fPlotter;

		public Plotter2dEditPanel() {
			InitializeComponent();
			this.fEditExpressionBox2d.Font = Manager.Font;
		}

		public void SetListBox(ListBox b) {
			this.fExpressionList = b;
		}

		public void SetPlotter(Plotter2d p) {
			this.fPlotter = p;
		}

		public virtual void UpdateFromPlotter() {
			this.fEditExpressionBox2d.Text = this.fPlotter.pExpression.ToString();
			this.fXPointsCalculated2d.Value = (decimal)this.fPlotter.pXPoints;
			this.fEditLineThickness2d.Value = (decimal)this.fPlotter.pPen.Width;
			if ( this.fPlotter.pLineQuality == SmoothingMode.HighQuality ) {
				this.fEditLineQuality2d.SelectedIndex = 0;
			} else if ( this.fPlotter.pLineQuality == SmoothingMode.AntiAlias ) {
				this.fEditLineQuality2d.SelectedIndex = 1;
			} else {
				this.fEditLineQuality2d.SelectedIndex = 2;
			}
		}

		public virtual void ApplyToPlotter() {
			this.fPlotter.pIsVisible = this.checkBox1.Checked;
			this.fPlotter.pExpression = new Expression(this.fEditExpressionBox2d.Text);
			this.fExpressionList.Items[this.fExpressionList.SelectedIndex] = this.fEditExpressionBox2d.Text;
			this.fPlotter.pXPoints = (int)this.fXPointsCalculated2d.Value;
			this.fPlotter.pPen.Width = (int)this.fEditLineThickness2d.Value;
			if ( this.fEditLineQuality2d.SelectedIndex == 0 ) {
				this.fPlotter.pLineQuality = SmoothingMode.HighQuality;
			} else if ( this.fEditLineQuality2d.SelectedIndex == 1 ) {
				this.fPlotter.pLineQuality = SmoothingMode.AntiAlias;
			} else if ( this.fEditLineQuality2d.SelectedIndex == 2 ) {
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label27 = new System.Windows.Forms.Label();
			this.fXPointsCalculated2d = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fEditLineThickness2d = new System.Windows.Forms.NumericUpDown();
			this.label26 = new System.Windows.Forms.Label();
			this.fEditLineQuality2d = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label25 = new System.Windows.Forms.Label();
			this.fEditExpressionBox2d = new System.Windows.Forms.TextBox();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fXPointsCalculated2d)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fEditLineThickness2d)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label27);
			this.groupBox3.Controls.Add(this.fXPointsCalculated2d);
			this.groupBox3.Location = new System.Drawing.Point(8, 216);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(240, 80);
			this.groupBox3.TabIndex = 60;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Accuracy";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(72, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(104, 16);
			this.label27.TabIndex = 38;
			this.label27.Text = "Points Calculated";
			// 
			// fXPointsCalculated2d
			// 
			this.fXPointsCalculated2d.Location = new System.Drawing.Point(72, 40);
			this.fXPointsCalculated2d.Maximum = new System.Decimal(new int[] {
																				 1000,
																				 0,
																				 0,
																				 0});
			this.fXPointsCalculated2d.Minimum = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.fXPointsCalculated2d.Name = "fXPointsCalculated2d";
			this.fXPointsCalculated2d.Size = new System.Drawing.Size(88, 20);
			this.fXPointsCalculated2d.TabIndex = 39;
			this.fXPointsCalculated2d.Value = new System.Decimal(new int[] {
																			   100,
																			   0,
																			   0,
																			   0});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.fEditLineThickness2d);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.fEditLineQuality2d);
			this.groupBox2.Controls.Add(this.label28);
			this.groupBox2.Location = new System.Drawing.Point(8, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 88);
			this.groupBox2.TabIndex = 59;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Plot Line";
			// 
			// fEditLineThickness2d
			// 
			this.fEditLineThickness2d.Location = new System.Drawing.Point(16, 48);
			this.fEditLineThickness2d.Maximum = new System.Decimal(new int[] {
																				 10,
																				 0,
																				 0,
																				 0});
			this.fEditLineThickness2d.Minimum = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.fEditLineThickness2d.Name = "fEditLineThickness2d";
			this.fEditLineThickness2d.Size = new System.Drawing.Size(88, 20);
			this.fEditLineThickness2d.TabIndex = 41;
			this.fEditLineThickness2d.Value = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(16, 32);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(104, 16);
			this.label26.TabIndex = 40;
			this.label26.Text = "Line Thickness";
			// 
			// fEditLineQuality2d
			// 
			this.fEditLineQuality2d.Items.AddRange(new object[] {
																	"High",
																	"Medium",
																	"Low"});
			this.fEditLineQuality2d.Location = new System.Drawing.Point(136, 48);
			this.fEditLineQuality2d.Name = "fEditLineQuality2d";
			this.fEditLineQuality2d.Size = new System.Drawing.Size(88, 21);
			this.fEditLineQuality2d.TabIndex = 34;
			this.fEditLineQuality2d.Text = "Solid";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(136, 32);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(100, 16);
			this.label28.TabIndex = 37;
			this.label28.Text = "Line Quality";
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(96, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(64, 24);
			this.checkBox1.TabIndex = 57;
			this.checkBox1.Text = "Visible";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(8, 48);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 16);
			this.label25.TabIndex = 56;
			this.label25.Text = "Expression";
			// 
			// fEditExpressionBox2d
			// 
			this.fEditExpressionBox2d.Location = new System.Drawing.Point(8, 64);
			this.fEditExpressionBox2d.Name = "fEditExpressionBox2d";
			this.fEditExpressionBox2d.Size = new System.Drawing.Size(240, 20);
			this.fEditExpressionBox2d.TabIndex = 55;
			this.fEditExpressionBox2d.Text = "";
			// 
			// Plotter2dEditPanel
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.fEditExpressionBox2d);
			this.Name = "Plotter2dEditPanel";
			this.Size = new System.Drawing.Size(256, 430);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fXPointsCalculated2d)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fEditLineThickness2d)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e) {
			bool b = this.checkBox1.Checked;

			this.fEditExpressionBox2d.Enabled = b;
			this.fEditLineQuality2d.Enabled = b;
			this.fEditLineThickness2d.Enabled = b;
			this.fXPointsCalculated2d.Enabled = b;
		}
	}
}
