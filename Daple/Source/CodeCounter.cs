using System;
using System.IO;

namespace Daple {

	/// <summary>
	/// Summary description for CodeCounter.
	/// </summary>
	public class CodeCounter {
		
		public static int LineCount(string directory, out int csFiles) {
			System.Console.WriteLine("directory="+directory);
			int lines = 0;
			csFiles = 0;
			System.IO.StreamReader reader;
			string [] files = System.IO.Directory.GetFiles(directory);
			for ( int i = 0; i < files.Length; i++ ) {
				if ( files[i].EndsWith(".java") ) {
					csFiles++;
					reader = System.IO.File.OpenText(files[i]);
					while ( reader.ReadLine() != null ) {
						lines++;
					}
				}
			}

			return lines;
		}
	}
}
