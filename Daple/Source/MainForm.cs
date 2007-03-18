using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using D3 = Microsoft.DirectX.Direct3D;

using Daple.Plotting;
using Daple.Plotting.TwoD;
using Daple.Plotting.ThreeD;
using Daple.Expressions;
using Daple.Plotting.TwoD.Controls;

namespace Daple {

	public partial class MainForm : Form {

		private VariableCollection fVariables;
		private Expression fExpression;

		private Plotter3d fPlotter3d;
		private Plotter2d fPlotter2d;

		private Color[] fColors3d;
		private Color[] fColors2d;

		public MainForm() {
			InitializeComponent();

			this.PostInitialize();
			this.fExpressionAnalyzer = new ExpressionAnalyzer();
			this.tabPage4.Controls.Add(this.fExpressionAnalyzer);
			this.fExpressionAnalyzer.SetBounds(
				8,
				8,
				240,
				420);
			this.CreateContextMenu();
			this.fXAxis = this.fGraphPanel2d.pCartesianPlane.pXAxis;
			this.fYAxis = this.fGraphPanel2d.pCartesianPlane.pYAxis;
			this.fPolarAxis = this.fGraphPanel2d.pCartesianPlane.pPolarAxis;
			//	this.Font = Manager.Font;
			this.Resize += new EventHandler(MainForm_Resize);
			this.tabControl1.Resize += new EventHandler(tabControl1_Resize);
			this.fVariables = new VariableCollection();
			this.fExpressionBox3d.KeyDown += new KeyEventHandler(fExpressionBox3d_KeyDown);
		}

		private void PostInitialize() {
			this.fMainPanel2d = new Panel2d(
				this.fGraphPanel2d,
				this.fColorDialog);
			this.tabPage2.Controls.Add(this.fMainPanel2d);
			this.fMainPanel2d.Dock = DockStyle.Right;
		}

		public GraphPanel2d pGraphPanel2d {
			get {
				return this.fGraphPanel2d;
			}
		}

		private void AddExpression3d(string s) {
			if ( !s.Equals("") ) {
				FunctionPlotter3d f = new FunctionPlotter3d(this.fGraphPanel3d.pGraphics3d.pDevice, this.fGraphPanel3d.pCartesianSpace);
				f.pExpression = new Expression(s);
				this.fGraphPanel3d.Add(f);
				this.fExpressionListBox3d.Items.Add(s);
				this.fExpressionBox3d.Text = "";
				this.fExpressionListBox3d.SelectedIndex = this.fExpressionListBox3d.Items.Count - 1;
				this.fGraphPanel3d.Invalidate();
			}
		}

		private void ApplyToPlotter2d() {
			/*	if ( this.fEditColorType2d.SelectedIndex == 0 ) {
					this.fPlotter2d.pColorSetter = new SolidColorSetter();
					this.fPlotter2d.pColorSetter.pColors = this.fColors2d;
				} else if ( this.fEditColorType2d.SelectedIndex == 1 ) {
					this.fPlotter2d.pColorSetter = new Expression2dColorSetter(
						this.fPlotter2d.pExpression.ToString(),
						this.fPlotter2d.pMinX,
						this.fPlotter2d.pMaxX);
				} else if ( this.fEditColorType2d.SelectedIndex == 2 ) {
					this.fPlotter2d.pColorSetter = new XPosition2dColorSetter(
						(float)this.fPlotter2d.pMinX,
						(float)this.fPlotter2d.pMaxX);
					this.fPlotter2d.pColorSetter.pColors = this.fColors2d;
				} else if ( this.fEditColorType2d.SelectedIndex == 3 ) {
				}
				this.fPlotter2d.pColorSetter.pColors = this.fColors2d;
									
				this.fGraphPanel2d.Invalidate();*/
		}


		private void EditPlotter3d() {
			for ( int i = 0; i < this.fGraphPanel3d.pGraphics3d.pRenderables.Count; i++ ) {
				IRenderable ir = this.fGraphPanel3d.pGraphics3d.pRenderables[i];
				if ( ir is Plotter3d ) {
					if ( ((Plotter3d)ir).pExpression.ToString().Equals((string)this.fExpressionListBox3d.SelectedItem) ) {
						this.fPlotter3d = (Plotter3d)ir;
					}
				}
			}
			this.fEditExpressionBox3d.Text = this.fPlotter3d.pExpression.ToString();
			this.fXPointsCalculated.Value = this.fPlotter3d.pXPoints;
			this.fYPointsCalculated.Value = this.fPlotter3d.pYPoints;
			if ( this.fPlotter3d.pFillMode == D3.FillMode.Solid ) {
				if ( this.fPlotter3d.pIsGridVisible ) {
					this.fEditRenderMode3d.SelectedIndex = 1;
				} else {
					this.fEditRenderMode3d.SelectedIndex = 0;
				}
			} else if ( this.fPlotter3d.pFillMode == D3.FillMode.WireFrame ) {
				this.fEditRenderMode3d.SelectedIndex = 2;
			} else {
				this.fEditRenderMode3d.SelectedIndex = 3;
			}
			if ( this.fPlotter3d.pColorSetter is ZPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 0;
			} else if ( this.fPlotter3d.pColorSetter is XPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 2;
			} else if ( this.fPlotter3d.pColorSetter is YPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 3;
			} else if ( this.fPlotter3d.pColorSetter is XYPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 4;
			} else if ( this.fPlotter3d.pColorSetter is Expression3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 1;
				this.fEditColorExpression3d.Text = ((Expression3dColorSetter)this.fPlotter3d.pColorSetter).pExpression.ToString();
			} else {
				this.fEditColorType3d.SelectedIndex = 5;
			}
			this.fMinX3d.Value = (decimal)this.fPlotter3d.pMinX;
			this.fMaxX3d.Value = (decimal)this.fPlotter3d.pMaxX;
			this.fMinY3d.Value = (decimal)this.fPlotter3d.pMinY;
			this.fMaxY3d.Value = (decimal)this.fPlotter3d.pMaxY;
			this.fRGBBox3d.Items.Clear();
			Color[] c = this.fPlotter3d.pColorSetter.pColors;
			for ( int i = 0; i < c.Length; i++ ) {
				string r = c[i].R.ToString();
				r = this.FillString(r, 3);
				string g = c[i].G.ToString();
				g = this.FillString(g, 3);
				string b = c[i].B.ToString();
				b = this.FillString(b, 3);
				this.fRGBBox3d.Items.Add("rgb[" + r + "," + g + "," + b + "]");
			}
			this.UpdateColorScheme();
		}


		private void ApplyToPlotter3d() {
			this.fPlotter3d.pExpression = new Expression(this.fEditExpressionBox3d.Text);
			this.fExpressionListBox3d.Items[this.fExpressionListBox3d.SelectedIndex] = this.fEditExpressionBox3d.Text;
			this.fPlotter3d.pXPoints = (int)this.fXPointsCalculated.Value;
			this.fPlotter3d.pYPoints = (int)this.fYPointsCalculated.Value;
			if ( this.fEditRenderMode3d.SelectedIndex == 0 ) {
				this.fPlotter3d.pFillMode = D3.FillMode.Solid;
				this.fPlotter3d.pIsGridVisible = false;
			} else if ( this.fEditRenderMode3d.SelectedIndex == 1 ) {
				this.fPlotter3d.pFillMode = D3.FillMode.Solid;
				this.fPlotter3d.pIsGridVisible = true;
			} else if ( this.fEditRenderMode3d.SelectedIndex == 2 ) {
				this.fPlotter3d.pFillMode = D3.FillMode.WireFrame;
			} else {
				this.fPlotter3d.pFillMode = D3.FillMode.Point;
			}
			if ( this.fEditColorType3d.SelectedIndex == 0 ) {
				Evaluator e = new Evaluator();
				e.pExpression = this.fPlotter3d.pExpression;
				float min = (float)e.Min(
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				float max = (float)e.Max(
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				this.fPlotter3d.pColorSetter = new ZPosition3dColorSetter(min, max);
				this.fPlotter3d.pColorSetter.pColors = this.fColors3d;
			} else if ( this.fEditColorType3d.SelectedIndex == 1 ) {
				this.fPlotter3d.pColorSetter = new Expression3dColorSetter(
					this.fEditColorExpression3d.Text,
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				this.fPlotter3d.pColorSetter.pColors = this.fColors3d;
			} else if ( this.fEditColorType3d.SelectedIndex == 2 ) {
				this.fPlotter3d.pColorSetter = new XPosition3dColorSetter(
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				this.fPlotter3d.pColorSetter.pColors = this.fColors3d;
			} else if ( this.fEditColorType3d.SelectedIndex == 3 ) {
				this.fPlotter3d.pColorSetter = new YPosition3dColorSetter(
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				this.fPlotter3d.pColorSetter.pColors = this.fColors3d;
			} else if ( this.fEditColorType3d.SelectedIndex == 4 ) {
				this.fPlotter3d.pColorSetter = new XYPosition3dColorSetter(
					this.fPlotter3d.pMinX,
					this.fPlotter3d.pMaxX,
					this.fPlotter3d.pMinY,
					this.fPlotter3d.pMaxY);
				this.fPlotter3d.pColorSetter.pColors = this.fColors3d;
			} else if ( this.fEditColorType3d.SelectedIndex == 5 ) {
			}
			if ( this.fPlotter3d.pColorSetter is ZPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 0;
			} else if ( this.fPlotter3d.pColorSetter is XPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 2;
			} else if ( this.fPlotter3d.pColorSetter is YPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 3;
			} else if ( this.fPlotter3d.pColorSetter is XYPosition3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 4;
			} else if ( this.fPlotter3d.pColorSetter is Expression3dColorSetter ) {
				this.fEditColorType3d.SelectedIndex = 1;
				this.fEditColorExpression3d.Text = ((Expression3dColorSetter)this.fPlotter3d.pColorSetter).pExpression.ToString();
			} else {
				this.fEditColorType3d.SelectedIndex = 5;
			}
			this.fPlotter3d.pMinX = (float)this.fMinX3d.Value;
			this.fPlotter3d.pMaxX = (float)this.fMaxX3d.Value;
			this.fPlotter3d.pMinY = (float)this.fMinY3d.Value;
			this.fPlotter3d.pMaxY = (float)this.fMaxY3d.Value;
			this.fGraphPanel3d.Invalidate();
		}


		private string FillString(string s, int length) {
			while ( s.Length < length ) {
				s += " ";
			}
			return s;
		}

		private void MainForm_Resize(object sender, EventArgs e) {
			this.tabControl1.SetBounds(
				4,
				4,
				this.Width - 17,
				this.Height - 63);
		}


		private void tabControl1_Resize(object sender, EventArgs e) {
			int size = (int)System.Math.Min(this.tabControl1.Width, this.tabControl1.Height);
			this.fGraphPanel2d.SetBounds(
				5,
				25,
				size - 57,
				size - 57);

			int panelWidth = 280;//this.Width-size-37+35;

			this.fMainPanel2d.SetBounds(
				size - 37 + 10 + (this.Width - size - 37 + 35 - panelWidth) / 2 - 10,
				5,
				panelWidth,
				size - 37);

			this.fGraphPanel3d.SetBounds(
				5,
				25,
				size - 57,
				size - 57);

			this.fPanel3d.SetBounds(
				size - 37 + 10 + (this.Width - size - 37 + 35 - panelWidth) / 2 - 10,
				5,
				panelWidth,
				size - 37);

			this.commandLinePanel1.SetBounds(
				5,
				5,
				this.tabControl1.Width - 15,
				this.tabControl1.Height - 35);

			this.fGraphPanel2d.Invalidate();
			this.fGraphPanel3d.Invalidate();
		}


		private void fAddButton3d_Click(object sender, System.EventArgs e) {
			this.AddExpression3d(this.fExpressionBox3d.Text);
		}


		private void fEditButton3d_Click(object sender, System.EventArgs e) {
			this.fEditAxesTabControl.Visible = false;
			this.fEditPlotterTabControl.Visible = true;
			this.EditPlotter3d();
			this.fApplyButton3d.Visible = true;
			this.fCloseButton3d.Visible = true;
			//this.fGraphPanel3d.Edit((string)this.fExpressionListBox3d.SelectedItem);
		}


		private void fRemoveButton3d_Click(object sender, System.EventArgs e) {
			int x = this.fExpressionListBox3d.SelectedIndex;
			this.fGraphPanel3d.Remove((string)this.fExpressionListBox3d.SelectedItem);
			this.fExpressionListBox3d.Items.Remove(this.fExpressionListBox3d.SelectedItem);
			if ( this.fExpressionListBox3d.Items.Count - 1 >= x ) {
				this.fExpressionListBox3d.SelectedIndex = x;
			} else {
				if ( x >= 1 ) {
					this.fExpressionListBox3d.SelectedIndex = x - 1;
				}
			}
			if ( this.fExpressionListBox3d.Items.Count == 0 ) {
				this.button3_Click(null, null);
			}
			this.fGraphPanel3d.Invalidate();
		}


		private void fExpressionBox3d_KeyDown(object sender, KeyEventArgs e) {
			if ( e.KeyCode == Keys.Enter ) {
				this.AddExpression3d(this.fExpressionBox3d.Text);
			}
		}

		private void fExpressionListBox3d_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fExpressionListBox3d.SelectedItem == null ) {
				b = false;
			}
			this.fEditButton3d.Enabled = b;
			this.fRemoveButton3d.Enabled = b;
			this.fAnalyzeButton3d.Enabled = b;
			if ( this.fEditPlotterTabControl.Visible ) {
				//	this.EditPlotter3d();
			}
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.fEditPlotterTabControl.Visible = false;
			this.fApplyButton3d.Visible = false;
			this.fCloseButton3d.Visible = false;
			this.fEditAxesTabControl.Visible = true;
		}


		private void fEditColorType3d_SelectedIndexChanged(object sender, System.EventArgs e) {
			if ( this.fEditColorType3d.SelectedIndex == 1 ) {
				this.fEditColorExpression3d.Enabled = true;
			} else {
				this.fEditColorExpression3d.Enabled = false;
			}
		}


		private void fRemoveColorButton3d_Click(object sender, System.EventArgs e) {
			int x = this.fRGBBox3d.SelectedIndex;
			this.fRGBBox3d.Items.Remove(this.fRGBBox3d.SelectedItem);
			if ( this.fRGBBox3d.Items.Count - 1 >= x ) {
				this.fRGBBox3d.SelectedIndex = x;
			} else {
				if ( x >= 1 ) {
					this.fRGBBox3d.SelectedIndex = x - 1;
				}
			}
			this.UpdateColorScheme();
		}


		private void UpdateColorScheme() {
			Color[] c = new Color[this.fRGBBox3d.Items.Count];
			for ( int i = 0; i < this.fRGBBox3d.Items.Count; i++ ) {
				c[i] = this.ParseRGB((string)this.fRGBBox3d.Items[i]);
			}
			this.fColors3d = c;
			this.fColorSchemePreview3d.SetColors(c);
			this.fColorSchemePreview3d.Invalidate();
		}


		private Color ParseRGB(string s) {
			return Color.FromArgb(
				int.Parse(s.Substring(4, 3)),
				int.Parse(s.Substring(8, 3)),
				int.Parse(s.Substring(12, 3)));
		}


		private void fMoveUpButton3d_Click(object sender, System.EventArgs e) {
			if ( this.fRGBBox3d.SelectedIndex >= 1 ) {
				int x = this.fRGBBox3d.SelectedIndex;
				object o1 = this.fRGBBox3d.SelectedItem;
				object o2 = this.fRGBBox3d.Items[x - 1];

				this.fRGBBox3d.Items[x] = o2;
				this.fRGBBox3d.Items[x - 1] = o1;
				this.fRGBBox3d.SelectedIndex = x - 1;
				this.UpdateColorScheme();
			}
		}


		private void fMoveDownButton3d_Click(object sender, System.EventArgs e) {
			if ( this.fRGBBox3d.SelectedIndex <= this.fRGBBox3d.Items.Count - 2 ) {
				int x = this.fRGBBox3d.SelectedIndex;
				object o1 = this.fRGBBox3d.SelectedItem;
				object o2 = this.fRGBBox3d.Items[x + 1];

				this.fRGBBox3d.Items[x] = o2;
				this.fRGBBox3d.Items[x + 1] = o1;
				this.fRGBBox3d.SelectedIndex = x + 1;
				this.UpdateColorScheme();
			}
		}


		private void fRGBBox3d_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fRGBBox3d.SelectedItem == null ) {
				b = false;
			}
			this.fMoveDownButton3d.Enabled = b;
			this.fMoveUpButton3d.Enabled = b;
			this.fRemoveColorButton3d.Enabled = b;
		}


		private void fAddColorButton3d_Click(object sender, System.EventArgs e) {
			string r = ((int)this.fRBox3d.Value).ToString();
			r = this.FillString(r, 3);
			string g = ((int)this.fGBox3d.Value).ToString();
			g = this.FillString(g, 3);
			string b = ((int)this.fBBox3d.Value).ToString();
			b = this.FillString(b, 3);
			this.fRGBBox3d.Items.Add("rgb[" + r + "," + g + "," + b + "]");
			this.UpdateColorScheme();
		}


		private void fRBox3d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview3d.SetColor((int)this.fRBox3d.Value, (int)this.fGBox3d.Value, (int)this.fBBox3d.Value);
		}


		private void fGBox3d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview3d.SetColor((int)this.fRBox3d.Value, (int)this.fGBox3d.Value, (int)this.fBBox3d.Value);
		}


		private void fBBox3d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview3d.SetColor((int)this.fRBox3d.Value, (int)this.fGBox3d.Value, (int)this.fBBox3d.Value);
		}


		private void button2_Click(object sender, System.EventArgs e) {
			this.ApplyToPlotter3d();
		}


		private void button3_Click(object sender, System.EventArgs e) {
			this.fEditPlotterTabControl.Visible = false;
			this.fApplyButton3d.Visible = false;
			this.fCloseButton3d.Visible = false;
		}


		#region Context Menus

		private void CreateContextMenu() {
			MenuItem m = new MenuItem("Existing");
			MenuItem m0 = new MenuItem("Rainbow", new EventHandler(this.LoadRainbow));
			MenuItem m1 = new MenuItem("Stripes", new EventHandler(this.LoadStripes));
			MenuItem m2 = new MenuItem("RGB", new EventHandler(this.LoadRGB));
			MenuItem m3 = new MenuItem("America", new EventHandler(this.LoadAmerica));
			MenuItem m4 = new MenuItem("Tips", new EventHandler(this.LoadTips));
			m.MenuItems.Add(m0);
			m.MenuItems.Add(m1);
			m.MenuItems.Add(m2);
			m.MenuItems.Add(m3);
			m.MenuItems.Add(m4);
			this.fLoadColorContextMenu.MenuItems.Add(m);
		}

		private void LoadTips(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.Tips);
		}

		private void LoadRGB(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.RGB);
		}

		private void LoadAmerica(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.America);
		}

		private void LoadRainbow(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.Rainbow);
		}

		private void LoadColorArray(Color[] c) {
			this.fColors3d = c;
			this.fRGBBox3d.Items.Clear();
			for ( int i = 0; i < c.Length; i++ ) {
				string r = c[i].R.ToString();
				r = this.FillString(r, 3);
				string g = c[i].G.ToString();
				g = this.FillString(g, 3);
				string b = c[i].B.ToString();
				b = this.FillString(b, 3);
				this.fRGBBox3d.Items.Add("rgb[" + r + "," + g + "," + b + "]");
			}
			this.UpdateColorScheme();
		}

		private void LoadStripes(object x, System.EventArgs e) {
			this.LoadColorArray(Colors.Stripes);
		}

		#endregion

		private void fLoadButton3d_Click(object sender, System.EventArgs e) {
			this.fLoadColorContextMenu.Show(
				this.fEditPlotterTabControl,
				new Point(
					this.fLoadButton3d.Location.X + 4 + this.fLoadButton3d.Width,
					this.fLoadButton3d.Location.Y + this.fLoadButton3d.Height - 1));
		}

		private void fApplyButton2d_Click(object sender, System.EventArgs e) {
			this.ApplyToPlotter2d();
		}

		private void tabPage10_Click(object sender, System.EventArgs e) {
			this.SetupExtrema2d();
		}

		private void SetupExtrema2d() {
			this.fExtremaMinX2d.Value = (decimal)this.fPlotter2d.pMinX;
			this.fExtremaMaxX2d.Value = (decimal)this.fPlotter2d.pMaxX;
		}

		private void button2_Click_1(object sender, System.EventArgs e) {
			this.CalculateExtrema2d();
		}

		private void CalculateExtrema2d() {
			Evaluator e = new Evaluator(this.fPlotter2d.pExpression);

			this.fAbsMax2d.Text = ((float)e.Max(
				(double)this.fExtremaMinX2d.Value,
				(double)this.fExtremaMaxX2d.Value,
				(int)this.fExtremaSteps2d.Value)).ToString();

			this.fAbsMin2d.Text = ((float)e.Min(
				(double)this.fExtremaMinX2d.Value,
				(double)this.fExtremaMaxX2d.Value,
				(int)this.fExtremaSteps2d.Value)).ToString();
		}

		private void fBackColorButton2d_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fBackColorButton2d.BackColor = this.fColorDialog.Color;
		}

		private void button7_Click(object sender, System.EventArgs e) {
			this.fMainPanel2d.SetDefaultZoom();
			this.fGraphPanel2d.Invalidate();
		}

		private void button8_Click(object sender, System.EventArgs e) {
			this.fMainPanel2d.SetTrigZoom();
			this.fGraphPanel2d.Invalidate();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e) {
			if ( e.KeyCode == Keys.Enter ) {
				this.expressionAnalysisPanel1.pExpressionAnalyzer.pExpression = new Expression(this.textBox1.Text);
			}
		}

		private void aboutDapleToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutForm af = new AboutForm();
			af.ShowDialog();
		}
	}
}