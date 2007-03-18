using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Daple.Commands.Controls {
	/// <summary>
	/// Summary description for CommandLinePanel.
	/// </summary>
	public class CommandLinePanel : System.Windows.Forms.UserControl {
		
		protected CommandPanelCollection fPanels;

		protected CommandPanelCollection fHighlightedPanels;

		private bool fIsControlDown;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CommandLinePanel() {
			InitializeComponent();
			this.fIsControlDown = false;
			this.fPanels = new CommandPanelCollection();
			this.fHighlightedPanels = new CommandPanelCollection();
			this.Resize += new EventHandler(CommandLinePanel_Resize);
			
			for ( int i = 0; i < 30; i++ ) {
				CommandPanel p = new CommandPanel(this,i);
				this.Add(p);
			}
		}

		public void Add(CommandPanel p) {
			this.fPanels.Add(p);
			this.Controls.Add(p);
			this.UpdateMemberBounds();
		}

		private void UpdateMemberBounds() {
			int y = 0;
			foreach ( CommandPanel cp in this.fPanels ) {
				cp.SetBounds(
					0,
					y,
					this.Width-22,
					cp.Height);
				
				y += (cp.Height-1);
			}
		}

		public void AdviseMousePress(CommandPanel p) {
			if ( this.fIsControlDown ) {
				this.fHighlightedPanels.Add(p);
				p.Highlight(true);
			} else {
				foreach ( CommandPanel cp in this.fHighlightedPanels ) {
					cp.Highlight(false);
				}
				this.fHighlightedPanels.Clear();
				this.fHighlightedPanels.Add(p);
				p.Highlight(true);
			}
			Console.WriteLine("mmoney------------------");
			foreach ( CommandPanel cp in this.fHighlightedPanels ) {
				Console.WriteLine("number: "+cp.pX);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			this.KeyPressed(e.KeyCode);
		}

		protected override void OnKeyUp(KeyEventArgs e) {
			base.OnKeyUp(e);
			this.KeyReleased(e.KeyCode);
		}

		public void KeyPressed(Keys k) {
			Console.WriteLine("heree:"+k);
			if ( k == Keys.Delete ) {
				this.DeleteHighlighted();
			} else if ( k == Keys.Control ) {
				this.fIsControlDown = true;
			}
		}

		public void KeyReleased(Keys k) {
			if ( k == Keys.Control ) {
				this.fIsControlDown = false;
			}
		}

		private void DeleteHighlighted() {
            ArrayList a = new ArrayList();
			for ( int i = 0; i < this.fPanels.Count; i++ ) {
				if ( ((CommandPanel)this.fPanels[i]).pIsHighlighted ) {
					a.Add(i);
				}
			}
			int x;
			while ( a.Count > 0 ) {
				x = (int)a[a.Count-1];
				CommandPanel p = (CommandPanel)this.fPanels[x];
				this.fPanels.Remove(p);
				this.Controls.Remove(p);
				a.Remove(x);
				Console.WriteLine("removing:"+x);
			}
			this.UpdateMemberBounds();
			this.Invalidate();
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
			// CommandLinePanel
			// 
			this.AutoScroll = true;
			this.AutoScrollMargin = new System.Drawing.Size(10, 0);
			this.Name = "CommandLinePanel";

		}
		#endregion

		private void CommandLinePanel_Resize(object sender, EventArgs e) {
			this.UpdateMemberBounds();
		}
	}
}
