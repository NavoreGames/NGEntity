using Mysqlx.Expr;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Interfaces
{
    public interface ITableCommand : IDataBaseCommit
    {
        IColumnCommand AddTable(string name, string alias);
        IColumnCommand AddTable(string name);
    }
}
