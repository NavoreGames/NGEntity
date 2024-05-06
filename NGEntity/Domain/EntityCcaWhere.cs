using System;
using System.Linq;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{

    public class EntityCcaWhere<TSource> : EntityData, IEntityCcaWhere<TSource>
	{
        internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
        internal EntityCcaWhere(IConnection connection) : base(connection) { }

        public IEntityCcaCommit Where(Expression<Func<TSource, bool>> expression)
		{
			//if (Command != null)
			//{
			//	ContextData contextData = Context.GetConnection(ConnectionAlias);
			//	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			//}

			return new EntityCcaCommit(ContextData);
		}
	}
}
