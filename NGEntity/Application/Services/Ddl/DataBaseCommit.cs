using NGConnection.Interfaces;

namespace NGEntity;

public class DataBaseCommit : DataBaseData, IDataBaseCommit
{
    internal DataBaseCommit(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection)
    {
        //Context.DeleteCommand(Identifier);

        return default;
    }
    public bool Execute(string contextAlias)
    {
        //if (!Context.ContextExists(contextAlias))
        //    throw new ContextNotExists($"Context with alias {contextAlias} not exists");

        //Context.DeleteCommand(Identifier);

        return default;
    }
    public bool Execute()
    {

        return default;
    }
}
