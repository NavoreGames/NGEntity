using System;
using System.Linq;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{

    public class EntityFcaWhere<TSource> : EntityData, IEntityFcaWhere<TSource>
	{
        internal EntityFcaWhere(string[] connectionsAlias, IEntity entity) : base(connectionsAlias, entity) { }
        internal EntityFcaWhere(string[] connectionsAlias) : base(connectionsAlias) { }

        public void Where(Expression<Func<TSource, bool>> expression)
		{
			//if (Command != null)
			//{
			//	ContextData contextData = Context.GetConnection(ConnectionAlias);
			//	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			//}
		}
	}
}
