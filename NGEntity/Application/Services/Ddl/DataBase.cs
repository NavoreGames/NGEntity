using NGEntity.Domain;
using System.Linq.Expressions;
namespace NGEntity;

public static class DataBase
{
    public static ITableCommand Create(string name) =>
        new DataBaseDdl().Create(name);
    public static ITableCommand Alter(string name) =>
        new DataBaseDdl().Alter(name);
    public static IDataBaseCommit Drop(string name) =>
        new DataBaseDdl().Drop(name);
}
