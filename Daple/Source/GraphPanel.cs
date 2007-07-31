using System;
using System.Drawing;
using System.Windows.Forms;

using Daple.Expressions;

namespace Daple.Plotting {

	/// <summary>
	/// Summary description for GraphPanel.
	/// </summary>
	public class GraphPanel : System.Windows.Forms.UserControl {

	//	protected GraphPanelOptionForm fOptionForm;

		protected Pen fBorderPen;

		public GraphPanel() {
		//	this.fOptionForm = new GraphPanelOptionForm(this);
			this.ContextMenu = new ContextMenu();
			this.fBorderPen = new Pen(Color.Black,2);

			this.SizeChanged += new EventHandler(this.ResizeAll);

			MenuItem options = new MenuItem("Options",new EventHandler(this.GraphPanelOptions));
			this.ContextMenu.MenuItems.Add(options);
			this.ContextMenu.MenuItems.Add(new MenuItem("-"));
			this.ContextMenu.MenuItems.Add(new MenuItem("Exit"));

			this.Cursor = Cursors.Cross;
		}

		protected void GraphPanelOptions(object sender, System.EventArgs e) {
		//	this.fOptionForm.Show();
		}

		private void DrawBorder(Graphics g) {
			g.DrawRectangle(
				this.fBorderPen,
				0,
				0,
				this.Width,
				this.Height);
		}

		protected override void OnPaint(PaintEventArgs e) {
			this.Display(e);
			this.DrawBorder(e.Graphics);

			this.Invalidate();
		}

		protected virtual void Display(System.Windows.Forms.PaintEventArgs e) {
		}

		protected virtual void ResizeAll(object sender, System.EventArgs e) {
		}

		private void InitializeComponent() {
			// 
			// GraphPanel
			// 
			this.Name = "GraphPanel";
			this.Size = new System.Drawing.Size(368, 272);

		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if ( e.Button == MouseButtons.Right ) {
				this.ContextMenu.Show(this,new Point(e.X,e.Y));
			}
		}
	}
}