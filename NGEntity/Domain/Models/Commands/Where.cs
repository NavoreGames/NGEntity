using System;
using System.Collections.Generic;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class Where : CommandBase, ICommandWhere
	{
		public List<string> Fields { get; set; }
		public List<string> Values { get; set; }
		public List<string> Clause { get; set; }

		public Where() { Fields = new List<string>(); Values = new List<string>(); Clause = new List<string>(); }
	}
}
