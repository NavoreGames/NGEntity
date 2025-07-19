using NGConnection.Interfaces;

namespace NGEntity.Models;

public abstract class CommandData
{
    internal Guid Identifier { get; set; }

    internal CommandData() { }
    internal CommandData(Guid identifier) { Identifier = identifier; }

    public override string ToString() => CommandHandle.RaiseOnGetCommand(Identifier, null,null);
    public string ToString(IConnection connection) => CommandHandle.RaiseOnGetCommand(Identifier, null, connection);
    public string ToString(string contextAlias) => CommandHandle.RaiseOnGetCommand(Identifier, contextAlias, null);
}
