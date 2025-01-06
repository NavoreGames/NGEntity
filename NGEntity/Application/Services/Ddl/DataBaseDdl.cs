namespace NGEntity;

internal class DataBaseDdl : DbaData, IDataBaseDdl
{
    internal DataBaseDdl() { }

    public ITableCreate CreateDataBase(string name)
    {
        DataBase dataBase = new DataBase(name);
        CommandData commandData = new CommandData(DdlCommandType.Create, dataBase);
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