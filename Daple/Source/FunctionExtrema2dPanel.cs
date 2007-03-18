using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {

	/// <summary>
	/// Summary description for FunctionExtrema2dPanel.
	/// </summary>
	public class FunctionExtrema2dPanel : System.Windows.Forms.UserControl {
		
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.NumericUpDown fExtremaSteps2d;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ListBox fRelativeExtrema2d;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox fAbsMax2d;
		private System.Windows.Forms.TextBox fAbsMin2d;
		private Daple.Expressions.Evaluator fEvaluator;
		private Daple.FunctionParseField fMinX;
		private Daple.FunctionParseField fMaxX;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FunctionExtrema2dPanel() {
			this.fEvaluator = new Daple.Expressions.Evaluator();
			InitializeComponent();
			this.fAbsMin2d.Font = Manager.Font;
			this.fAbsMax2d.Font = Manager.Font;
		}

		public void SetExpression(Daple.Expressions.Expression e) {
			this.fEvaluator.pExpression = e;
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
			this.label39 = new System.Windows.Forms.Label();
			this.fExtremaSteps2d = new System.Windows.Forms.NumericUpDown();
			this.label38 = new System.Windows.Forms.Label();
			this.fRelativeExtrema2d = new System.Windows.Forms.ListBox();
			this.label22 = new System.Windows.Forms.Label();
			this.fAbsMax2d = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.fAbsMin2d = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.fMinX = new Daple.FunctionParseField();
			this.fMaxX = new Daple.FunctionParseField();
			((System.ComponentModel.ISupportInitialize)(this.fExtremaSteps2d)).BeginInit();
			this.SuspendLayout();
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(24, 104);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(96, 16);
			this.label39.TabIndex = 28;
			this.label39.Text = "Points Calculated";
			// 
			// fExtremaSteps2d
			// 
			this.fExtremaSteps2d.Location = new System.Drawing.Point(144, 104);
			this.fExtremaSteps2d.Maximum = new System.Decimal(new int[] {
																			10000,
																			0,
																			0,
																			0});
			this.fExtremaSteps2d.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.fExtremaSteps2d.Name = "fExtremaSteps2d";
			this.fExtremaSteps2d.Size = new System.Drawing.Size(80, 20);
			this.fExtremaSteps2d.TabIndex = 27;
			this.fExtremaSteps2d.Value = new System.Decimal(new int[] {
																		  200,
																		  0,
																		  0,
																		  0});
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(16, 264);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(100, 16);
			this.label38.TabIndex = 26;
			this.label38.Text = "Relative Extrema";
			// 
			// fRelativeExtrema2d
			// 
			this.fRelativeExtrema2d.BackColor = System.Drawing.SystemColors.Control;
			this.fRelativeExtrema2d.Enabled = false;
			this.fRelativeExtrema2d.Location = new System.Drawing.Point(16, 280);
			this.fRelativeExtrema2d.Name = "fRelativeExtrema2d";
			this.fRelativeExtrema2d.Size = new System.Drawing.Size(224, 95);
			this.fRelativeExtrema2d.TabIndex = 25;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 208);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 16);
			this.label22.TabIndex = 24;
			this.label22.Text = "Absolute Maximum";
			// 
			// fAbsMax2d
			// 
			this.fAbsMax2d.BackColor = System.Drawing.Color.White;
			this.fAbsMax2d.Enabled = false;
			this.fAbsMax2d.Location = new System.Drawing.Point(16, 224);
			this.fAbsMax2d.Name = "fAbsMax2d";
			this.fAbsMax2d.Size = new System.Drawing.Size(224, 20);
			this.fAbsMax2d.TabIndex = 23;
			this.fAbsMax2d.Text = "";
			this.fAbsMax2d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 152);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 22;
			this.label21.Text = "Absolute Minimum";
			// 
			// fAbsMin2d
			// 
			this.fAbsMin2d.BackColor = System.Drawing.Color.White;
			this.fAbsMin2d.Enabled = false;
			this.fAbsMin2d.Location = new System.Drawing.Point(16, 168);
			this.fAbsMin2d.Name = "fAbsMin2d";
			this.fAbsMin2d.Size = new System.Drawing.Size(224, 20);
			this.fAbsMin2d.TabIndex = 21;
			this.fAbsMin2d.Text = "";
			this.fAbsMin2d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(24, 64);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(88, 16);
			this.label36.TabIndex = 20;
			this.label36.Text = "Maximum X";
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(24, 24);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(88, 16);
			this.label37.TabIndex = 19;
			this.label37.Text = "Minimum X";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(96, 408);
			this.button2.Name = "button2";
			this.button2.TabIndex = 18;
			this.button2.Text = "Calculate";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// fMinX
			// 
			this.fMinX.Location = new System.Drawing.Point(144, 24);
			this.fMinX.Name = "fMinX";
			this.fMinX.Size = new System.Drawing.Size(80, 20);
			this.fMinX.TabIndex = 29;
			this.fMinX.Value = 0F;
			// 
			// fMaxX
			// 
			this.fMaxX.Location = new System.Drawing.Point(144, 64);
			this.fMaxX.Name = "fMaxX";
			this.fMaxX.Size = new System.Drawing.Size(80, 20);
			this.fMaxX.TabIndex = 30;
			this.fMaxX.Value = 0F;
			// 
			// FunctionExtrema2dPanel
			// 
			this.Controls.Add(this.fMaxX);
			this.Controls.Add(this.fMinX);
			this.Controls.Add(this.label39);
			this.Controls.Add(this.fExtremaSteps2d);
			this.Controls.Add(this.label38);
			this.Controls.Add(this.fRelativeExtrema2d);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.fAbsMax2d);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.fAbsMin2d);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.button2);
			this.Name = "FunctionExtrema2dPanel";
			this.Size = new System.Drawing.Size(256, 438);
			((System.ComponentModel.ISupportInitialize)(this.fExtremaSteps2d)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e) {
			float min = (float)this.fEvaluator.Min(
				this.fMinX.Value,
				this.fMaxX.Value,
				(int)this.fExtremaSteps2d.Value);

			float max = (float)this.fEvaluator.Max(
				this.fMinX.Value,
				this.fMaxX.Value,
				(int)this.fExtremaSteps2d.Value);

			this.fAbsMin2d.Text = min.ToString();
			this.fAbsMax2d.Text = max.ToString();
		}
	}
}
