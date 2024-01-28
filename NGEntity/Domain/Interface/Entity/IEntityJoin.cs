using System;
using System.Linq.Expressions;

namespace NGEntity.Interface
{
    public interface IEntityJoin<TSource> : IEntityWhere<TSource>
    {
        public IEntityJoin<TSource> InnerJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity;
    }
}
