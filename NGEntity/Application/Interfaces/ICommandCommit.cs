using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface ICommandCommit
    {
        bool Execute(IConnection connection);
        bool Execute(string connectionAlias);
        bool Execute();
    }
}
