using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IEntityDml<TSource>
{
    IEntityCommit Inserts(TSource FirstEntity, params TSource[] OtherEntities);
    IEntityCommit Update(TSource entity);
    IEntityWhere<TSource> Update<TProperty>(Expression<Func<TSource, TProperty>> fields);
    IEntityCommit Delete(TSource entity);
    IEntityWhere<TSource> Delete();
}
