using System;
using System.Collections.Generic;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class Select : CommandDml
	{
		public List<string> Fields { get; set; }
		public List<string> Values { get; set; }
		public List<string> Set { get; set; }

		public Select() { Fields = new List<string>(); Values = new List<string>(); Set = new List<string>(); }
	}
}
