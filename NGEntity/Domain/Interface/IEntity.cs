using System.Collections.Generic;

namespace NGEntity.Interface
{
	public interface IEntity : IReturn
	{
		Enum.CommandType CommandObject { get; }
		Dictionary<string, Enum.CommandType> CommandFields { get; }
	}
}
