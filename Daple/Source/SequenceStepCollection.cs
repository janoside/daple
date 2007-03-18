using System;
using System.Collections;

namespace Daple.Animation {

	/// <summary>
	/// Summary description for SequenceStepCollection.
	/// </summary>
	public class SequenceStepCollection : ArrayList {

		public new SequenceStep this[int x] {
			get {
				return (SequenceStep)base[x];
			}
		}
	}
}
