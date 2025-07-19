namespace NGEntity;

public class CommandExecuteReader : CommandData, ICommandExecute
{
    internal CommandExecuteReader(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => Context.SaveChanges(Identifier, connection);
    public bool Execute(string contextAlias) => Context.SaveChanges(Identifier, contextAlias);
    public bool Execute() => Context.SaveChanges(Identifier);
}
