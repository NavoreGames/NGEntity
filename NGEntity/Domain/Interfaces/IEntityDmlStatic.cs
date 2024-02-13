using NGEntity.Models;
using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityDmlStatic<TSource> 
	{
        IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities);
    }
}
