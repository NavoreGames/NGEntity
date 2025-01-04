using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface IDbaCommit : IDbaData
    {
        bool Execute(IConnection connection);
        bool Execute(string connectionAlias);
        bool Execute();
    }
}
