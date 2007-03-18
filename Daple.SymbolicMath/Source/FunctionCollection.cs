
using Daple.Expressions.Functions;

namespace Daple.Expressions {

	/// <summary>
	/// Extension of ArrayList for storage of Functions.
	/// </summary>
	public class FunctionCollection : System.Collections.ArrayList {

		public new Function this[int x] {
			get {
				return (Function)base[x];
			}
		}
	}
}
