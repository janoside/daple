using System;
using System.Windows.Forms;

namespace Daple {

	/// <summary>
	/// Summary description for MainClass.
	/// </summary>
	public class MainClass {

		[STAThread]
		static void Main () {

			Manager.Initialize();
			Manager.Instance.PostConstruction();

			Application.EnableVisualStyles();
			Application.Run(Manager.Instance.pMainForm);
		//	Manager.Instance.pMainForm.Show();

		//	Application.Run(new Form1());

			// create a log for debugging
			/*DebugLog.CreateLog("DebugLog.txt");

			Manager.Initialize();
			Manager.Instance.PostConstruction();

			Manager.Instance.pMainForm.Show();

			if ( Manager.Instance.pMainForm.Created ) {
				Manager.Instance.pMainForm.SplashIntro();
			}

			Manager.Instance.GameLoop();
			Manager.Instance.CloseEngine();*/
		}
	}
}
