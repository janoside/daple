using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple {

	/// <summary>
	/// Summary description for ExpressionAnalysisPanel.
	/// </summary>
	public class ExpressionAnalysisPanel : System.Windows.Forms.UserControl {
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Expressions.ExpressionAnalyzer fExpressionAnalyzer;

		public ExpressionAnalysisPanel() {
			InitializeComponent();
			this.fExpressionAnalyzer = new Daple.Expressions.ExpressionAnalyzer();
			this.fExpressionAnalyzer.SetBounds(
				0,
				0,
				this.Width,
				this.Height);
			this.Controls.Add(this.fExpressionAnalyzer);
			this.Resize += new EventHandler(ExpressionAnalysisPanel_Resize);
		}

		public Expressions.ExpressionAnalyzer pExpressionAnalyzer {
			get {
				return this.fExpressionAnalyzer;
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
			// 
			// ExpressionAnalysisPanel
			// 
			this.Name = "ExpressionAnalysisPanel";
			this.Size = new System.Drawing.Size(384, 376);

		}
		#endregion

		private void ExpressionAnalysisPanel_Resize(object sender, EventArgs e) {
			this.fExpressionAnalyzer.SetBounds(
				0,
				0,
				this.Width,
				this.Height);
		}
	}
}
