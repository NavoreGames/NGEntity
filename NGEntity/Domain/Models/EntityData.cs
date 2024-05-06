using NGConnection.Interfaces;
using NGEntity.Interfaces;

namespace NGEntity.Models
{
    public abstract class EntityData
    {
        private readonly string[] _connectionsAlias;
        private readonly IConnection _connection;
        private readonly IEntity _entity;
        internal ContextData ContextData { get; set; }
        internal IEntity Entity { get; set; }

        internal EntityData(ContextData contextData, IEntity entity) { ContextData = contextData; Entity = entity; }
        internal EntityData(ContextData contextData) { ContextData = contextData; Entity = null; }

        private EntityData(string[] connectionsAlias, IEntity entity, IConnection connection) 
        { 
            _connectionsAlias = connectionsAlias; 
            _entity = entity;
            _connection = connection;
        }
        internal EntityData(string[] connectionsAlias, IEntity entity) : this(connectionsAlias, entity, null) { }
        internal EntityData(string[] connectionsAlias) : this(connectionsAlias, null, null) { }
        internal EntityData(IConnection connection, IEntity entity) : this(null, entity, connection) { }
        internal EntityData(IConnection connection) : this(null, null, connection) { }

    }
}
