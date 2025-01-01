using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableCommand : DataBaseData, ITableCommand
{
    internal TableCommand(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => new DataBaseCommit(Identifier).Execute(connection);
    public bool Execute(string contextAlias) => new DataBaseCommit(Identifier).Execute(contextAlias);
    public bool Execute() => new DataBaseCommit(Identifier).Execute();

    public IColumnCommand AddTable(string name, string alias)
    {

        return default;
    }
    public IColumnCommand AddTable(string name) => AddTable(name, "");
}
