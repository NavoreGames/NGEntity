using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface IDbaCommit : IDataBaseData
    {
        bool Execute(IConnection connection);
        bool Execute(string connectionAlias);
        bool Execute();
    }
}
