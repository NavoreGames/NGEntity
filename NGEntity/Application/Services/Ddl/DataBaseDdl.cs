using NGEntity.Models;

namespace NGEntity;

internal class DataBaseDdl : DataBaseData, IDataBaseDdl
{
    internal DataBaseDdl() { }

    public ITableCommand Create(string name)
    {
        //DataBase dataBase

        return default;
    }
    public ITableCommand Alter(string name)
    {
        //DataBase dataBase

        return default;
    }
    public IDataBaseCommit Drop(string name)
    {


        return default;
    }
}