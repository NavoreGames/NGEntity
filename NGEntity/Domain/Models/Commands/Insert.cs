using System.Collections.Generic;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class Insert : CommandDml
	{
		internal List<string> Fields { get; set; }
		internal List<string> Values { get; set; }

		internal Insert() { Fields = new List<string>(); Values = new List<string>(); }
		internal Insert(IEntity entidy) : base(entidy) { }
	}
}
