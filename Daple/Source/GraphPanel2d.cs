using System;
using System.Drawing;
using System.Windows.Forms;

using Daple.Expressions;
using Daple.Animation.Testing;

namespace Daple.Plotting.TwoD {

	/// <summary>
	/// Summary description for GraphPanel.
	/// </summary>
	public class GraphPanel2d : GraphPanel {

		protected CartesianPlane fCartesianPlane;

		protected DrawableCollection fDrawables;

		protected Brush fBackgroundBrush;

		protected Plotter2dEditForm fPlotter2dEditForm;

		public GraphPanel2d() {
			this.BackColor = Color.White;
		//	this.fOptionForm = new GraphPanelOptionForm(this);
			this.ContextMenu = new ContextMenu();
		//	this.fBackgroundBrush = new SolidBrush(Color.White);
			this.fBorderPen = new Pen(Color.Black,2);
			this.fDrawables = new DrawableCollection();

			this.SizeChanged += new EventHandler(this.ResizeAll);

			this.fPlotter2dEditForm = new Plotter2dEditForm(this);

			MenuItem options = new MenuItem("Options",new EventHandler(this.GraphPanelOptions));
			this.ContextMenu.MenuItems.Add(options);
			this.ContextMenu.MenuItems.Add(new MenuItem("-"));
			this.ContextMenu.MenuItems.Add(new MenuItem("Exit"));

			this.Cursor = Cursors.Cross;

			this.fCartesianPlane = new CartesianPlane();
			this.fCartesianPlane.pBackgroundBrush = this.fBackgroundBrush;

			this.Add(this.fCartesianPlane);
		//	this.Add(new FunctionPlotterAnimation(Manager.Instance.pAnimationManager,new Expression("sin(time*x"),this.fCartesianPlane));
		//	this.Add(new FunctionPlotter(this.fCartesianPlane));
		}

		public DrawableCollection pDrawables {
			get {
				return this.fDrawables;
			}
		}

		public CartesianPlane pCartesianPlane {
			get {
				return this.fCartesianPlane;
			}
		}

		public new void Invalidate() {
			foreach ( IDrawable id in this.fDrawables ) {
				if ( id is Plotter2d ) {
					((Plotter2d)id).Invalidate();
				}
			}
			base.Invalidate();
		}

		public void Remove(IDrawable id) {
			this.fDrawables.Remove(id);
		}

		public void Remove(string s) {
			for ( int i = 0; i < this.fDrawables.Count; i++ ) {
				IDrawable id = this.fDrawables[i];
				if ( id is Plotter ) {
					if ( ((Plotter)id).pExpression.ToString().Equals(s) ) {
						this.fDrawables.Remove(id);
						this.Invalidate();
					}
				}
			}
		}

		public void Edit(string s) {
			for ( int i = 0; i < this.fDrawables.Count; i++ ) {
				IDrawable id = this.fDrawables[i];
				if ( id is Plotter2d ) {
					if ( ((Plotter)id).pExpression.ToString().Equals(s) ) {
						this.fPlotter2dEditForm.SetPlotter((Plotter2d)id);
						this.fPlotter2dEditForm.Show();
					}
				}
			}
		}

		public void SetFunctionExpression(Expression e) {
			this.fDrawables.RemoveAt(1);
			FunctionPlotter p = new FunctionPlotter(this.fCartesianPlane);
			p.pExpression = e;
			this.Add(p);
		}

		public void SetPolarExpression(Expression e) {
			this.fDrawables.RemoveAt(1);
			PolarPlotter p = new PolarPlotter(this.fCartesianPlane);
			p.pExpression = e;
			this.Add(p);
		}

		public Brush pBackgroundBrush {
			get {
				return this.fBackgroundBrush;
			}
			set {
				this.fBackgroundBrush = value;
			}
		}

		public void Add(IDrawable id) {
			this.fDrawables.Add(id);
			this.Invalidate();
		}

		protected override void Display(System.Windows.Forms.PaintEventArgs e) {
		//	e.Graphics.FillRectangle(
		//		this.fBackgroundBrush,
		//		0,
		//		0,
		//		this.Width,
		//		this.Height);

			foreach ( IDrawable id in this.fDrawables ) {
				id.Draw(e.Graphics);
			}
		}

		protected override void ResizeAll(object sender, System.EventArgs e) {
			this.fCartesianPlane.SetPlotBounds(this.Width,this.Height);
		}

		private void InitializeComponent() {
			// 
			// GraphPanel2d
			// 
			this.Name = "GraphPanel2d";
			this.Size = new System.Drawing.Size(464, 352);

		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if ( e.Button == MouseButtons.Right ) {
				this.ContextMenu.Show(this,new Point(e.X,e.Y));
			}
		}
	}
}