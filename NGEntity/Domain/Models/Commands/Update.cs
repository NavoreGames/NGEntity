using System;
using System.Collections.Generic;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class Update : CommandDml
	{
		internal List<string> Fields { get; set; }
		internal List<string> Values { get; set; }
		internal List<string> Set { get; set; }
		
		internal Update() { Fields = new List<string>(); Values = new List<string>(); Set = new List<string>(); Where = null;  }
		internal Update(IEntity entidy) : base(entidy) { }
	}
}
