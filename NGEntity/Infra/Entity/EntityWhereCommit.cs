using System;
using System.Linq.Expressions;
using NGEntity.Interface;
using NGEntity.Domain;
using NGConnection.Interface;

namespace NGEntity
{
	public class EntityWhereCommit<TSource> : EntityCommands, IEntityWhereCommit<TSource>
	{
		internal EntityWhereCommit() { }
		internal EntityWhereCommit(CommandsData command, IConnectionAlias connectionAlias) : base(command, connectionAlias) { }

		public IEntityCommit Where(string expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public bool Commit() => new EntityCommit(Command, ConnectionAlias).Commit();
	}
}
