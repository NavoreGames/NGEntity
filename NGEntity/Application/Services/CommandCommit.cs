namespace NGEntity;

public class CommandCommit : CommandData, ICommandCommit
{
    internal CommandCommit(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => Context.SaveChanges(Identifier, connection);
    public bool Execute(string contextAlias) => Context.SaveChanges(Identifier, contextAlias);
    public bool Execute() => Context.SaveChanges(Identifier);
}
