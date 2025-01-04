using NGConnection;
using NGConnection.Interfaces;

namespace NGEntity;

public class DbaCommit : DbaData, IDbaCommit
{
    internal DbaCommit(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection)
    {

        return default;
    }
    public bool Execute(string contextAlias)
    {

        return default;
    }
    public bool Execute()
    {
        var v = Context.GetCommandData(Identifier);

        return default;
    }
}
