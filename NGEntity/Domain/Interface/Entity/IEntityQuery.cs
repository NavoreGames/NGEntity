using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityQuery<TSource>
	{
		public IEntityQuery<TSource> InnerJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity;

		public IEntityCommit Where(string expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression);
		public bool Commit();
	}
}
