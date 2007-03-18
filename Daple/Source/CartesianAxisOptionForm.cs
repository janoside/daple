using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for CartesianAxisOptionForm.
	/// </summary>
	public class CartesianAxisOptionForm : System.Windows.Forms.Form {

		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private CartesianAxis fAxis;

		public CartesianAxisOptionForm() {
			InitializeComponent();
		}

		public void Show(CartesianAxis ca) {
			this.fAxis = ca;
			this.SetAxisValues();
			base.Show();
		}

		private void SetAxisValues() {
			
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
			this.button1.Location = new System.Drawing.Point(112, 232);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// CartesianAxisOptionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.button1);
			this.Name = "CartesianAxisOptionForm";
			this.Text = "CartesianAxisOptionForm";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
