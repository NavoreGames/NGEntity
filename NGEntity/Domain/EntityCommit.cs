using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{
    public class EntityCommit : EntityData, IEntityCommit
	{
        internal EntityCommit(ContextDataNew contextData, IEntity entity) : base(contextData, entity) { }
        internal EntityCommit(ContextDataNew contextData) : base(contextData) { }

        public bool Commit() 
		{
			//if (Command != null)
			//{
			//	///// FAZER O COMMIT
			//}
			
			return true;
		}
	}
}
