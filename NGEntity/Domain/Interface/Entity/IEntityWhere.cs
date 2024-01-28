﻿using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
	public interface IEntityWhere<TSource> : IEntityCommit
	{
		public IEntityCommit Where(string expression);
		public IEntityCommit Where(Expression<Func<TSource, bool>> expression);
	}
}
