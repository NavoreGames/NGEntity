using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IEntityDml<TSource> 
    where TSource : IEntity
{
    ICommandExecute Insert(TSource firstEntity, params TSource[] otherEntities);
    ICommandExecute Update(TSource entity);
    IEntityWhere<TSource> Updates(TSource entity);
    ICommandExecute Delete(TSource entity);
    IEntityWhere<TSource> Deletes();
}
