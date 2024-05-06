using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
    public interface IEntityJoin<TSource> //: IEntityFcaWhere<TSource>
    {
        //public IEntityJoin<TSource> InnerJoin<TEntityLeft, TEntityRight>(Expression<Func<TEntityLeft, TEntityRight, bool>> expression) where TEntityLeft : IEntity where TEntityRight : IEntity;
    }
}
