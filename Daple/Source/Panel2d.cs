using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Plotting.TwoD.Controls {
	/// <summary>
	/// Summary description for Panel2d.
	/// </summary>
	public class Panel2d : System.Windows.Forms.UserControl {

		private enum CurrentTab {
			None,
			EditAxis,
			EditPlotter,
			Analysis
		};

		private enum CurrentPlotter {
			None,
			Function,
			Polar,
			Parametric
		};

		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox fExpressionBox2d2;
		private System.Windows.Forms.Button fCloseAxisButton2d;
		private System.Windows.Forms.Button fApplyAxisButton2d;
		private System.Windows.Forms.Button fCloseAnalysisButton2d;
		private System.Windows.Forms.Button fCloseButton2d;
		private System.Windows.Forms.Button fApplyButton2d;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button fAnalyzeButton2d;
		private System.Windows.Forms.Button fEditButton2d;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button fRemoveButton2d;
		private System.Windows.Forms.Button fAddButton2d;
		private System.Windows.Forms.TextBox fExpressionBox2d;
		private System.Windows.Forms.TabControl fEditAxisTabControl2d;
		private System.Windows.Forms.TabPage tabPage14;
		private System.Windows.Forms.TabPage tabPage15;
		private System.Windows.Forms.TabPage tabPage16;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Button fBackColorButton2d;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TabControl fAnalyzeTabControl2d;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage10;
		private System.Windows.Forms.TabPage tabPage11;
		private System.Windows.Forms.TabPage tabPage12;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.TabControl fEditPlotterTabControl2d;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ListBox fPolarList;

		private GraphPanel2d fGraphPanel;
		private EditAxis2dPanel fXEditPanel;
		private EditAxis2dPanel fYEditPanel;
		private EditPolarAxisPanel fPolarEditPanel;
		private System.Windows.Forms.TabPage tabPage13;
		private CurrentTab fCurrentTab;
		private EditFunction2dPanel fEditFunction2dPanel;
		private EditPolar2dPanel fEditPolar2dPanel;
		private EditFunction2dColorPanel fEditFunction2dColorPanel;
		private Plotter2d fPlotter;
		private System.Windows.Forms.ListBox fFunctionList;
		private System.Windows.Forms.ListBox fParametricList;
		private FunctionExtrema2dPanel fFunctionExtremaPanel;
		private CurrentPlotter fCurrentPlotter;
		private EditParametric2dPanel fEditParametric2dPanel;
		private System.Windows.Forms.ColorDialog fColorDialog;
		private Daple.FunctionParseField fTrigMaxY;
		private Daple.FunctionParseField fTrigMinY;
		private Daple.FunctionParseField fTrigMaxX;
		private Daple.FunctionParseField fTrigMinX;
		private Daple.FunctionParseField fDefaultMaxY;
		private Daple.FunctionParseField fDefaultMinY;
		private Daple.FunctionParseField fDefaultMaxX;
		private Daple.FunctionParseField fDefaultMinX;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Panel2d(GraphPanel2d g, ColorDialog cd) {
			this.fGraphPanel = g;
			InitializeComponent();
			this.PostInitialize(cd);
			this.fCurrentPlotter = CurrentPlotter.None;
		}

		private void PostInitialize(ColorDialog cd) {
			this.fExpressionBox2d.Font = Manager.Font;
			this.fExpressionBox2d2.Font = Manager.Font;
			this.fFunctionList.Font = Manager.Font;
			this.fPolarList.Font = Manager.Font;
			this.fParametricList.Font = Manager.Font;
			this.fDefaultMinX.Value = -10;
			this.fDefaultMaxX.Value = 10;
			this.fDefaultMinY.Value = -10;
			this.fDefaultMaxY.Value = 10;
			this.fTrigMinX.Value = (float)(-2 * MathUtil.Pi);
			this.fTrigMaxX.Value = (float)(2 * MathUtil.Pi);
			this.fTrigMinY.Value = -4;
			this.fTrigMaxY.Value = 4;

			this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

			this.fXEditPanel = new EditAxis2dPanel(
				this.fGraphPanel.pCartesianPlane.pXAxis,
				cd);
			this.fXEditPanel.SetBounds(
				0,
				8,
				256,
				430);
			this.tabPage13.Controls.Add(this.fXEditPanel);
			
			this.fYEditPanel = new EditAxis2dPanel(
				this.fGraphPanel.pCartesianPlane.pYAxis,
				cd);
			this.fYEditPanel.SetBounds(
				0,
				8,
				256,
				430);
			this.tabPage14.Controls.Add(this.fYEditPanel);

			this.fPolarEditPanel = new EditPolarAxisPanel(
				this.fGraphPanel.pCartesianPlane.pPolarAxis,
				cd);
			this.fPolarEditPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage15.Controls.Add(this.fPolarEditPanel);

			this.fEditFunction2dPanel = new EditFunction2dPanel();
			this.fEditFunction2dPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage8.Controls.Add(this.fEditFunction2dPanel);

			this.fEditFunction2dColorPanel = new EditFunction2dColorPanel();
			this.fEditFunction2dPanel.SetListBox(this.fFunctionList);
			this.fEditFunction2dColorPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage9.Controls.Add(this.fEditFunction2dColorPanel);
		
			this.fFunctionExtremaPanel = new FunctionExtrema2dPanel();
			this.fFunctionExtremaPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage10.Controls.Add(this.fFunctionExtremaPanel);
		
			this.fEditPolar2dPanel = new EditPolar2dPanel();
			this.fEditPolar2dPanel.SetListBox(this.fPolarList);
			this.fEditPolar2dPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage8.Controls.Add(this.fEditPolar2dPanel);

			this.fEditParametric2dPanel = new EditParametric2dPanel();
			this.fEditParametric2dPanel.SetListBox(this.fParametricList);
			this.fEditParametric2dPanel.SetBounds(
				0,
				0,
				256,
				438);
			this.tabPage8.Controls.Add(this.fEditParametric2dPanel);

			this.fCurrentPlotter = CurrentPlotter.None;
			this.UpdateCurrentPlotter();
		}

		private void UpdateCurrentPlotter() {
			bool b = false;
			if ( this.fCurrentPlotter == CurrentPlotter.Function ) {
				b = true;
			}
			this.fEditFunction2dPanel.Visible = b;

			b = false;
			if ( this.fCurrentPlotter == CurrentPlotter.Polar ) {
				b = true;
			}
			this.fEditPolar2dPanel.Visible = b;

			b = false;
			if ( this.fCurrentPlotter == CurrentPlotter.Parametric ) {
				b = true;
			}
			this.fEditParametric2dPanel.Visible = b;
		}

		private void RemoveListBoxItem(ListBox b) {
			int x = b.SelectedIndex;
			this.fGraphPanel.Remove((string)b.SelectedItem);
			b.Items.Remove(b.SelectedItem);
			if ( b.Items.Count-1 >= x ) {
				b.SelectedIndex = x;
			} else {
				if ( x >= 1 ) {
					b.SelectedIndex = x-1;
				}
			}
			if ( b.Items.Count == 0 ) {
				this.fAnalyzeButton2d.Enabled = false;
				this.fEditButton2d.Enabled = false;
				this.fRemoveButton2d.Enabled = false;
				if ( this.fCurrentTab == CurrentTab.EditPlotter ) {
					this.fCurrentTab = CurrentTab.None;
					this.UpdateControls();
				}
			}
			this.fGraphPanel.Invalidate();
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

		private void UpdateControls() {
			bool b = false;
			if ( this.fCurrentTab == CurrentTab.EditAxis ) {
				b = true;
			}
			this.fEditAxisTabControl2d.Visible =b;
			this.fApplyAxisButton2d.Visible = b;
			this.fCloseAxisButton2d.Visible = b;

			b = false;
			if ( this.fCurrentTab == CurrentTab.EditPlotter ) {
				b = true;
			}
			this.fEditPlotterTabControl2d.Visible = b;
			this.fApplyButton2d.Visible = b;
			this.fCloseButton2d.Visible = b;

			b = false;
			if ( this.fCurrentTab == CurrentTab.Analysis ) {
				b = true;
			}
			this.fAnalyzeTabControl2d.Visible = b;
			this.fCloseAnalysisButton2d.Visible = b;
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.button6 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.fExpressionBox2d2 = new System.Windows.Forms.TextBox();
			this.fCloseAxisButton2d = new System.Windows.Forms.Button();
			this.fApplyAxisButton2d = new System.Windows.Forms.Button();
			this.fCloseAnalysisButton2d = new System.Windows.Forms.Button();
			this.fCloseButton2d = new System.Windows.Forms.Button();
			this.fApplyButton2d = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.fAnalyzeButton2d = new System.Windows.Forms.Button();
			this.fEditButton2d = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.fRemoveButton2d = new System.Windows.Forms.Button();
			this.fAddButton2d = new System.Windows.Forms.Button();
			this.fExpressionBox2d = new System.Windows.Forms.TextBox();
			this.fEditAxisTabControl2d = new System.Windows.Forms.TabControl();
			this.tabPage13 = new System.Windows.Forms.TabPage();
			this.tabPage14 = new System.Windows.Forms.TabPage();
			this.tabPage15 = new System.Windows.Forms.TabPage();
			this.tabPage16 = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.fTrigMaxY = new Daple.FunctionParseField();
			this.fTrigMinY = new Daple.FunctionParseField();
			this.fTrigMaxX = new Daple.FunctionParseField();
			this.fTrigMinX = new Daple.FunctionParseField();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.fDefaultMaxY = new Daple.FunctionParseField();
			this.fDefaultMinY = new Daple.FunctionParseField();
			this.fDefaultMaxX = new Daple.FunctionParseField();
			this.fDefaultMinX = new Daple.FunctionParseField();
			this.label71 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.fBackColorButton2d = new System.Windows.Forms.Button();
			this.label67 = new System.Windows.Forms.Label();
			this.fEditPlotterTabControl2d = new System.Windows.Forms.TabControl();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.fFunctionList = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.fPolarList = new System.Windows.Forms.ListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.fParametricList = new System.Windows.Forms.ListBox();
			this.fAnalyzeTabControl2d = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.tabPage12 = new System.Windows.Forms.TabPage();
			this.label40 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.fColorDialog = new System.Windows.Forms.ColorDialog();
			this.fEditAxisTabControl2d.SuspendLayout();
			this.tabPage16.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.fEditPlotterTabControl2d.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.fAnalyzeTabControl2d.SuspendLayout();
			this.tabPage12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			this.SuspendLayout();
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(192, 73);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 20);
			this.button6.TabIndex = 5;
			this.button6.Text = "Parametric";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(104, 73);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 20);
			this.button3.TabIndex = 4;
			this.button3.Text = "Polar";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// fExpressionBox2d2
			// 
			this.fExpressionBox2d2.Location = new System.Drawing.Point(8, 50);
			this.fExpressionBox2d2.Name = "fExpressionBox2d2";
			this.fExpressionBox2d2.Size = new System.Drawing.Size(264, 20);
			this.fExpressionBox2d2.TabIndex = 2;
			// 
			// fCloseAxisButton2d
			// 
			this.fCloseAxisButton2d.Location = new System.Drawing.Point(160, 752);
			this.fCloseAxisButton2d.Name = "fCloseAxisButton2d";
			this.fCloseAxisButton2d.Size = new System.Drawing.Size(75, 23);
			this.fCloseAxisButton2d.TabIndex = 25;
			this.fCloseAxisButton2d.Text = "Close";
			this.fCloseAxisButton2d.Visible = false;
			this.fCloseAxisButton2d.Click += new System.EventHandler(this.fCloseAxisButton2d_Click);
			// 
			// fApplyAxisButton2d
			// 
			this.fApplyAxisButton2d.Location = new System.Drawing.Point(48, 752);
			this.fApplyAxisButton2d.Name = "fApplyAxisButton2d";
			this.fApplyAxisButton2d.Size = new System.Drawing.Size(75, 23);
			this.fApplyAxisButton2d.TabIndex = 24;
			this.fApplyAxisButton2d.Text = "Apply";
			this.fApplyAxisButton2d.Visible = false;
			this.fApplyAxisButton2d.Click += new System.EventHandler(this.fApplyAxisButton2d_Click);
			// 
			// fCloseAnalysisButton2d
			// 
			this.fCloseAnalysisButton2d.Location = new System.Drawing.Point(104, 752);
			this.fCloseAnalysisButton2d.Name = "fCloseAnalysisButton2d";
			this.fCloseAnalysisButton2d.Size = new System.Drawing.Size(75, 23);
			this.fCloseAnalysisButton2d.TabIndex = 22;
			this.fCloseAnalysisButton2d.Text = "Close";
			this.fCloseAnalysisButton2d.Visible = false;
			this.fCloseAnalysisButton2d.Click += new System.EventHandler(this.fCloseAnalysisButton2d_Click);
			// 
			// fCloseButton2d
			// 
			this.fCloseButton2d.Location = new System.Drawing.Point(160, 752);
			this.fCloseButton2d.Name = "fCloseButton2d";
			this.fCloseButton2d.Size = new System.Drawing.Size(75, 23);
			this.fCloseButton2d.TabIndex = 20;
			this.fCloseButton2d.Text = "Close";
			this.fCloseButton2d.Visible = false;
			this.fCloseButton2d.Click += new System.EventHandler(this.fCloseButton2d_Click);
			// 
			// fApplyButton2d
			// 
			this.fApplyButton2d.Location = new System.Drawing.Point(48, 752);
			this.fApplyButton2d.Name = "fApplyButton2d";
			this.fApplyButton2d.Size = new System.Drawing.Size(75, 23);
			this.fApplyButton2d.TabIndex = 19;
			this.fApplyButton2d.Text = "Apply";
			this.fApplyButton2d.Visible = false;
			this.fApplyButton2d.Click += new System.EventHandler(this.fApplyButton2d_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(80, 254);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(124, 20);
			this.button10.TabIndex = 9;
			this.button10.Text = "Edit Axes";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// fAnalyzeButton2d
			// 
			this.fAnalyzeButton2d.Enabled = false;
			this.fAnalyzeButton2d.Location = new System.Drawing.Point(16, 226);
			this.fAnalyzeButton2d.Name = "fAnalyzeButton2d";
			this.fAnalyzeButton2d.Size = new System.Drawing.Size(75, 20);
			this.fAnalyzeButton2d.TabIndex = 6;
			this.fAnalyzeButton2d.Text = "Analyze";
			this.fAnalyzeButton2d.Click += new System.EventHandler(this.fAnalyzeButton2d_Click);
			// 
			// fEditButton2d
			// 
			this.fEditButton2d.Enabled = false;
			this.fEditButton2d.Location = new System.Drawing.Point(104, 226);
			this.fEditButton2d.Name = "fEditButton2d";
			this.fEditButton2d.Size = new System.Drawing.Size(75, 20);
			this.fEditButton2d.TabIndex = 7;
			this.fEditButton2d.Text = "Edit";
			this.fEditButton2d.Click += new System.EventHandler(this.fEditButton2d_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Expression(s)";
			// 
			// fRemoveButton2d
			// 
			this.fRemoveButton2d.Enabled = false;
			this.fRemoveButton2d.Location = new System.Drawing.Point(192, 226);
			this.fRemoveButton2d.Name = "fRemoveButton2d";
			this.fRemoveButton2d.Size = new System.Drawing.Size(75, 20);
			this.fRemoveButton2d.TabIndex = 8;
			this.fRemoveButton2d.Text = "Remove";
			this.fRemoveButton2d.Click += new System.EventHandler(this.fRemoveButton2d_Click);
			// 
			// fAddButton2d
			// 
			this.fAddButton2d.Location = new System.Drawing.Point(16, 73);
			this.fAddButton2d.Name = "fAddButton2d";
			this.fAddButton2d.Size = new System.Drawing.Size(75, 20);
			this.fAddButton2d.TabIndex = 3;
			this.fAddButton2d.Text = "Function";
			this.fAddButton2d.Click += new System.EventHandler(this.fAddButton2d_Click);
			// 
			// fExpressionBox2d
			// 
			this.fExpressionBox2d.Location = new System.Drawing.Point(8, 26);
			this.fExpressionBox2d.Name = "fExpressionBox2d";
			this.fExpressionBox2d.Size = new System.Drawing.Size(264, 20);
			this.fExpressionBox2d.TabIndex = 1;
			// 
			// fEditAxisTabControl2d
			// 
			this.fEditAxisTabControl2d.Controls.Add(this.tabPage13);
			this.fEditAxisTabControl2d.Controls.Add(this.tabPage14);
			this.fEditAxisTabControl2d.Controls.Add(this.tabPage15);
			this.fEditAxisTabControl2d.Controls.Add(this.tabPage16);
			this.fEditAxisTabControl2d.Location = new System.Drawing.Point(8, 280);
			this.fEditAxisTabControl2d.Name = "fEditAxisTabControl2d";
			this.fEditAxisTabControl2d.SelectedIndex = 0;
			this.fEditAxisTabControl2d.Size = new System.Drawing.Size(264, 464);
			this.fEditAxisTabControl2d.TabIndex = 23;
			this.fEditAxisTabControl2d.Visible = false;
			// 
			// tabPage13
			// 
			this.tabPage13.Location = new System.Drawing.Point(4, 22);
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Size = new System.Drawing.Size(256, 438);
			this.tabPage13.TabIndex = 0;
			this.tabPage13.Text = "X Axis";
			// 
			// tabPage14
			// 
			this.tabPage14.Location = new System.Drawing.Point(4, 22);
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Size = new System.Drawing.Size(256, 438);
			this.tabPage14.TabIndex = 1;
			this.tabPage14.Text = "Y Axis";
			this.tabPage14.Visible = false;
			// 
			// tabPage15
			// 
			this.tabPage15.Location = new System.Drawing.Point(4, 22);
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Size = new System.Drawing.Size(256, 438);
			this.tabPage15.TabIndex = 2;
			this.tabPage15.Text = "Polar Axis";
			this.tabPage15.Visible = false;
			// 
			// tabPage16
			// 
			this.tabPage16.Controls.Add(this.groupBox11);
			this.tabPage16.Controls.Add(this.groupBox10);
			this.tabPage16.Controls.Add(this.fBackColorButton2d);
			this.tabPage16.Controls.Add(this.label67);
			this.tabPage16.Location = new System.Drawing.Point(4, 22);
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Size = new System.Drawing.Size(256, 438);
			this.tabPage16.TabIndex = 3;
			this.tabPage16.Text = "General";
			this.tabPage16.Visible = false;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.fTrigMaxY);
			this.groupBox11.Controls.Add(this.fTrigMinY);
			this.groupBox11.Controls.Add(this.fTrigMaxX);
			this.groupBox11.Controls.Add(this.fTrigMinX);
			this.groupBox11.Controls.Add(this.label72);
			this.groupBox11.Controls.Add(this.label73);
			this.groupBox11.Controls.Add(this.label74);
			this.groupBox11.Controls.Add(this.label75);
			this.groupBox11.Location = new System.Drawing.Point(8, 264);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(240, 128);
			this.groupBox11.TabIndex = 20;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Trig Zoom";
			// 
			// fTrigMaxY
			// 
			this.fTrigMaxY.Location = new System.Drawing.Point(144, 88);
			this.fTrigMaxY.Name = "fTrigMaxY";
			this.fTrigMaxY.Size = new System.Drawing.Size(80, 20);
			this.fTrigMaxY.TabIndex = 19;
			this.fTrigMaxY.Value = 0F;
			// 
			// fTrigMinY
			// 
			this.fTrigMinY.Location = new System.Drawing.Point(24, 88);
			this.fTrigMinY.Name = "fTrigMinY";
			this.fTrigMinY.Size = new System.Drawing.Size(80, 20);
			this.fTrigMinY.TabIndex = 18;
			this.fTrigMinY.Value = 0F;
			// 
			// fTrigMaxX
			// 
			this.fTrigMaxX.Location = new System.Drawing.Point(144, 40);
			this.fTrigMaxX.Name = "fTrigMaxX";
			this.fTrigMaxX.Size = new System.Drawing.Size(80, 20);
			this.fTrigMaxX.TabIndex = 17;
			this.fTrigMaxX.Value = 0F;
			// 
			// fTrigMinX
			// 
			this.fTrigMinX.Location = new System.Drawing.Point(24, 40);
			this.fTrigMinX.Name = "fTrigMinX";
			this.fTrigMinX.Size = new System.Drawing.Size(80, 20);
			this.fTrigMinX.TabIndex = 16;
			this.fTrigMinX.Value = 0F;
			// 
			// label72
			// 
			this.label72.Location = new System.Drawing.Point(24, 72);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(64, 16);
			this.label72.TabIndex = 14;
			this.label72.Text = "Minimum Y";
			// 
			// label73
			// 
			this.label73.Location = new System.Drawing.Point(144, 72);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(64, 16);
			this.label73.TabIndex = 13;
			this.label73.Text = "Maximum Y";
			// 
			// label74
			// 
			this.label74.Location = new System.Drawing.Point(144, 24);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(64, 16);
			this.label74.TabIndex = 12;
			this.label74.Text = "Maximum X";
			// 
			// label75
			// 
			this.label75.Location = new System.Drawing.Point(24, 24);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(64, 16);
			this.label75.TabIndex = 11;
			this.label75.Text = "Minimum X";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.fDefaultMaxY);
			this.groupBox10.Controls.Add(this.fDefaultMinY);
			this.groupBox10.Controls.Add(this.fDefaultMaxX);
			this.groupBox10.Controls.Add(this.fDefaultMinX);
			this.groupBox10.Controls.Add(this.label71);
			this.groupBox10.Controls.Add(this.label70);
			this.groupBox10.Controls.Add(this.label69);
			this.groupBox10.Controls.Add(this.label68);
			this.groupBox10.Location = new System.Drawing.Point(8, 96);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(240, 128);
			this.groupBox10.TabIndex = 19;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Default Zoom";
			// 
			// fDefaultMaxY
			// 
			this.fDefaultMaxY.Location = new System.Drawing.Point(144, 88);
			this.fDefaultMaxY.Name = "fDefaultMaxY";
			this.fDefaultMaxY.Size = new System.Drawing.Size(80, 20);
			this.fDefaultMaxY.TabIndex = 18;
			this.fDefaultMaxY.Value = 0F;
			// 
			// fDefaultMinY
			// 
			this.fDefaultMinY.Location = new System.Drawing.Point(24, 88);
			this.fDefaultMinY.Name = "fDefaultMinY";
			this.fDefaultMinY.Size = new System.Drawing.Size(80, 20);
			this.fDefaultMinY.TabIndex = 17;
			this.fDefaultMinY.Value = 0F;
			// 
			// fDefaultMaxX
			// 
			this.fDefaultMaxX.Location = new System.Drawing.Point(144, 40);
			this.fDefaultMaxX.Name = "fDefaultMaxX";
			this.fDefaultMaxX.Size = new System.Drawing.Size(80, 20);
			this.fDefaultMaxX.TabIndex = 16;
			this.fDefaultMaxX.Value = 0F;
			// 
			// fDefaultMinX
			// 
			this.fDefaultMinX.Location = new System.Drawing.Point(24, 40);
			this.fDefaultMinX.Name = "fDefaultMinX";
			this.fDefaultMinX.Size = new System.Drawing.Size(80, 20);
			this.fDefaultMinX.TabIndex = 15;
			this.fDefaultMinX.Value = 0F;
			// 
			// label71
			// 
			this.label71.Location = new System.Drawing.Point(24, 72);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(64, 16);
			this.label71.TabIndex = 14;
			this.label71.Text = "Minimum Y";
			// 
			// label70
			// 
			this.label70.Location = new System.Drawing.Point(144, 72);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(64, 16);
			this.label70.TabIndex = 13;
			this.label70.Text = "Maximum Y";
			// 
			// label69
			// 
			this.label69.Location = new System.Drawing.Point(144, 24);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(64, 16);
			this.label69.TabIndex = 12;
			this.label69.Text = "Maximum X";
			// 
			// label68
			// 
			this.label68.Location = new System.Drawing.Point(24, 24);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(64, 16);
			this.label68.TabIndex = 11;
			this.label68.Text = "Minimum X";
			// 
			// fBackColorButton2d
			// 
			this.fBackColorButton2d.BackColor = System.Drawing.Color.White;
			this.fBackColorButton2d.Location = new System.Drawing.Point(144, 40);
			this.fBackColorButton2d.Name = "fBackColorButton2d";
			this.fBackColorButton2d.Size = new System.Drawing.Size(80, 16);
			this.fBackColorButton2d.TabIndex = 18;
			this.fBackColorButton2d.Text = "...";
			this.fBackColorButton2d.UseVisualStyleBackColor = false;
			this.fBackColorButton2d.Click += new System.EventHandler(this.fBackColorButton2d_Click);
			// 
			// label67
			// 
			this.label67.Location = new System.Drawing.Point(40, 40);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(72, 16);
			this.label67.TabIndex = 0;
			this.label67.Text = "Back Color";
			// 
			// fEditPlotterTabControl2d
			// 
			this.fEditPlotterTabControl2d.Controls.Add(this.tabPage8);
			this.fEditPlotterTabControl2d.Controls.Add(this.tabPage9);
			this.fEditPlotterTabControl2d.Location = new System.Drawing.Point(8, 280);
			this.fEditPlotterTabControl2d.Name = "fEditPlotterTabControl2d";
			this.fEditPlotterTabControl2d.SelectedIndex = 0;
			this.fEditPlotterTabControl2d.Size = new System.Drawing.Size(264, 464);
			this.fEditPlotterTabControl2d.TabIndex = 17;
			this.fEditPlotterTabControl2d.Visible = false;
			// 
			// tabPage8
			// 
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(256, 438);
			this.tabPage8.TabIndex = 0;
			this.tabPage8.Text = "Plotting";
			// 
			// tabPage9
			// 
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(256, 438);
			this.tabPage9.TabIndex = 1;
			this.tabPage9.Text = "Coloring";
			this.tabPage9.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(8, 104);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(264, 120);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.fFunctionList);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(256, 94);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Function";
			// 
			// fFunctionList
			// 
			this.fFunctionList.Location = new System.Drawing.Point(0, 0);
			this.fFunctionList.Name = "fFunctionList";
			this.fFunctionList.Size = new System.Drawing.Size(256, 95);
			this.fFunctionList.TabIndex = 27;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.fPolarList);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(256, 94);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Polar";
			// 
			// fPolarList
			// 
			this.fPolarList.HorizontalScrollbar = true;
			this.fPolarList.Location = new System.Drawing.Point(0, 0);
			this.fPolarList.Name = "fPolarList";
			this.fPolarList.Size = new System.Drawing.Size(256, 95);
			this.fPolarList.TabIndex = 0;
			this.fPolarList.SelectedIndexChanged += new System.EventHandler(this.fPolarList_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.fParametricList);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(256, 94);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Parametric";
			// 
			// fParametricList
			// 
			this.fParametricList.Location = new System.Drawing.Point(0, 0);
			this.fParametricList.Name = "fParametricList";
			this.fParametricList.Size = new System.Drawing.Size(256, 95);
			this.fParametricList.TabIndex = 27;
			// 
			// fAnalyzeTabControl2d
			// 
			this.fAnalyzeTabControl2d.Controls.Add(this.tabPage4);
			this.fAnalyzeTabControl2d.Controls.Add(this.tabPage10);
			this.fAnalyzeTabControl2d.Controls.Add(this.tabPage11);
			this.fAnalyzeTabControl2d.Controls.Add(this.tabPage12);
			this.fAnalyzeTabControl2d.Location = new System.Drawing.Point(8, 280);
			this.fAnalyzeTabControl2d.Name = "fAnalyzeTabControl2d";
			this.fAnalyzeTabControl2d.SelectedIndex = 0;
			this.fAnalyzeTabControl2d.Size = new System.Drawing.Size(264, 464);
			this.fAnalyzeTabControl2d.TabIndex = 21;
			this.fAnalyzeTabControl2d.Visible = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(256, 438);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Expression";
			// 
			// tabPage10
			// 
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Size = new System.Drawing.Size(256, 438);
			this.tabPage10.TabIndex = 1;
			this.tabPage10.Text = "Extrema";
			this.tabPage10.Visible = false;
			// 
			// tabPage11
			// 
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Size = new System.Drawing.Size(256, 438);
			this.tabPage11.TabIndex = 2;
			this.tabPage11.Text = "Differential Calculus";
			this.tabPage11.Visible = false;
			// 
			// tabPage12
			// 
			this.tabPage12.Controls.Add(this.label40);
			this.tabPage12.Controls.Add(this.numericUpDown1);
			this.tabPage12.Controls.Add(this.label41);
			this.tabPage12.Controls.Add(this.label42);
			this.tabPage12.Controls.Add(this.numericUpDown2);
			this.tabPage12.Controls.Add(this.numericUpDown3);
			this.tabPage12.Location = new System.Drawing.Point(4, 22);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Size = new System.Drawing.Size(256, 438);
			this.tabPage12.TabIndex = 3;
			this.tabPage12.Text = "Integral Calculus";
			this.tabPage12.Visible = false;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(24, 104);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(96, 16);
			this.label40.TabIndex = 21;
			this.label40.Text = "Points Calculated";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(120, 104);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(112, 20);
			this.numericUpDown1.TabIndex = 20;
			this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(24, 64);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(88, 16);
			this.label41.TabIndex = 19;
			this.label41.Text = "Maximum X";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(24, 24);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(88, 16);
			this.label42.TabIndex = 18;
			this.label42.Text = "Minimum X";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 2;
			this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown2.Location = new System.Drawing.Point(120, 64);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(112, 20);
			this.numericUpDown2.TabIndex = 17;
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.DecimalPlaces = 2;
			this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown3.Location = new System.Drawing.Point(120, 24);
			this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown3.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(112, 20);
			this.numericUpDown3.TabIndex = 16;
			// 
			// Panel2d
			// 
			this.Controls.Add(this.fAnalyzeTabControl2d);
			this.Controls.Add(this.fEditAxisTabControl2d);
			this.Controls.Add(this.fCloseAxisButton2d);
			this.Controls.Add(this.fApplyAxisButton2d);
			this.Controls.Add(this.fCloseAnalysisButton2d);
			this.Controls.Add(this.fCloseButton2d);
			this.Controls.Add(this.fApplyButton2d);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.fEditPlotterTabControl2d);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fRemoveButton2d);
			this.Controls.Add(this.fAddButton2d);
			this.Controls.Add(this.fExpressionBox2d);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.fExpressionBox2d2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.fAnalyzeButton2d);
			this.Controls.Add(this.fEditButton2d);
			this.Name = "Panel2d";
			this.Size = new System.Drawing.Size(288, 776);
			this.fEditAxisTabControl2d.ResumeLayout(false);
			this.tabPage16.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.fEditPlotterTabControl2d.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.fAnalyzeTabControl2d.ResumeLayout(false);
			this.tabPage12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void fAddButton2d_Click(object sender, System.EventArgs e) {
			if ( !this.fExpressionBox2d.Text.Equals("") ) {
				this.fFunctionList.Items.Add(this.fExpressionBox2d.Text);
				FunctionPlotter f = new FunctionPlotter(this.fGraphPanel.pCartesianPlane);
				f.pExpression = new Daple.Expressions.Expression(this.fExpressionBox2d.Text);
				this.fExpressionBox2d.Text = "";
				this.fExpressionBox2d2.Text = "";
				this.fGraphPanel.Add(f);
				this.fGraphPanel.Invalidate();
				this.tabControl1.SelectedIndex = 0;
				this.fFunctionList.SelectedIndex = this.fFunctionList.Items.Count-1;
				this.tabControl1_SelectedIndexChanged(null,null);
			}
		}

		private void button3_Click(object sender, System.EventArgs e) {
			if ( !this.fExpressionBox2d.Text.Equals("") ) {
				this.fPolarList.Items.Add(this.fExpressionBox2d.Text);
				PolarPlotter f = new PolarPlotter(this.fGraphPanel.pCartesianPlane);
				f.pExpression = new Daple.Expressions.Expression(this.fExpressionBox2d.Text);
				this.fExpressionBox2d.Text = "";
				this.fExpressionBox2d2.Text = "";
				this.fGraphPanel.Add(f);
				this.fGraphPanel.Invalidate();
				this.tabControl1.SelectedIndex = 1;
				this.fPolarList.SelectedIndex = this.fPolarList.Items.Count-1;
			}
		}

		private void button6_Click(object sender, System.EventArgs e) {
			if ( !this.fExpressionBox2d.Text.Equals("") ) {
				this.fParametricList.Items.Add("["+this.fExpressionBox2d.Text+","+this.fExpressionBox2d2.Text+"]");
				ParametricPlotter f = new ParametricPlotter(this.fGraphPanel.pCartesianPlane);
				f.pExpression = new Daple.Expressions.Expression(this.fExpressionBox2d.Text);
				f.pExpression2 = new Daple.Expressions.Expression(this.fExpressionBox2d2.Text);
				this.fExpressionBox2d.Text = "";
				this.fExpressionBox2d2.Text = "";
				this.fGraphPanel.Add(f);
				this.fGraphPanel.Invalidate();
				this.tabControl1.SelectedIndex = 2;
				this.fParametricList.SelectedIndex = this.fParametricList.Items.Count-1;
			}
		}

		private void button10_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.EditAxis;

			this.fXEditPanel.UpdateFromAxis();
			this.fYEditPanel.UpdateFromAxis();
			this.fPolarEditPanel.UpdateFromAxis();

			this.UpdateControls();
		}

		private void fRemoveButton2d_Click(object sender, System.EventArgs e) {
			if ( this.tabControl1.SelectedIndex == 0 ) {
				this.SelectFunctionPlotter();
				this.RemoveListBoxItem(this.fFunctionList);
			} else if ( this.tabControl1.SelectedIndex == 1 ) {
				this.SelectPolarPlotter();
				this.RemoveListBoxItem(this.fPolarList);
			} else if ( this.tabControl1.SelectedIndex == 2 ) {
				this.SelectParametricPlotter();
				this.RemoveListBoxItem(this.fParametricList);
			}
			this.fGraphPanel.Remove(this.fPlotter);
			this.fGraphPanel.Invalidate();
		}

		private void fMinimizeButton_Click(object sender, System.EventArgs e) {
			this.Size = new Size(16,this.Size.Height);
			this.Invalidate();
		}

		private void fApplyAxisButton2d_Click(object sender, System.EventArgs e) {
			this.fXEditPanel.ApplyToAxis();
			this.fYEditPanel.ApplyToAxis();
			this.fPolarEditPanel.ApplyToAxis();

			this.UpdateAxisLockedPlotters();
			this.fGraphPanel.BackColor = this.fBackColorButton2d.BackColor;

			this.fGraphPanel.Invalidate();
		}

		private void fCloseAxisButton2d_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.None;
			this.UpdateControls();
		}

		private void fCloseAnalysisButton2d_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.None;
			this.UpdateControls();
		}

		private void fCloseButton2d_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.None;
			this.UpdateControls();
		}

		private void fApplyButton2d_Click(object sender, System.EventArgs e) {
			if ( this.fCurrentPlotter == CurrentPlotter.Function ) {
				this.fEditFunction2dPanel.ApplyToPlotter();
			} else if ( this.fCurrentPlotter == CurrentPlotter.Polar ) {
				this.fEditPolar2dPanel.ApplyToPlotter();
			} else if ( this.fCurrentPlotter == CurrentPlotter.Parametric) {
				this.fEditParametric2dPanel.ApplyToPlotter();
			}
			this.fEditFunction2dColorPanel.ApplyToPlotter();
			this.fGraphPanel.Invalidate();
		}

		private void fFunctionList_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fFunctionList.SelectedItem == null ) {
				b = false;
			}
			this.fAnalyzeButton2d.Enabled = b;
			this.fRemoveButton2d.Enabled = b;
			this.fEditButton2d.Enabled = b;
		}

		private void fPolarList_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fPolarList.SelectedItem == null ) {
				b = false;
			}
			this.fAnalyzeButton2d.Enabled = b;
			this.fRemoveButton2d.Enabled = b;
			this.fEditButton2d.Enabled = b;
		}

		private void fParametricList_SelectedIndexChanged(object sender, System.EventArgs e) {
			bool b = true;
			if ( this.fParametricList.SelectedItem == null ) {
				b = false;
			}
			this.fAnalyzeButton2d.Enabled = b;
			this.fRemoveButton2d.Enabled = b;
			this.fEditButton2d.Enabled = b;
		}

		private void fAnalyzeButton2d_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.Analysis;
			this.UpdateControls();

			if ( this.tabControl1.SelectedIndex == 0 ) {
				this.fFunctionExtremaPanel.SetExpression(new Daple.Expressions.Expression((string)this.fFunctionList.SelectedItem));
			}
		}

		private void fEditButton2d_Click(object sender, System.EventArgs e) {
			this.fCurrentTab = CurrentTab.EditPlotter;
			this.UpdateControls();
			this.EditPlotter();
		}

		private void EditPlotter() {
			if ( this.tabControl1.SelectedIndex == 0 ) {
				this.SelectFunctionPlotter();
				this.fEditFunction2dPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.UpdateFromPlotter();
				this.fEditFunction2dPanel.UpdateFromPlotter();
			} else if ( this.tabControl1.SelectedIndex == 1 ) {
				this.SelectPolarPlotter();
				this.fEditPolar2dPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.UpdateFromPlotter();
				this.fEditPolar2dPanel.UpdateFromPlotter();
			} else if ( this.tabControl1.SelectedIndex == 2 ) {
				this.SelectParametricPlotter();
				this.fEditParametric2dPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.SetPlotter(this.fPlotter);
				this.fEditFunction2dColorPanel.UpdateFromPlotter();
				this.fEditParametric2dPanel.UpdateFromPlotter();
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
			bool b = true;
			if ( this.tabControl1.SelectedIndex == 0 ) {
				this.fCurrentPlotter = CurrentPlotter.Function;
				if ( this.fFunctionList.SelectedItem == null ) {
					b = false;
				}
			} else if ( this.tabControl1.SelectedIndex == 1 ) {
				this.fCurrentPlotter = CurrentPlotter.Polar;
				if ( this.fPolarList.SelectedItem == null ) {
					b = false;
				}
			} else if ( this.tabControl1.SelectedIndex == 2 ) {
				this.fCurrentPlotter = CurrentPlotter.Parametric;
				if ( this.fParametricList.SelectedItem == null ) {
					b = false;
				}
			}
			this.fAnalyzeButton2d.Enabled = b;
			this.fEditButton2d.Enabled = b;
			this.fRemoveButton2d.Enabled = b;
			this.UpdateCurrentPlotter();
		}

		private void SelectFunctionPlotter() {
			for ( int i = 0; i < this.fGraphPanel.pDrawables.Count; i++ ) {
				IDrawable id = this.fGraphPanel.pDrawables[i];
				if ( id is FunctionPlotter ) {
					if ( ((FunctionPlotter)id).pExpression.ToString().Equals((string)this.fFunctionList.SelectedItem) ) {
						this.fPlotter = (Plotter2d)id;
					}
				}
			}
		}

		private void SelectPolarPlotter() {
			for ( int i = 0; i < this.fGraphPanel.pDrawables.Count; i++ ) {
				IDrawable id = this.fGraphPanel.pDrawables[i];
				if ( id is PolarPlotter ) {
					if ( ((PolarPlotter)id).pExpression.ToString().Equals((string)this.fPolarList.SelectedItem) ) {
						this.fPlotter = (Plotter2d)id;
					}
				}
			}
		}

		private void SelectParametricPlotter() {
			for ( int i = 0; i < this.fGraphPanel.pDrawables.Count; i++ ) {
				IDrawable id = this.fGraphPanel.pDrawables[i];
				System.Console.WriteLine("here0");
				if ( id is ParametricPlotter ) {
					System.Console.WriteLine("here1:"+this.fParametricList.SelectedItem);
					System.Console.WriteLine("hasdf:"+this.fParametricList.SelectedIndex);
					if ( ((ParametricPlotter)id).GetExpressions().Equals((string)this.fParametricList.SelectedItem) ) {
						System.Console.WriteLine("here2");
						this.fPlotter = (Plotter2d)id;
					}
				}
			}
		}

		private void UpdateAxisLockedPlotters() {
			foreach ( IDrawable id in this.fGraphPanel.pDrawables ) {
				if ( id is FunctionPlotter ) {
					if ( ((FunctionPlotter)id).pIsAxisLockedBounds ) {
						((FunctionPlotter)id).pMinX = this.fGraphPanel.pCartesianPlane.pXAxis.pMin;
						((FunctionPlotter)id).pMaxX = this.fGraphPanel.pCartesianPlane.pXAxis.pMax;
					}
				}
			}
		}

		public void SetDefaultZoom() {
			this.fGraphPanel.pCartesianPlane.pXAxis.pMin = this.fDefaultMinX.Value;
			this.fGraphPanel.pCartesianPlane.pXAxis.pMax = this.fDefaultMaxX.Value;
			this.fGraphPanel.pCartesianPlane.pYAxis.pMin = this.fDefaultMinY.Value;
			this.fGraphPanel.pCartesianPlane.pYAxis.pMax = this.fDefaultMaxY.Value;
			
			this.UpdateAxisLockedPlotters();
		}

		public void SetTrigZoom() {
			this.fGraphPanel.pCartesianPlane.pXAxis.pMin = this.fTrigMinX.Value;
			this.fGraphPanel.pCartesianPlane.pXAxis.pMax = this.fTrigMaxX.Value;
			this.fGraphPanel.pCartesianPlane.pYAxis.pMin = this.fTrigMinY.Value;
			this.fGraphPanel.pCartesianPlane.pYAxis.pMax = this.fTrigMaxY.Value;
		
			this.UpdateAxisLockedPlotters();
		}

		private void fBackColorButton2d_Click(object sender, System.EventArgs e) {
			this.fColorDialog.ShowDialog();
			this.fBackColorButton2d.BackColor = this.fColorDialog.Color;
		}
	}
}
