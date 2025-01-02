using Mysqlx.Expr;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Interfaces
{
    public interface ITableCreate : IDbaCommit
    {
        IColumnAdd CreateTable(string name, string alias);
        IColumnAdd CreateTable(string name);
    }
}
