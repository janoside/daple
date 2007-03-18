using System;

namespace Daple.Expressions {

	/// <summary>
	/// Summary description for IEvaluatable.
	/// </summary>
	public interface IEvaluatable {

		double Evaluate(VariableCollection vc);

		string Substitute(VariableCollection vc);
	}
}
