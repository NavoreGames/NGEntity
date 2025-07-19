using Mysqlx.Expr;
using NGConnection.Interfaces;

namespace NGEntity.Interfaces
{
	public interface ICommandExecute
    {
        string ToString(IConnection connection);
        string ToString(string contextAlias);
        string ToString();

        bool Execute(IConnection connection);
        bool Execute();
    }
}
