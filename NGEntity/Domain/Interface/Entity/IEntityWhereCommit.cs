﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Interfaces
{
	public interface IEntityWhereCommit<TSource> : IEntityWhere<TSource>, IEntityCommit
	{

	}
}
