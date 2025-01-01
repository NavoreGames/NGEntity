using System.Linq.Expressions;
using System;

namespace NGEntity.Interfaces;

public interface IDataBaseDdl
{
    ITableCommand Create(string name);
    ITableCommand Alter(string name);
    IDataBaseCommit Drop(string name);
}
