using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {
	
	/// <summary>
	/// Summary description for EditPolarPlotter2dPanel.
	/// </summary>
	public class EditPolar2dPanel : Plotter2dEditPanel {

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Daple.FunctionParseField functionParseField1;
		private Daple.FunctionParseField functionParseField2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditPolar2dPanel() {
			InitializeComponent();
			this.functionParseField2.Value = (float)(2 * MathUtil.Pi);
		}

		public override void UpdateFromPlotter() {
			base.UpdateFromPlotter();
			this.functionParseField1.Value = (float)this.fPlotter.pMinX;
			this.functionParseField2.Value = (float)this.fPlotter.pMaxX;
		}

		public override void ApplyToPlotter() {
			base.ApplyToPlotter();
			this.fPlotter.pMinX = this.functionParseField1.Value;
			this.fPlotter.pMaxX = this.functionParseField2.Value;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.functionParseField2 = new Daple.FunctionParseField();
			this.functionParseField1 = new Daple.FunctionParseField();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Name = "checkBox1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.functionParseField2);
			this.groupBox1.Controls.Add(this.functionParseField1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Independent Variable";
			// 
			// functionParseField2
			// 
			this.functionParseField2.Location = new System.Drawing.Point(136, 48);
			this.functionParseField2.Name = "functionParseField2";
			this.functionParseField2.Size = new System.Drawing.Size(80, 20);
			this.functionParseField2.TabIndex = 3;
			this.functionParseField2.Value = 0F;
			// 
			// functionParseField1
			// 
			this.functionParseField1.Location = new System.Drawing.Point(24, 48);
			this.functionParseField1.Name = "functionParseField1";
			this.functionParseField1.Size = new System.Drawing.Size(80, 20);
			this.functionParseField1.TabIndex = 2;
			this.functionParseField1.Value = 0F;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Maximum Theta";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Minimum Theta";
			// 
			// EditPolar2dPanel
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "EditPolar2dPanel";
			this.Size = new System.Drawing.Size(256, 438);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.checkBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
