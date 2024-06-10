using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IEntityDml<TSource>
{
    IEntityCommit Insert(TSource firstEntity, params TSource[] otherEntities);
    IEntityCommit Update(TSource entity);
    IEntityWhere<TSource> Updates(TSource entity);
    IEntityCommit Delete(TSource entity);
    IEntityWhere<TSource> Deletes();
}
