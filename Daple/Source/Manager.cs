using Daple.Animation;
using Daple.Animation.Testing;

using Daple.Plotting.TwoD;

namespace Daple {

	/// <summary>
	/// Summary description for Manager.
	/// </summary>
	public class Manager {

		public static Manager Instance;

		public static System.Drawing.Font Font = new System.Drawing.Font("Courier New",9);

		public static void Initialize() {
			Manager.Instance = new Manager();
		}

		private MainForm fMainForm;

	//	private AnimationManager fAnimationManager;

///		private ExpressionAnalysisForm fExpressionAnalysisForm;

		public Manager() {
			this.fMainForm = new MainForm();
	//		this.fAnimationManager = new AnimationManager();
	//		this.fExpressionAnalysisForm = new ExpressionAnalysisForm();
		}

		public void ShowAnalysis(string s) {
	//		this.fExpressionAnalysisForm.SetExpression(s);
	//		this.fExpressionAnalysisForm.Show();
		}

		public void PostConstruction() {
			//this.fMainForm.pGraphPanel2d.Add(new FunctionPlotterAnimation(this.fMainForm.pGraphPanel2d,this.fAnimationManager,new Expressions.Expression("sin(time*x"),this.fMainForm.pGraphPanel2d.pCartesianPlane));
		}

		public MainForm pMainForm {
			get {
				return this.fMainForm;
			}
		}

	//	public AnimationManager pAnimationManager {
	//		get {
	//			return this.fAnimationManager;
	//		}
	//	}
	}
}
