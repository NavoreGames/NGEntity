namespace NGEntity;

public class CommandCommit : CommandData, ICommandCommit
{
    internal CommandCommit(Guid Identifier) : base(Identifier) { }

    public bool SaveChanges(IConnection connection) => Context.SaveChanges(Identifier, connection);
    public bool SaveChanges(string contextAlias) => Context.SaveChanges(Identifier, contextAlias);
    public bool SaveChanges() => Context.SaveChanges(Identifier);
}
