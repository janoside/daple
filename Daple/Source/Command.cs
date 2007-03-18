
namespace Daple.Commands {

	/// <summary>
	/// Summary description for Command.
	/// </summary>
	public abstract class Command {

		public Command(string s) {
		}

		public abstract object Return();
	}
}
