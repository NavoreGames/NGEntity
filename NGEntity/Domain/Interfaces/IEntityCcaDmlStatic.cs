using NGEntity.Models;
using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityCcaDmlStatic<TSource>
	{
        IEntityCcaCommit Inserts(TSource FirstEntity, params TSource[] OtherEntities);
        IEntityCcaWhere<TSource> Updates(TSource entity);
        IEntityCcaWhere<TSource> Deletes();
    }
}
