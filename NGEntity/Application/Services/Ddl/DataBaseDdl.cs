namespace NGEntity;

internal class DataBaseDdl : DbaData, IDataBaseDdl
{
    internal DataBaseDdl() { }

    public ITableCreate CreateDataBase(string name)
    {
        DataBase dataBase = new DataBase(DdlCommandType.Create, name);
        Context.AddCommand(dataBase);

        return new TableCreate(dataBase.Identifier);
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