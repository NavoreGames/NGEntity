using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces;

public interface IEntityCcaDmlStatic
{
    IEntityCcaCommit Inserts(IEntity FirstEntity, params IEntity[] OtherEntities);
    IEntityCcaCommit Query(string query);
}
public interface IEntityCcaDmlStatic<TSource>
{
    IEntityCcaCommit Inserts(TSource FirstEntity, params TSource[] OtherEntities);
    IEntityCcaWhere<TSource> Updates(TSource entity);
    IEntityCcaWhere<TSource> Deletes();
    IEntityCcaJoin<TSource> Selects();
    IEntityCcaJoin<TSource> Selects(Expression<Func<TSource, object>> fields);
}
