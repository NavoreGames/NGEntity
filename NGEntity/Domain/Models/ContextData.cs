using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Models
{
    internal class ContextData
    {
        public string Alias { get; private set; }
        public IConnection Connection { get; private set; }
        public List<Type> Types { get; private set; }
        public List<CommandDataTemp> CommandsData { get; internal set; }

        internal ContextData(string alias, IConnection connection, List<Type> types)
        {
            Alias = alias;
            Connection = connection;
            Types = types;
            CommandsData = [];
        }
    }
}