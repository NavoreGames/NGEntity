using NGEntity.Models;
using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityFcaDml<TSource>
	{
        //IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities);
        //IEntityWhere<TSource> Update(TSource entity);
    }
}
