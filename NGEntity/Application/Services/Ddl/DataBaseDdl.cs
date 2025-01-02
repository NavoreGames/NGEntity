using NGEntity.Models;

namespace NGEntity;

internal class DataBaseDdl : DataBaseData, IDataBaseDdl
{
    internal DataBaseDdl() { }

    public ITableCreate CreateDataBase(string name)
    {
        //DataBase dataBase

        return default;
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