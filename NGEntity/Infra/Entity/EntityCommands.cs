using NGConnection.Interface;
using NGEntity.Domain;

namespace NGEntity
{
	public abstract class EntityCommands
	{
		internal CommandsData Command { get; set; }
		internal IConnectionAlias ConnectionAlias { get; set; }

		internal EntityCommands() { Command = null; ConnectionAlias = null; }
		internal EntityCommands(CommandsData command, IConnectionAlias connectionAlias) { Command = command; ConnectionAlias = connectionAlias;  }
	}
}
