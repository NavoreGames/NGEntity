using Mysqlx.Expr;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Interfaces
{
    public interface ITableAlter : ITableCreate
    {
        ITableAlter AlterTable(string name);
    }
}
