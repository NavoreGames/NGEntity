using System;
using System.Collections.Generic;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class Delete : CommandDml
	{
		internal Delete() { }
		internal Delete(IEntity entidy) : base(entidy) { }
	}
}
