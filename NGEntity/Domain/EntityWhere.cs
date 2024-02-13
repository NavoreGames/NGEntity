using System;
using System.Linq;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity
{

    public class EntityWhere<TSource> : EntityData, IEntityWhere<TSource>
	{
        internal EntityWhere(ContextDataNew contextData, IEntity entity) : base(contextData, entity) { }
        internal EntityWhere(ContextDataNew contextData) : base(contextData) { }
        public IEntityCommit Where(string expression)
		{
			//if (Command != null)
			//{
			//	ContextData contextData = Context.GetConnection(ConnectionAlias);
			//	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			//}

			return new EntityCommit(ContextData);
		}
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression)
		{
			//if (Command != null)
			//{
			//	ContextData contextData = Context.GetConnection(ConnectionAlias);
			//	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			//}

			return new EntityCommit(ContextData);
		}

		///////// IMPLEMENTAÇÃO DAS HERANÇAS DA INTERFACE DO WHERE  /////////////////
		public bool Commit() => new EntityCommit(ContextData).Commit();
	}
}
