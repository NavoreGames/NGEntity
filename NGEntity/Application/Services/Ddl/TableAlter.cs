using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableAlter : CommandData, ITableAlter
{
    internal TableAlter(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => new CommandCommit(Identifier).Execute(connection);
    public bool Execute(string contextAlias) => new CommandCommit(Identifier).Execute(contextAlias);
    public bool Execute() => new CommandCommit(Identifier).Execute();

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
