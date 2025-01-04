using NGConnection;
using NGConnection.Enums;
using NGConnection.Models;

namespace NGEntity;

internal class DataBaseDdl : DbaData, IDataBaseDdl
{
    internal DataBaseDdl() { }

    public ITableCreate CreateDataBase(string name)
    {
        CommandDataBaseTemp commandDataBase = new CommandDataBaseTemp(new DataBase(name));
        CommandDataTemp commandData = new CommandDataTemp(DdlCommandType.Create, commandDataBase);
        Context.AddCommand(commandData);

        return new TableCreate(commandData.Identifier);
    }
    //public ITableAlter AlterDataBase(string name)
    //{
    //    //DataBase dataBase

    //    return default;
    //}
    //public IDbaCommit DropDataBase(string name)
    //{


    //    return default;
    //}
}