
namespace Daple.Expressions {

	/// <summary>
	/// Extension of ArrayList for storage of Variables.
	/// </summary>
	public class VariableCollection : System.Collections.ArrayList {

		public VariableCollection(params Variable [] v) : base() {
			for ( int i = 0; i < v.Length; i++ ) {
				this.Add(v[i]);
			}
		}

		public override int Add(object o) {
			if ( !this.Contains(o) ) {
				return base.Add(o);
			}
			return -1;
		}

		public void AddAll(VariableCollection vc) {
			foreach ( Variable v in vc ) {
				this.Add(v);
			}
		}

		public override bool Equals(object obj) {
			if ( obj is VariableCollection ) {
				VariableCollection vc = (VariableCollection)obj;
				foreach ( Variable v in this ) {
					if ( !vc.Contains(v) ) {
						return false;
					}
				}
				foreach ( Variable v in vc ) {
					if ( !this.Contains(v) ) {
						return false;
					}
				}
			}
			return false;
		}

		public new Variable this[int x] {
			get {
				return (Variable)base[x];
			}
		}

		public Variable this[string s] {
			get {
				foreach ( Variable v in this ) {
					if ( v.pString.Equals(s) ) {
						return v;
					}
				}
				return null;
			}
		}
	}
}
