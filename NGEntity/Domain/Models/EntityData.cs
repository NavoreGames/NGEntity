using NGConnection.Interfaces;
using NGEntity.Interfaces;

namespace NGEntity.Models
{
    public abstract class EntityData
    {
        internal ContextDataNew ContextData { get; set; }
        internal IEntity Entity { get; set; }

        internal EntityData(ContextDataNew contextData, IEntity entity) { ContextData = contextData; Entity = entity; }
        internal EntityData(ContextDataNew contextData) { ContextData = contextData; Entity = null; }
    }
}
