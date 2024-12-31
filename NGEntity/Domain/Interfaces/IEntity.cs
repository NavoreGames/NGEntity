using NGConnection.Enums;

namespace NGEntity.Interfaces
{
    public interface IEntity : IReturn
    {
        DmlCommandType CommandObject { get; }
		Dictionary<string, DmlCommandType> CommandFields { get; }
	}
}
