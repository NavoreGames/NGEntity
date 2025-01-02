using NGEntity.Domain;
using System.Linq.Expressions;

namespace NGEntity;

public static class Dba
{
    public static ITableCreate CreateDataBase(string name) =>
        new DataBaseDdl().CreateDataBase(name);
    //public static ITableAlter AlterDataBase(string name) =>
    //    new DataBaseDdl().AlterDataBase(name);
    //public static IDbaCommit DropDataBase(string name) =>
    //    new DataBaseDdl().DropDataBase(name);
}
