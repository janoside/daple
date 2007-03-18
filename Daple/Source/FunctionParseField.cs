using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Daple.Expressions;

namespace Daple {
	/// <summary>
	/// Summary description for FunctionParseField.
	/// </summary>
	public class FunctionParseField : System.Windows.Forms.UserControl {
		private Expression fExpression;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FunctionParseField() {
			InitializeComponent();
			this.textBox1.Font = Manager.Font;
			this.Resize += new EventHandler(FunctionParseField_Resize);
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// FunctionParseField
			// 
			this.Controls.Add(this.textBox1);
			this.Name = "FunctionParseField";
			this.Size = new System.Drawing.Size(100, 20);
			this.ResumeLayout(false);

		}
		#endregion

		public float Value {
			get {
				this.fExpression = new Expression(this.textBox1.Text);
				float f = (float)this.fExpression.Evaluate(0);
				this.textBox1.Text = f.ToString();
				return f;
			}
			set {
				this.textBox1.Text = value.ToString();
			}
		}

		private void FunctionParseField_Resize(object sender, EventArgs e) {
			this.textBox1.SetBounds(
				0,
				0,
				this.Width,
				this.Height);
		}
	}
}
