using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IEntityDml<TSource>
{
    ICommandCommit Insert(TSource firstEntity, params TSource[] otherEntities);
    ICommandCommit Update(TSource entity);
    IEntityWhere<TSource> Updates(TSource entity);
    ICommandCommit Delete(TSource entity);
    IEntityWhere<TSource> Deletes();
}
