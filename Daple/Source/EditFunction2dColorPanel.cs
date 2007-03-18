using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {
	
	/// <summary>
	/// Summary description for EditFunction2dColorPanel.
	/// </summary>
	public class EditFunction2dColorPanel : System.Windows.Forms.UserControl {
		
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label30;
		private Daple.Plotting.ColorSchemePreviewControl fColorSchemePreview2d;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.ListBox fRGBBox2d;
		private System.Windows.Forms.Button fMoveUpButton2d;
		private System.Windows.Forms.Button fLoadButton2d;
		private System.Windows.Forms.Button fMoveDownButton2d;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Button fAddColor2d;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.NumericUpDown fBBox2d;
		private System.Windows.Forms.NumericUpDown fRBox2d;
		private System.Windows.Forms.ComboBox fEditColorType2d;
		private Daple.Plotting.ColorPreviewControl fColorPreview2d;
		private System.Windows.Forms.Button fRemoveColorButton2d;
		private System.Windows.Forms.NumericUpDown fGBox2d;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private Plotter2d fPlotter;
		private Color [] fColors2d;
		private System.Windows.Forms.ContextMenu fLoadColorContextMenu2d;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditFunction2dColorPanel() {
			InitializeComponent();
			this.PostInitialize();
		}

		public void SetPlotter(Plotter2d p) {
			this.fPlotter = p;
		}

		public void UpdateFromPlotter() {
			if ( this.fPlotter.pColorSetter is SolidColorSetter ) {
				this.fEditColorType2d.SelectedIndex = 0;
			} else if ( this.fPlotter.pColorSetter is Expression2dColorSetter ) {
				this.fEditColorType2d.SelectedIndex = 1;
			} else if ( this.fPlotter.pColorSetter is XPosition2dColorSetter ) {
				this.fEditColorType2d.SelectedIndex = 2;
			} else {
				this.fEditColorType2d.SelectedIndex = 3;
			}
			this.fRGBBox2d.Items.Clear();
			Color [] c = this.fPlotter.pColorSetter.pColors;
			for ( int i = 0; i < c.Length; i++ ) {
				string r = c[i].R.ToString();
				r = this.FillString(r,3);
				string g = c[i].G.ToString();
				g = this.FillString(g,3);
				string b = c[i].B.ToString();
				b = this.FillString(b,3);
				this.fRGBBox2d.Items.Add("rgb["+r+","+g+","+b+"]");
			}
			this.UpdateColorScheme2d();
		}

		public void ApplyToPlotter() {
			if ( this.fEditColorType2d.SelectedIndex == 0 ) {
				this.fPlotter.pColorSetter = new SolidColorSetter();
				this.fPlotter.pColorSetter.pColors = this.fColors2d;
			} else if ( this.fEditColorType2d.SelectedIndex == 1 ) {
				this.fPlotter.pColorSetter = new Expression2dColorSetter(
					this.fPlotter.pExpression.ToString(),
					this.fPlotter.pMinX,
					this.fPlotter.pMaxX);
			} else if ( this.fEditColorType2d.SelectedIndex == 2 ) {
				this.fPlotter.pColorSetter = new XPosition2dColorSetter(
					(float)this.fPlotter.pMinX,
					(float)this.fPlotter.pMaxX);
				this.fPlotter.pColorSetter.pColors = this.fColors2d;
			} else if ( this.fEditColorType2d.SelectedIndex == 3 ) {
				this.fPlotter.pColorSetter = new XYPosition2dColorSetter(
					this.fPlotter.pExpression.ToString(),
					this.fPlotter.pMinX,
					this.fPlotter.pMaxX);
				this.fPlotter.pColorSetter.pColors = this.fColors2d;
			}
			this.fPlotter.pColorSetter.pColors = this.fColors2d;
		}

		private void PostInitialize() {
			MenuItem mx = new MenuItem("Existing");
			MenuItem m0x = new MenuItem("Rainbow",new EventHandler(this.LoadRainbow2d));
			MenuItem m1x = new MenuItem("Stripes",new EventHandler(this.LoadStripes2d));
			MenuItem m2x = new MenuItem("RGB",new EventHandler(this.LoadRGB2d));
			MenuItem m3x = new MenuItem("America",new EventHandler(this.LoadAmerica2d));
			MenuItem m4x = new MenuItem("Tips",new EventHandler(this.LoadTips2d));
			mx.MenuItems.Add(m0x);
			mx.MenuItems.Add(m1x);
			mx.MenuItems.Add(m2x);
			mx.MenuItems.Add(m3x);
			mx.MenuItems.Add(m4x);
			this.fLoadColorContextMenu2d.MenuItems.Add(mx);
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
			this.button4 = new System.Windows.Forms.Button();
			this.label30 = new System.Windows.Forms.Label();
			this.fColorSchemePreview2d = new Daple.Plotting.ColorSchemePreviewControl();
			this.label31 = new System.Windows.Forms.Label();
			this.fRGBBox2d = new System.Windows.Forms.ListBox();
			this.fMoveUpButton2d = new System.Windows.Forms.Button();
			this.fLoadButton2d = new System.Windows.Forms.Button();
			this.fMoveDownButton2d = new System.Windows.Forms.Button();
			this.label32 = new System.Windows.Forms.Label();
			this.fAddColor2d = new System.Windows.Forms.Button();
			this.label33 = new System.Windows.Forms.Label();
			this.fBBox2d = new System.Windows.Forms.NumericUpDown();
			this.fRBox2d = new System.Windows.Forms.NumericUpDown();
			this.fEditColorType2d = new System.Windows.Forms.ComboBox();
			this.fColorPreview2d = new Daple.Plotting.ColorPreviewControl();
			this.fRemoveColorButton2d = new System.Windows.Forms.Button();
			this.fGBox2d = new System.Windows.Forms.NumericUpDown();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.fLoadColorContextMenu2d = new System.Windows.Forms.ContextMenu();
			((System.ComponentModel.ISupportInitialize)(this.fBBox2d)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox2d)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fGBox2d)).BeginInit();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(188, 404);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(56, 23);
			this.button4.TabIndex = 70;
			this.button4.Text = "Save";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(188, 204);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(56, 16);
			this.label30.TabIndex = 69;
			this.label30.Text = "Preview";
			// 
			// fColorSchemePreview2d
			// 
			this.fColorSchemePreview2d.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.fColorSchemePreview2d.Location = new System.Drawing.Point(188, 220);
			this.fColorSchemePreview2d.Name = "fColorSchemePreview2d";
			this.fColorSchemePreview2d.Size = new System.Drawing.Size(56, 173);
			this.fColorSchemePreview2d.TabIndex = 68;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(12, 204);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(100, 16);
			this.label31.TabIndex = 63;
			this.label31.Text = "Color Scheme";
			// 
			// fRGBBox2d
			// 
			this.fRGBBox2d.Location = new System.Drawing.Point(12, 220);
			this.fRGBBox2d.Name = "fRGBBox2d";
			this.fRGBBox2d.Size = new System.Drawing.Size(128, 173);
			this.fRGBBox2d.TabIndex = 65;
			this.fRGBBox2d.SelectedIndexChanged += new System.EventHandler(this.fRGBBox2d_SelectedIndexChanged);
			// 
			// fMoveUpButton2d
			// 
			this.fMoveUpButton2d.Enabled = false;
			this.fMoveUpButton2d.Location = new System.Drawing.Point(148, 228);
			this.fMoveUpButton2d.Name = "fMoveUpButton2d";
			this.fMoveUpButton2d.Size = new System.Drawing.Size(32, 23);
			this.fMoveUpButton2d.TabIndex = 66;
			this.fMoveUpButton2d.Text = "Up";
			this.fMoveUpButton2d.Click += new System.EventHandler(this.fMoveUpButton2d_Click);
			// 
			// fLoadButton2d
			// 
			this.fLoadButton2d.Enabled = false;
			this.fLoadButton2d.Location = new System.Drawing.Point(12, 404);
			this.fLoadButton2d.Name = "fLoadButton2d";
			this.fLoadButton2d.Size = new System.Drawing.Size(56, 23);
			this.fLoadButton2d.TabIndex = 64;
			this.fLoadButton2d.Text = "Load";
			this.fLoadButton2d.Click += new System.EventHandler(this.fLoadButton2d_Click);
			// 
			// fMoveDownButton2d
			// 
			this.fMoveDownButton2d.Enabled = false;
			this.fMoveDownButton2d.Location = new System.Drawing.Point(148, 260);
			this.fMoveDownButton2d.Name = "fMoveDownButton2d";
			this.fMoveDownButton2d.Size = new System.Drawing.Size(32, 23);
			this.fMoveDownButton2d.TabIndex = 67;
			this.fMoveDownButton2d.Text = "Dn";
			this.fMoveDownButton2d.Click += new System.EventHandler(this.fMoveDownButton2d_Click);
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(68, 116);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(24, 16);
			this.label32.TabIndex = 55;
			this.label32.Text = "G";
			// 
			// fAddColor2d
			// 
			this.fAddColor2d.Enabled = false;
			this.fAddColor2d.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.fAddColor2d.Location = new System.Drawing.Point(60, 164);
			this.fAddColor2d.Name = "fAddColor2d";
			this.fAddColor2d.Size = new System.Drawing.Size(136, 23);
			this.fAddColor2d.TabIndex = 57;
			this.fAddColor2d.Text = "Add";
			this.fAddColor2d.Click += new System.EventHandler(this.fAddColor2d_Click);
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(12, 116);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(16, 16);
			this.label33.TabIndex = 54;
			this.label33.Text = "R";
			// 
			// fBBox2d
			// 
			this.fBBox2d.Location = new System.Drawing.Point(124, 132);
			this.fBBox2d.Maximum = new System.Decimal(new int[] {
																	255,
																	0,
																	0,
																	0});
			this.fBBox2d.Name = "fBBox2d";
			this.fBBox2d.Size = new System.Drawing.Size(48, 20);
			this.fBBox2d.TabIndex = 59;
			this.fBBox2d.Value = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fBBox2d.ValueChanged += new System.EventHandler(this.fBBox2d_ValueChanged);
			// 
			// fRBox2d
			// 
			this.fRBox2d.Location = new System.Drawing.Point(12, 132);
			this.fRBox2d.Maximum = new System.Decimal(new int[] {
																	255,
																	0,
																	0,
																	0});
			this.fRBox2d.Name = "fRBox2d";
			this.fRBox2d.Size = new System.Drawing.Size(48, 20);
			this.fRBox2d.TabIndex = 58;
			this.fRBox2d.Value = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fRBox2d.ValueChanged += new System.EventHandler(this.fRBox2d_ValueChanged);
			// 
			// fEditColorType2d
			// 
			this.fEditColorType2d.Items.AddRange(new object[] {
																  "Solid Color",
																  "Elevation",
																  "X Value",
																  "XY Value"});
			this.fEditColorType2d.Location = new System.Drawing.Point(60, 28);
			this.fEditColorType2d.Name = "fEditColorType2d";
			this.fEditColorType2d.Size = new System.Drawing.Size(121, 21);
			this.fEditColorType2d.TabIndex = 53;
			this.fEditColorType2d.Text = "Solid Color";
			this.fEditColorType2d.SelectedIndexChanged += new System.EventHandler(this.fEditColorType2d_SelectedIndexChanged);
			// 
			// fColorPreview2d
			// 
			this.fColorPreview2d.BackColor = System.Drawing.Color.White;
			this.fColorPreview2d.Location = new System.Drawing.Point(188, 116);
			this.fColorPreview2d.Name = "fColorPreview2d";
			this.fColorPreview2d.Size = new System.Drawing.Size(56, 36);
			this.fColorPreview2d.TabIndex = 62;
			// 
			// fRemoveColorButton2d
			// 
			this.fRemoveColorButton2d.Enabled = false;
			this.fRemoveColorButton2d.Location = new System.Drawing.Point(76, 404);
			this.fRemoveColorButton2d.Name = "fRemoveColorButton2d";
			this.fRemoveColorButton2d.Size = new System.Drawing.Size(64, 23);
			this.fRemoveColorButton2d.TabIndex = 61;
			this.fRemoveColorButton2d.Text = "Remove";
			this.fRemoveColorButton2d.Click += new System.EventHandler(this.fRemoveColorButton2d_Click);
			// 
			// fGBox2d
			// 
			this.fGBox2d.Location = new System.Drawing.Point(68, 132);
			this.fGBox2d.Maximum = new System.Decimal(new int[] {
																	255,
																	0,
																	0,
																	0});
			this.fGBox2d.Name = "fGBox2d";
			this.fGBox2d.Size = new System.Drawing.Size(48, 20);
			this.fGBox2d.TabIndex = 60;
			this.fGBox2d.Value = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.fGBox2d.ValueChanged += new System.EventHandler(this.fGBox2d_ValueChanged);
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(60, 12);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(56, 16);
			this.label34.TabIndex = 52;
			this.label34.Text = "Type";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(124, 116);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(24, 16);
			this.label35.TabIndex = 56;
			this.label35.Text = "B";
			// 
			// EditFunction2dColorPanel
			// 
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label30);
			this.Controls.Add(this.fColorSchemePreview2d);
			this.Controls.Add(this.label31);
			this.Controls.Add(this.fRGBBox2d);
			this.Controls.Add(this.fMoveUpButton2d);
			this.Controls.Add(this.fLoadButton2d);
			this.Controls.Add(this.fMoveDownButton2d);
			this.Controls.Add(this.label32);
			this.Controls.Add(this.fAddColor2d);
			this.Controls.Add(this.label33);
			this.Controls.Add(this.fBBox2d);
			this.Controls.Add(this.fRBox2d);
			this.Controls.Add(this.fEditColorType2d);
			this.Controls.Add(this.fColorPreview2d);
			this.Controls.Add(this.fRemoveColorButton2d);
			this.Controls.Add(this.fGBox2d);
			this.Controls.Add(this.label34);
			this.Controls.Add(this.label35);
			this.Name = "EditFunction2dColorPanel";
			this.Size = new System.Drawing.Size(256, 438);
			((System.ComponentModel.ISupportInitialize)(this.fBBox2d)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fRBox2d)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fGBox2d)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void fAddColor2d_Click(object sender, System.EventArgs e) {
			string r = ((int)this.fRBox2d.Value).ToString();
			r = this.FillString(r,3);
			string g = ((int)this.fGBox2d.Value).ToString();
			g = this.FillString(g,3);
			string b = ((int)this.fBBox2d.Value).ToString();
			b = this.FillString(b,3);
			this.fRGBBox2d.Items.Add("rgb["+r+","+g+","+b+"]");
			if ( this.fEditColorType2d.SelectedIndex == 0 ) {
				this.fAddColor2d.Enabled = false;
			}
			this.UpdateColorScheme2d();
		}

		private string FillString(string s, int length) {
			while ( s.Length < length ) {
				s += " ";
			}
			return s;
		}

		private void LoadTips2d(object x, System.EventArgs e) {
			this.LoadColorArray2d(Colors.Tips);
		}

		private void LoadRainbow2d(object x, System.EventArgs e) {
			this.LoadColorArray2d(Colors.Rainbow);
		}

		private void LoadRGB2d(object x, System.EventArgs e) {
			this.LoadColorArray2d(Colors.RGB);
		}

		private void LoadStripes2d(object x, System.EventArgs e) {
			this.LoadColorArray2d(Colors.Stripes);
		}

		private void LoadAmerica2d(object x, System.EventArgs e) {
			this.LoadColorArray2d(Colors.America);
		}

		private void LoadColorArray2d(Color [] c) {
			this.fColors2d = c;
			this.fRGBBox2d.Items.Clear();
			for ( int i = 0; i < c.Length; i++ ) {
				string r = c[i].R.ToString();
				r = this.FillString(r,3);
				string g = c[i].G.ToString();
				g = this.FillString(g,3);
				string b = c[i].B.ToString();
				b = this.FillString(b,3);
				this.fRGBBox2d.Items.Add("rgb["+r+","+g+","+b+"]");
			}
			this.UpdateColorScheme2d();
		}

		private void fMoveUpButton2d_Click(object sender, System.EventArgs e) {
			if ( this.fRGBBox2d.SelectedIndex >= 1 ) {
				int x = this.fRGBBox2d.SelectedIndex;
				object o1 = this.fRGBBox2d.SelectedItem;
				object o2 = this.fRGBBox2d.Items[x-1];
				
				this.fRGBBox2d.Items[x]   = o2;
				this.fRGBBox2d.Items[x-1] = o1;
				this.fRGBBox2d.SelectedIndex = x-1;
				this.UpdateColorScheme2d();
			}
		}

		private void fMoveDownButton2d_Click(object sender, System.EventArgs e) {
			if ( this.fRGBBox2d.SelectedIndex <= this.fRGBBox2d.Items.Count-2 ) {
				int x = this.fRGBBox2d.SelectedIndex;
				object o1 = this.fRGBBox2d.SelectedItem;
				object o2 = this.fRGBBox2d.Items[x+1];
				
				this.fRGBBox2d.Items[x]   = o2;
				this.fRGBBox2d.Items[x+1] = o1;
				this.fRGBBox2d.SelectedIndex = x+1;
				this.UpdateColorScheme2d();
			}
		}

		private void UpdateColorScheme2d() {
			Color [] c = new Color[this.fRGBBox2d.Items.Count];
			for ( int i = 0; i < this.fRGBBox2d.Items.Count; i++ ) {
				c[i] = this.ParseRGB((string)this.fRGBBox2d.Items[i]);
			}
			this.fColors2d = c;
			this.fColorSchemePreview2d.SetColors(c);
			this.fColorSchemePreview2d.Invalidate();
		}

		private void fLoadButton2d_Click(object sender, System.EventArgs e) {
			this.fLoadColorContextMenu2d.Show(
				this,
				new Point(
				this.fLoadButton2d.Location.X+this.fLoadButton2d.Width,
				this.fLoadButton2d.Location.Y));
		}

		private Color ParseRGB(string s) {
			return Color.FromArgb(
				int.Parse(s.Substring(4,3)),
				int.Parse(s.Substring(8,3)),
				int.Parse(s.Substring(12,3)));
		}

		private void fRemoveColorButton2d_Click(object sender, System.EventArgs e) {
			int x = this.fRGBBox2d.SelectedIndex;
			this.fRGBBox2d.Items.Remove(this.fRGBBox2d.SelectedItem);
			if ( this.fRGBBox2d.Items.Count-1 >= x ) {
				this.fRGBBox2d.SelectedIndex = x;
			} else {
				if ( x >= 1 ) {
					this.fRGBBox2d.SelectedIndex = x-1;
				}
			}
			if ( this.fRGBBox2d.Items.Count == 0 ) {
				if ( !this.fAddColor2d.Enabled ) {
					this.fAddColor2d.Enabled = true;
				}
			}
			this.UpdateColorScheme2d();
		}

		private void fEditColorType2d_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fEditColorType2d.SelectedIndex == 0 ) {
				if ( this.fRGBBox2d.Items.Count > 0 ) {
					b = false;
				}
			} else if ( this.fEditColorType2d.SelectedIndex == 1 ) {
			} else if ( this.fEditColorType2d.SelectedIndex == 2 ) {
			} else if ( this.fEditColorType2d.SelectedIndex == 3 ) {	
			}
			this.fAddColor2d.Enabled = b;
			this.fLoadButton2d.Enabled = b;
		}

		private void fRGBBox2d_SelectedIndexChanged(object sender, System.EventArgs e) {
			if ( this.fRGBBox2d.SelectedItem == null ) {
				this.fMoveDownButton2d.Enabled = false;
				this.fMoveUpButton2d.Enabled = false;
				this.fRemoveColorButton2d.Enabled = false;
			} else {
				this.fRemoveColorButton2d.Enabled = true;
				if ( this.fEditColorType2d.SelectedIndex != 0 ) {
					this.fMoveUpButton2d.Enabled = true;
					this.fMoveDownButton2d.Enabled = true;
				}
			}
		}

		private void fRBox2d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview2d.SetColor(
				(int)this.fRBox2d.Value,
				(int)this.fGBox2d.Value,
				(int)this.fBBox2d.Value);
		}

		private void fGBox2d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview2d.SetColor(
				(int)this.fRBox2d.Value,
				(int)this.fGBox2d.Value,
				(int)this.fBBox2d.Value);
		}

		private void fBBox2d_ValueChanged(object sender, System.EventArgs e) {
			this.fColorPreview2d.SetColor(
				(int)this.fRBox2d.Value,
				(int)this.fGBox2d.Value,
				(int)this.fBBox2d.Value);
		}
	}
}
