
namespace Daple {

	/// <summary>
	/// Utility class for dealing with strings.
	/// </summary>
	public class StringUtil {

		public static int InstancesOf(string s, string test) {
		
			string str = s + "~~~~~";
			int instances = 0;
			int i = 0;
		
			while ( i < ( str.Length - test.Length ) ) {
			
				if ( str.Substring(i,test.Length).Equals(test) ) {
					instances++;
					i += test.Length;
				} else {
					i++;	
				}
			}
			return instances;
		}

		public static string Point(System.Drawing.Point p) {
			return "(" + p.X.ToString() + "," + p.Y.ToString() + ")";
		}

		public static bool Contains(string s, string test) {
			return ( StringUtil.InstancesOf(s,test) > 0 );
		}

		public static string Remove(string s, string toBeRemoved) {
			return StringUtil.Replace(s,toBeRemoved,"");	
		}

		public static string RemoveSpaces(string s) {
			return StringUtil.Replace(s," ","");
		}

		public static string ReplaceRange(string s, string replacement, int begin, int end) { 
			string str = "";
			str += s.Substring(0,begin);
			str += replacement;
			str += s.Substring(end);
			return str;
		}

		public static string RemoveRange(string s, int begin, int end) {
			return StringUtil.ReplaceRange(s,"",begin,end);	
		}

		public static int [] IndicesOf(string s, string subString) {
			int [] indices = new int[StringUtil.InstancesOf(s,subString)];
			int currentIndex = 0;
		
			for ( int i = 0; i < (s.Length - subString.Length + 1); i++ ) {
				if ( s.Substring(i,subString.Length).Equals(subString) ) {
					indices[currentIndex] = i;
					currentIndex++;	
				}
			}
			return indices;			
		}

		public static string Replace(string s, string toBeReplaced, string replacement) {
			if ( !StringUtil.Contains(s,toBeReplaced) ) {
				return s;	
			}
			if ( StringUtil.InstancesOf(s,toBeReplaced) == 1 ) {
				return StringUtil.ReplaceRange(s,replacement,s.IndexOf(toBeReplaced),
					s.IndexOf(toBeReplaced)+toBeReplaced.Length);
			}

			string str = "";
			int [] replaceIndices = new int[StringUtil.InstancesOf(s,toBeReplaced)];
			int currentIndex = 0;
			int count = 0;
			int endIndex;
			bool oneAhead = true;

			while ( currentIndex < s.Length ) {
				endIndex = StringUtil.CutTo(currentIndex+toBeReplaced.Length,s.Length-currentIndex);
				if ( s.Substring(currentIndex,toBeReplaced.Length/*endIndex-currentIndex*/).Equals(toBeReplaced) ) {
					replaceIndices[count] = currentIndex;
					currentIndex += toBeReplaced.Length;
					count++;
					oneAhead = false;
				} else {
					currentIndex ++;
					oneAhead = true;
				}
			}
		
			if ( oneAhead ) {
				currentIndex--;
			} else {
				currentIndex -= toBeReplaced.Length;
			}	
		
			if ( !s.StartsWith(toBeReplaced) ) {
				str += s.Substring(0,replaceIndices[0]);
			}

			str += replacement;
		
			for ( int i = 0; i < (count-1); i++ ) {
				string sss = s.Substring(replaceIndices[i]+toBeReplaced.Length/*+toBeReplaced.Length*/,replaceIndices[i+1]-replaceIndices[i]-1);
				str += sss;
				str += replacement;
			}
		
			if ( !s.Substring(currentIndex).Equals(toBeReplaced) ) {
				str += s.Substring(replaceIndices[count-1]+toBeReplaced.Length);
			}
			return str;
		}

		public static int CutTo(int i, int max) {
			if ( i < max ) {
				return i;
			} else {
				return max;
			}
		}

		/// <summary>
		/// Determines whether or not the specified index within the given string
		/// is between a pair of parentheses or not.
		/// </summary>
		/// <param name="s">The search string.</param>
		/// <param name="index">The index in the string.</param>
		/// <returns>The boolean result.</returns>
		public static bool InsideParentheses(string s, int index) {
			return StringUtil.InsidePairs(s,index,"(",")");
		}
	
		public static bool InsidePairs(string s, int index, string pair1, string pair2) {
			int openParens  = StringUtil.InstancesOf(s.Substring(0,index),pair1);
			int closeParens = StringUtil.InstancesOf(s.Substring(0,index),pair2);
		
			if ( openParens != closeParens ) {
				return true;
			} else {
				return false;
			}	
		}

		public static string Array(object [] o) {
			string s = "[";
			for ( int i = 0; i < o.Length; i++ ) {
				s += o[i].ToString();
			}
			s += "]";
			
			return s;
		}

		public static string Time(float milliseconds) {
			float seconds = milliseconds / 1000.0f;
			int min = (int)seconds / 60;
			seconds = seconds - min*60.0f;
			int hrs = (int)seconds / 60;
			seconds = seconds - hrs*60.0f;
			
			string s = "";
			if ( hrs.ToString().Length < 2 ) {
				s += "0";
			}
			s += hrs.ToString();
			s += ":";
			if ( min.ToString().Length < 2 ) {
				s += "0";
			}
			s += min.ToString();
			s += ":";
			string [] ss = seconds.ToString().Split('.');
			if ( ss[0].Length < 2 ) {
				s += "0";
			}
			s += ss[0];
			s += ".";
			//if ( ss[1].Length > 2 ) {
			//	ss[1] = ss[1].Substring(0,2);
			//}
			try {
				s += ss[1].Substring(0,2);
			} catch ( System.IndexOutOfRangeException ) {
			} catch ( System.ArgumentOutOfRangeException ) {
			}

			return s;
		}

		public static string Float(float f, int decimals) {
			string [] ss = f.ToString().Split('.');

			string s = ss[0] + ".";
			try {
				s += ss[1].Substring(0,decimals);
			} catch ( System.ArgumentOutOfRangeException ) {
				s += "0";
			} catch ( System.IndexOutOfRangeException ) {
				s += "0";
			}

			return s;
		}
	}
}
