using NGEntity.Models;
using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityCcaDml<TSource> 
	{
        IEntityCcaCommit Insert();
        IEntityCcaCommit Update();
        IEntityCcaCommit Delete();
    }
}
