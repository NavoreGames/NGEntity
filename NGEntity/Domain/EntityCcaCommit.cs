using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{
    public class EntityCcaCommit : EntityData, IEntityCcaCommit
	{
        internal EntityCcaCommit(ContextData contextData, IEntity entity) : base(contextData, entity) { }
        internal EntityCcaCommit(ContextData contextData) : base(contextData) { }

        public bool Execute() 
		{
			//if (Command != null)
			//{
			//	///// FAZER O COMMIT
			//}
			
			return true;
		}
	}
}
