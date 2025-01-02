using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IDataBaseDdl
{
    ITableCreate CreateDataBase(string name);
    //ITableAlter AlterDataBase(string name);
    //IDbaCommit DropDataBase(string name);
}
