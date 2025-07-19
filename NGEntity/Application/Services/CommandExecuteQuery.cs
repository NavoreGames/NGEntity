namespace NGEntity;

public class CommandExecuteQuery : CommandData, ICommandExecute
{
    internal CommandExecuteQuery(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => Context.SaveChanges(Identifier, connection);
    public bool Execute() => Context.SaveChanges(Identifier);
}
