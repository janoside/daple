using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Commands.Controls {
	
	/// <summary>
	/// Summary description for CommandPanel.
	/// </summary>
	public class CommandPanel : System.Windows.Forms.UserControl {

		private static readonly Color DefaultColor = Color.White;
		private static readonly Color HighlightColor = Color.LightGreen;
		
		protected CommandLinePanel fCommandLinePanel;

		protected Pen fBorderPen;

		protected bool fIsHighlighted;

		protected int x;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CommandPanel(CommandLinePanel p, int x) {
			this.x = x;
			this.fCommandLinePanel = p;
			InitializeComponent();
			this.BackColor = Color.White;
			this.fBorderPen = new Pen(Color.Black);
			this.fIsHighlighted = false;
		}

		public bool pIsHighlighted {
			get {
				return this.fIsHighlighted;
			}
		}

		public int pX {
			get {
				return this.x;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			this.fCommandLinePanel.KeyPressed(e.KeyCode);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if ( e.Button == MouseButtons.Left ) {
				this.fCommandLinePanel.AdviseMousePress(this);
			}
		}

		public void Highlight(bool b) {
			Console.WriteLine("highlighting:"+this.x+","+b);
			this.fIsHighlighted = b;
			if ( this.fIsHighlighted ) {
				this.BackColor = CommandPanel.DefaultColor;
			} else {
				this.BackColor = CommandPanel.HighlightColor;
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			e.Graphics.DrawRectangle(
				this.fBorderPen,
				0,
				0,
				this.Width-1,
				this.Height-1);
			e.Graphics.DrawString(
				this.x.ToString(),
				new Font("Arial",20),
				new SolidBrush(Color.Black),
				5,
				5);
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
			// CommandPanel
			// 
			this.Name = "CommandPanel";
			this.Size = new System.Drawing.Size(392, 72);

		}
		#endregion
	}
}
