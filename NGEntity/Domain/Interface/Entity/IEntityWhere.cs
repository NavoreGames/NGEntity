﻿using System;
using System.Linq.Expressions;

namespace NGEntity.Interface
{
	public interface IEntityWhere<TSource>
	{
		public IEntityCommit Where(string expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression);
	}
}