using NGConnection.Enums;
using NGConnection;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableCreate : CommandData, ITableCreate
{
    internal TableCreate(Guid Identifier) : base(Identifier) { }

    public bool SaveChanges(IConnection connection) => new CommandCommit(Identifier).SaveChanges(connection);
    public bool SaveChanges(string contextAlias) => new CommandCommit(Identifier).SaveChanges(contextAlias);
    public bool SaveChanges() => new CommandCommit(Identifier).SaveChanges();

    public IColumnAdd CreateTable(string name, string alias)
    {
        DataBase dataBase =
            (DataBase)Context.
                GetCommands(Identifier)
                    .Where(w => w is DataBase)?
                    .FirstOrDefault();

        Table table = new Table(Identifier, DdlCommandType.Create, dataBase, name, alias);
        Context.AddCommand(table);

        return new ColumnAdd(Identifier);
    }
    public IColumnAdd CreateTable(string name) => CreateTable(name, "");
}
