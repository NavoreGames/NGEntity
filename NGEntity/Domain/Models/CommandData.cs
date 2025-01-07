using NGConnection.Interfaces;

namespace NGEntity.Models;

public abstract class CommandData
{
    internal Guid Identifier { get; set; }

    internal CommandData() { }
    internal CommandData(Guid identifier) { Identifier = identifier; }

    public override string ToString() => Context.GetQuery(Identifier);
    public string ToString(IConnection connection) => Context.GetQuery(Identifier, connection);
    public string ToString(string connectionAlias) => Context.GetQuery(Identifier, connectionAlias);
}
