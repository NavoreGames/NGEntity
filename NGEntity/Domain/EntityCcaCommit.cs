using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{
    public class EntityCcaCommit : EntityData, IEntityCcaCommit
	{
        internal EntityCcaCommit(IConnection connection, IEntity entity) : base(connection, entity) { }
        internal EntityCcaCommit(IConnection connection) : base(connection) { }

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
