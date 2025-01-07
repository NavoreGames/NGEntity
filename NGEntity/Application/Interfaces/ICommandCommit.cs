using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface ICommandCommit
    {
        bool SaveChanges(IConnection connection);
        bool SaveChanges(string connectionAlias);
        bool SaveChanges();
    }
}
