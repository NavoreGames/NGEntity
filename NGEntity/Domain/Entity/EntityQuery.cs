using System;
using System.Linq.Expressions;
using NGConnection.Interface;
using NGEntity.Domain;
using NGEntity.Interface;

namespace NGEntity
{
	public class EntityQuery<TSource> : EntityCommands, IEntityQuery<TSource>
	{
		internal EntityQuery() { }
		internal EntityQuery(CommandsData command, IConnectionAlias connectionAlias) : base(command, connectionAlias) { }

		public IEntityQuery<TSource> InnerJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityQuery<TSource> InnerJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityQuery<TSource> LeftJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityQuery<TSource> LeftJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityQuery<TSource> RightJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityQuery<TSource> RightJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}

		//public IEntityWhereCommit<TSource> OrderBy<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		//{
		//	return default;
		//}

		public IEntityCommit Where(string expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public bool Commit() => new EntityCommit(Command, ConnectionAlias).Commit();
	}
}
