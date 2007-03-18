using System;
using System.Drawing;
using System.Windows.Forms;

using Daple.Expressions.Functions;

namespace Daple.Expressions {

	/// <summary>
	/// Summary description for ExpressionAnalyzer.
	/// </summary>
	public class ExpressionAnalyzer : TreeView {

		private Expression fExpression;

		public ExpressionAnalyzer() {
			this.Font = new Font( "Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (byte)0 );
		}

		public Expression pExpression {
			set {
				this.fExpression = value;
				this.Analyze();
			}
		}

		private void Analyze() {
			this.Nodes.Clear();
			TreeNode root = new TreeNode("Expression Analysis:");
			this.Nodes.Add(root);
			this.AnalyzeExpression("Expression",this.fExpression,root);
			this.ExpandAll();
		}

		private void AnalyzeExpression(string title, Expression e, TreeNode n) {
			TreeNode root = new TreeNode(title+": "+e.ToString());

			foreach ( Quotient q in e.pPositiveQuotients ) {
				this.AnalyzeQuotient(q,root,true);
			}
			foreach ( Quotient q in e.pNegativeQuotients ) {
				this.AnalyzeQuotient(q,root,false);
			}
			foreach ( Variable v in e.pVariables ) {
				this.AnalyzeVariable(v,root);
			}

			n.Nodes.Add(root);
		}

		private void AnalyzeQuotient(Quotient q, TreeNode n, bool pos) {
			string s = "Positive ";
			if ( !pos ) {
				s = "Negative ";
			}
			TreeNode root = new TreeNode(s+"Quotient: "+q.ToString());

			foreach ( Function f in q.pMultipliedFunctions ) {
				this.AnalyzeFunction(f,root,true);
			}
			foreach ( Function f in q.pDividedFunctions ) {
				this.AnalyzeFunction(f,root,false);
			}
	
			n.Nodes.Add(root);
		}

		private void AnalyzeFunction(Function f, TreeNode n, bool mul) {
			string s = "Multiplied ";
			if ( !mul ) {
				s = "Divided ";
			}
			TreeNode root = new TreeNode(s+"Function: "+f.ToString());

			if ( f.pArgument != null ) {
				this.AnalyzeExpression("Argument",f.pArgument,root);
			}
			if ( f.pPower != null ) {
				this.AnalyzeExpression("Power",f.pPower,root);
			}

			n.Nodes.Add(root);
		}

		private void AnalyzeVariable(Variable v, TreeNode n) {
			TreeNode root = new TreeNode("Variable: "+v.ToString());
			n.Nodes.Add(root);
		}
	}
}
