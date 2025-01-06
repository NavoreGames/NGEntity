using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NGEntity.Application.Interfaces;
using NGEntity.Interfaces;

namespace NGConnection;

public class Update : Command
{
    public string[] Fields { get; set; }
    public string[] Values { get; set; }
    public string[] Set {  get; set; }
    //public Where Where { get; set; }
    public override void SetValues(object entity)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(entity);
        Fields = GetFields(propertyInfos);
        Values = GetValues(entity, propertyInfos);
        Set = GetFields(propertyInfos).Zip(Values, (fields, values) => $"{fields}={values}" ).ToArray();
        Name = GetTableName(entity);
    }
    //public override ICommandDml SetCommand(Type connectionType)
    //{
    //    Command = @$"UPDATE {Table} SET {String.Join(',', Set)}";

    //    return this;
    //}
}
