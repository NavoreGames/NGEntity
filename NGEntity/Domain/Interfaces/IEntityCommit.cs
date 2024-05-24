using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface IEntityCommit
	{
        IEntity Execute(IConnection connection);
        IEntity Execute(string connectionAlias);
        IEntity Execute();
    }
}
