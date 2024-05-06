using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityCcaWhere<TSource>
	{
		public IEntityCcaCommit Where(Expression<Func<TSource, bool>> expression);
	}
}
