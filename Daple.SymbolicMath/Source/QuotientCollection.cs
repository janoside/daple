
namespace Daple.Expressions {

	/// <summary>
	/// Extension of ArrayList for storage of Quotients.
	/// </summary>
	public class QuotientCollection : System.Collections.ArrayList {

		public new Quotient this[int x] {
			get {
				return (Quotient)base[x];
			}
		}
	}
}
