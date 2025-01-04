using NGConnection.Enums;

namespace NGEntity.Interfaces
{
    public interface IEntity : IReturn
    {
        CommandType CommandObject { get; }
		Dictionary<string, CommandType> CommandFields { get; }
	}
}
