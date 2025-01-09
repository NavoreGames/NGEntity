using NGConnection.Interfaces;
namespace NGEntity.Models;

internal class ContextData
{
    public string Alias { get; private set; }
    public IConnection Connection { get; internal set; }
    public List<Type> Types { get; private set; }
    public List<ICommand> Commands { get; internal set; }

    internal ContextData(string alias, IConnection connection, List<Type> types)
    {
        Alias = alias;
        Connection = connection;
        Types = types;
        Commands = [];
    }
}