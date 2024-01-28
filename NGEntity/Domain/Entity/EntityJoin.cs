using System;
using System.Linq.Expressions;
using NGConnection.Interface;
using NGEntity.Domain;
using NGEntity.Interface;

namespace NGEntity
{
	public class EntityJoin<TSource> : EntityCommands, IEntityJoin<TSource>
	{
		internal EntityJoin() { }
		internal EntityJoin(CommandsData command, IConnectionAlias connectionAlias) : base(command, connectionAlias) { }

		public IEntityJoin<TSource> InnerJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityJoin<TSource> InnerJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityJoin<TSource> LeftJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityJoin<TSource> LeftJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityJoin<TSource> RightJoin<TEntityRight>(Expression<Func<TSource, TEntityRight, bool>> expression) where TEntityRight : IEntity
		{
			return default;
		}
		public IEntityJoin<TSource> RightJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity
		{
			return default;
		}

		///////// IMPLEMENTAÇÃO DAS HERANÇAS DA INTERFACE DO JOIN  /////////////////
		public IEntityCommit Where(string expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression) => new EntityWhere<TSource>(Command, ConnectionAlias).Where(expression);
		public bool Commit() => new EntityCommit(Command, ConnectionAlias).Commit();
	}
}
