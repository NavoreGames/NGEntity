using NGEntity.Interface;
using NGEntity.Domain;
using NGConnection.Interface;

namespace NGEntity
{
	public class EntityCommit : EntityCommands, IEntityCommit
	{
		internal EntityCommit() { }
		internal EntityCommit(CommandsData command, IConnectionAlias connectionAlias) : base(command, connectionAlias) { }

		public bool Commit() 
		{
			if (Command != null)
			{
				///// FAZER O COMMIT
			}
			
			return true;
		}
	}
}
