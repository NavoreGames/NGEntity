using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface IDataBaseCommit
    {
        bool Execute(IConnection connection);
        bool Execute(string connectionAlias);
        bool Execute();
    }
}
