using System;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Interfaces;

namespace NGEntity
{
    public class EntityJoin<TSource> : EntityData, IEntityJoin<TSource>
	{
        internal EntityJoin(ContextDataNew contextData, IEntity entity) : base(contextData, entity) { }
        internal EntityJoin(ContextDataNew contextData) : base(contextData) { }

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
		public IEntityCommit Where(string expression) => new EntityWhere<TSource>(ContextData).Where(expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression) => new EntityWhere<TSource>(ContextData).Where(expression);
		public bool Commit() => new EntityCommit(ContextData).Commit();
	}
}
