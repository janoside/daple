using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Daple.Plotting {
	/// <summary>
	/// Summary description for GraphPanelOptionForm.
	/// </summary>
	public class GraphPanelOptionForm : System.Windows.Forms.Form {

		private GraphPanel fGraphPanel;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.ColorDialog fColorDialog;
		private System.Windows.Forms.Button fPolarOptions;
		private System.Windows.Forms.Button fYOptions;
		private System.Windows.Forms.Button fXOptions;
		private System.Windows.Forms.Button fApplyButton;
		private System.Windows.Forms.Button fCloseButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GraphPanelOptionForm(GraphPanel p) {
			this.fGraphPanel = p;
			InitializeComponent();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fPolarOptions = new System.Windows.Forms.Button();
			this.fYOptions = new System.Windows.Forms.Button();
			this.fXOptions = new System.Windows.Forms.Button();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.fColorDialog = new System.Windows.Forms.ColorDialog();
			this.fCloseButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// fApplyButton
			// 
			this.fApplyButton.Location = new System.Drawing.Point(48, 304);
			this.fApplyButton.Name = "fApplyButton";
			this.fApplyButton.TabIndex = 0;
			this.fApplyButton.Text = "Apply";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fPolarOptions);
			this.groupBox1.Controls.Add(this.fYOptions);
			this.groupBox1.Controls.Add(this.fXOptions);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 128);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Axes";
			// 
			// fPolarOptions
			// 
			this.fPolarOptions.Location = new System.Drawing.Point(112, 88);
			this.fPolarOptions.Name = "fPolarOptions";
			this.fPolarOptions.TabIndex = 5;
			this.fPolarOptions.Text = "Options";
			// 
			// fYOptions
			// 
			this.fYOptions.Location = new System.Drawing.Point(112, 56);
			this.fYOptions.Name = "fYOptions";
			this.fYOptions.TabIndex = 4;
			this.fYOptions.Text = "Options";
			// 
			// fXOptions
			// 
			this.fXOptions.Location = new System.Drawing.Point(112, 24);
			this.fXOptions.Name = "fXOptions";
			this.fXOptions.TabIndex = 3;
			this.fXOptions.Text = "Options";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(16, 88);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(80, 24);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Polar Axis";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(16, 56);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(72, 24);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Y Axis";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(16, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(72, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "X Axis";
			// 
			// fCloseButton
			// 
			this.fCloseButton.Location = new System.Drawing.Point(168, 304);
			this.fCloseButton.Name = "fCloseButton";
			this.fCloseButton.TabIndex = 2;
			this.fCloseButton.Text = "Close";
			this.fCloseButton.Click += new System.EventHandler(this.fCloseButton_Click);
			// 
			// GraphPanelOptionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 334);
			this.Controls.Add(this.fCloseButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fApplyButton);
			this.Name = "GraphPanelOptionForm";
			this.Text = "Graph Options";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void fCloseButton_Click(object sender, System.EventArgs e) {
			this.Visible = false;
		}
	}
}
