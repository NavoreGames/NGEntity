using NGConnection.Enums;
using NGConnection;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableCreate : DbaData, ITableCreate
{
    internal TableCreate(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => new DbaCommit(Identifier).Execute(connection);
    public bool Execute(string contextAlias) => new DbaCommit(Identifier).Execute(contextAlias);
    public bool Execute() => new DbaCommit(Identifier).Execute();

    public IColumnAdd CreateTable(string name, string alias)
    {
        CommandDataBaseTemp commandDataBase = 
            (CommandDataBaseTemp)Context.
                GetCommandData(Identifier)
                    .Where(w => w.Command is CommandDataBaseTemp)?
                    .FirstOrDefault()?
               .Command;
        CommandTableTemp commandTable = new CommandTableTemp(new Table(commandDataBase.DataBase.Name, name, alias));
        CommandDataTemp commandData = new CommandDataTemp(Identifier, DdlCommandType.Create, commandTable);
        Context.AddCommand(commandData);

        return new ColumnAdd(Identifier);
    }
    public IColumnAdd CreateTable(string name) => CreateTable(name, "");
}
