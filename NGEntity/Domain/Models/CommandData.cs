using NGConnection.Interfaces;

namespace NGEntity.Models;

public abstract class CommandData
{
    internal Guid Identifier { get; set; }

    internal CommandData() { }
    internal CommandData(Guid identifier) { Identifier = identifier; }

    public override string ToString() =>
        String.Join(';', Context.GetCommands(Identifier).ToString());
    public string ToString(IConnection connection) { return default; }
    public string ToString(string connectionAlias) { return default; }
}
