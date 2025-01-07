using NGConnection;
using NGConnection.Interfaces;

namespace NGEntity;

public class CommandCommit : CommandData, ICommandCommit
{
    internal CommandCommit(Guid Identifier) : base(Identifier) { }

    public bool SaveChanges(IConnection connection)
    {

        return default;
    }
    public bool SaveChanges(string contextAlias)
    {
        if (!Context.ContextExists(contextAlias))
            throw new ContextNotExists($"Context with alias {contextAlias} not exists");

        ContextData contextData = Context.GetContext(contextAlias);
        //contextData.Connection

        return default;
    }
    public bool SaveChanges()
    {
        var v = Context.GetCommands(Identifier);

        return default;
    }
}
