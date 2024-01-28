using System;
using System.Linq.Expressions;
using NGEntity.Interface;
using NGEntity.Domain;
using NGConnection.Interfaces;
using System.Linq;

namespace NGEntity
{

    public class EntityWhere<TSource> : EntityCommands, IEntityWhere<TSource>
	{
		internal EntityWhere() { }
		internal EntityWhere(CommandsData command, IConnectionAlias connectionAlias) : base(command, connectionAlias) { }
		public IEntityCommit Where(string expression)
		{
			if (Command != null)
			{
				ContextData contextData = Context.GetConnection(ConnectionAlias);
				Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			}

			return new EntityCommit(Command, ConnectionAlias);
		}
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression)
		{
			if (Command != null)
			{
				ContextData contextData = Context.GetConnection(ConnectionAlias);
				Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			}

			return new EntityCommit(Command, ConnectionAlias);
		}

		///////// IMPLEMENTAÇÃO DAS HERANÇAS DA INTERFACE DO WHERE  /////////////////
		public bool Commit() => new EntityCommit(Command, ConnectionAlias).Commit();
	}
}
