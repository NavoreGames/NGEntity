using System.Collections.Generic;
using System.ComponentModel;

namespace NGEntity.Interface
{
	public interface IEntity : IReturn
	{
		Enum.CommandType CommandObject { get; }
		Dictionary<string, Enum.CommandType> CommandFields { get; }
	}
}
