using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Daple.Expressions;

namespace Daple {

	/// <summary>
	/// Summary description for ExpressionAnalysisForm.
	/// </summary>
	public class ExpressionAnalysisForm : System.Windows.Forms.Form {

		private System.Windows.Forms.Button button1;

		private ExpressionAnalyzer fExpressionAnalyzer;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ExpressionAnalysisForm() {
			this.fExpressionAnalyzer = new ExpressionAnalyzer();
			this.Resize += new EventHandler(ExpressionAnalysisForm_Resize);
			InitializeComponent();
			this.ExpressionAnalysisForm_Resize(null,null);
		}

		public void SetExpression(string s) {
			this.fExpressionAnalyzer.pExpression = new Expression(s);
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 240);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ExpressionAnalysisForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 438);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.fExpressionAnalyzer);
			this.Name = "ExpressionAnalysisForm";
			this.Text = "ExpressionAnalysisForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e) {
			this.Hide();
		}

		private void ExpressionAnalysisForm_Resize(object sender, EventArgs e) {
			this.fExpressionAnalyzer.SetBounds(
				5,
				5,
				this.Width-20,
				this.Height-50-this.button1.Height);

			this.button1.SetBounds(
				this.Width/2-this.button1.Width/2,
				this.Height-40-this.button1.Height,
				this.button1.Width,
				this.button1.Height);
		}
	}
}
