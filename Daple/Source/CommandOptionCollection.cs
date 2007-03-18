
namespace Daple.Commands {

	/// <summary>
	/// Extension of ArrayList for storage of CommandOptions.
	/// </summary>
	public class CommandOptionCollection : System.Collections.ArrayList {

		public new CommandOption this[int x] {
			get {
				return (CommandOption)base[x];
			}
		}
	}
}
