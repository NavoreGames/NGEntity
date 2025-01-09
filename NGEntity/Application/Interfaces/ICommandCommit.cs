using Mysqlx.Expr;
using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface ICommandCommit
    {
        string ToString(IConnection connection);
        string ToString(string connectionAlias);
        string ToString();

        bool Execute(IConnection connection);
        bool Execute(string connectionAlias);
        bool Execute();
    }
}
