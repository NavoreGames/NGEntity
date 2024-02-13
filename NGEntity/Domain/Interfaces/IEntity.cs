using System.Collections.Generic;
using Enum = NGEntity.Enums;

namespace NGEntity.Interfaces
{
	public interface IEntity : IReturn
	{
		Enum.CommandType CommandObject { get; }
		Dictionary<string, Enum.CommandType> CommandFields { get; }
	}
}
