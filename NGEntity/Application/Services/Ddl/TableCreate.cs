using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableCreate : DataBaseData, ITableCreate
{
    internal TableCreate(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => new DbaCommit(Identifier).Execute(connection);
    public bool Execute(string contextAlias) => new DbaCommit(Identifier).Execute(contextAlias);
    public bool Execute() => new DbaCommit(Identifier).Execute();

    public IColumnAdd CreateTable(string name, string alias)
    {

        return default;
    }
    public IColumnAdd CreateTable(string name) => CreateTable(name, "");
}
