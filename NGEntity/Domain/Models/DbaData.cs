﻿using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Models;

public abstract class DbaData
{
    internal Guid Identifier { get; set; }

    internal DbaData() { }
    internal DbaData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommands(Identifier).ToString());
    public string ToString(IConnection connection) { return default; }
    public string ToString(string connectionAlias) { return default; }

    public string ToObject() { return default; }
    public string ToObject(IConnection connection) { return default; }
    public string ToObject(string connectionAlias) { return default; }
}
