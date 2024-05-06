using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityFcaWhere<TSource>
	{
		public void Where(Expression<Func<TSource, bool>> expression);
	}
}
