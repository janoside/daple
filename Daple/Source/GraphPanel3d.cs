using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using D3 = Microsoft.DirectX.Direct3D;

using Daple.Expressions;

namespace Daple.Plotting.ThreeD {

	/// <summary>
	/// Summary description for GraphPanel3d.
	/// </summary>
	public class GraphPanel3d : GraphPanel {

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected Graphics3d fGraphics3d;

		protected CartesianSpace fCartesianSpace;

		protected Plotter3dEditForm fPlotter3dEditForm;

		protected bool fIsMouseDown;

		public GraphPanel3d() {
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
			this.fPlotter3dEditForm = new Plotter3dEditForm(this);
			this.fIsMouseDown = false;
			this.fGraphics3d = new Graphics3d(this);
			this.fCartesianSpace = new CartesianSpace(this.fGraphics3d.pDevice);
			this.fGraphics3d.Add(this.fCartesianSpace);

			this.DoubleBuffered = true;
		}

		public Graphics3d pGraphics3d {
			get {
				return this.fGraphics3d;
			}
		}

		public CartesianSpace pCartesianSpace {
			get {
				return this.fCartesianSpace;
			}
		}

		public void Add(IRenderable ir) {
			this.fGraphics3d.Add(ir);
		}

		public void Remove(string s) {
			for ( int i = 0; i < this.fGraphics3d.pRenderables.Count; i++ ) {
				IRenderable ir = this.fGraphics3d.pRenderables[i];
				if ( ir is Plotter3d ) {
					if ( ((Plotter3d)ir).pExpression.ToString().Equals(s) ) {
						this.fGraphics3d.pRenderables.Remove(ir);
						this.Invalidate();
					}
				}
			}
		}

		public void Edit(string s) {
			for ( int i = 0; i < this.fGraphics3d.pRenderables.Count; i++ ) {
				IRenderable ir = this.fGraphics3d.pRenderables[i];
				if ( ir is Plotter3d ) {
					if ( ((Plotter3d)ir).pExpression.ToString().Equals(s) ) {
						this.fPlotter3dEditForm.SetPlotter((Plotter3d)ir);
						this.fPlotter3dEditForm.Show();
					}
				}
			}
		}

		public void SetFunctionExpression(Expression e) {
			this.fGraphics3d.pRenderables.RemoveAt(1);
			FunctionPlotter3d p = new FunctionPlotter3d(this.fGraphics3d.pDevice,this.fCartesianSpace);
			p.pExpression = e;
			this.fGraphics3d.Add(p);
		}

		protected override void Display(PaintEventArgs e) {
			this.fGraphics3d.Render();
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);
			if ( this.fIsMouseDown ) {
			//	if ( e.X > 0 && e.X < this.Width && e.Y > 0 && e.Y < this.Height ) {
					this.fGraphics3d.DragMouse(e.X,e.Y);
					this.Invalidate();
			//	}
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e) {
			base.OnMouseWheel(e);
			this.fGraphics3d.MouseWheel(e.Delta);
			this.Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			this.fGraphics3d.SetMousePosition(e.X,e.Y);
			this.fIsMouseDown = true;
			while ( this.fIsMouseDown ) {
				this.fGraphics3d.Render();
				Application.DoEvents();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			this.fIsMouseDown = false;
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
			this.SuspendLayout();
			// 
			// GraphPanel3d
			// 
			this.Name = "GraphPanel3d";
			this.Size = new System.Drawing.Size(546, 501);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void ResizeAll(object sender, EventArgs e) {

		}
	}
}
