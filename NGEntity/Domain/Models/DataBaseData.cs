using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Models;

public abstract class DataBaseData
{
    internal Guid Identifier { get; set; }
    internal DataBase DataBase { get; set; }

    internal DataBaseData() { }
    internal DataBaseData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommandData(Identifier).Select(s=> s.Command.ToString()).Where(w=> w != null && w != ""));
    public string ToString(IConnection connection) { return default; }
    public string ToString(string connectionAlias) { return default; }

    public string ToObject() { return default; }
    public string ToObject(IConnection connection) { return default; }
    public string ToObject(string connectionAlias) { return default; }
}
