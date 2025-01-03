﻿using NGEntity.Application.Interfaces;
using System.Reflection;

namespace NGEntity.Application.Services;

internal class CommandInsert : CommandDml, ICommandInsert
{
    public string Fields { get; private set; }
    public string Values { get; private set; }
    public CommandInsert() { }
    public void SetValues(IEntity entity)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(entity);
        Fields = GetFields(propertyInfos);
        Values = GetValues(entity, propertyInfos);
        Table = GetTableName(entity);
    }

    public override ICommandDml SetCommand(Type connectionType) 
    {
        Command =
        @$"
		INSERT INTO {Table}
		({Fields})
		VALUES
		({Values})
        ";
        return this; 
    }  
}
