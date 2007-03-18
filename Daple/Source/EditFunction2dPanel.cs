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
	/// Summary description for EditPlotter2dPanel.
	/// </summary>
	public class EditFunction2dPanel : Plotter2dEditPanel {

		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private Daple.FunctionParseField fMinX2d;
		private Daple.FunctionParseField fMaxX2d;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditFunction2dPanel() {
			InitializeComponent();
			this.checkBox1.CheckStateChanged += new EventHandler(checkBox1_CheckStateChanged);
		}

		public override void UpdateFromPlotter() {
			base.UpdateFromPlotter();
			this.fMinX2d.Value = (float)this.fPlotter.pMinX;
			this.fMaxX2d.Value = (float)this.fPlotter.pMaxX;
			this.checkBox2.Checked = this.fPlotter.pIsAxisLockedBounds;
		}

		public override void ApplyToPlotter() {
			base.ApplyToPlotter();
			this.fPlotter.pMinX = (float)this.fMinX2d.Value;
			this.fPlotter.pMaxX = (float)this.fMaxX2d.Value;
			this.fPlotter.pIsAxisLockedBounds = this.checkBox2.Checked;
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
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.fMinX2d = new Daple.FunctionParseField();
			this.fMaxX2d = new Daple.FunctionParseField();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Name = "checkBox1";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(136, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(80, 16);
			this.label23.TabIndex = 47;
			this.label23.Text = "Maximum X";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(24, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(72, 16);
			this.label24.TabIndex = 46;
			this.label24.Text = "Minimum X";
			// 
			// fMinX2d
			// 
			this.fMinX2d.Location = new System.Drawing.Point(24, 64);
			this.fMinX2d.Name = "fMinX2d";
			this.fMinX2d.Size = new System.Drawing.Size(80, 20);
			this.fMinX2d.TabIndex = 48;
			this.fMinX2d.Value = 0F;
			// 
			// fMaxX2d
			// 
			this.fMaxX2d.Location = new System.Drawing.Point(136, 64);
			this.fMaxX2d.Name = "fMaxX2d";
			this.fMaxX2d.Size = new System.Drawing.Size(80, 20);
			this.fMaxX2d.TabIndex = 49;
			this.fMaxX2d.Value = 0F;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(56, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(128, 24);
			this.checkBox2.TabIndex = 51;
			this.checkBox2.Text = "Axis Locked Bounds";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fMaxX2d);
			this.groupBox1.Controls.Add(this.fMinX2d);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Location = new System.Drawing.Point(8, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 104);
			this.groupBox1.TabIndex = 52;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Independent Variable";
			// 
			// EditFunction2dPanel
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "EditFunction2dPanel";
			this.Size = new System.Drawing.Size(256, 438);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.checkBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e) {
			bool b = !this.checkBox2.Checked;

			this.fMinX2d.Enabled = b;
			this.fMaxX2d.Enabled = b;
		}

		private void checkBox1_CheckStateChanged(object sender, EventArgs e) {
			bool b = this.checkBox1.Checked;

			this.fMinX2d.Enabled = b && !this.checkBox2.Checked;
			this.fMaxX2d.Enabled = b && !this.checkBox2.Checked;
			this.checkBox2.Enabled = b;
		}
	}
}
