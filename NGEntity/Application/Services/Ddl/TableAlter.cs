using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableAlter : CommandData, ITableAlter
{
    internal TableAlter(Guid Identifier) : base(Identifier) { }

    public bool SaveChanges(IConnection connection) => new CommandCommit(Identifier).SaveChanges(connection);
    public bool SaveChanges(string contextAlias) => new CommandCommit(Identifier).SaveChanges(contextAlias);
    public bool SaveChanges() => new CommandCommit(Identifier).SaveChanges();

    public IColumnAdd CreateTable(string name, string alias)
    {

        return default;
    }
    public IColumnAdd CreateTable(string name) => CreateTable(name, "");

    public ITableAlter AlterTable(string name) 
    {
        return default;
    }
}
