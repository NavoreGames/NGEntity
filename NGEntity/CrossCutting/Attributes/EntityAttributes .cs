using System;
using System.Linq.Expressions;
using NGEntity.Enums;
using NGEntity.Interfaces;

namespace NGEntity.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class Primarykey : Attribute
{
	public Primarykey(string firstField, params string[] otherFields) { }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Foreignkey : Attribute
{
    public Foreignkey(string firstField, params string[] otherFields) { }
}
