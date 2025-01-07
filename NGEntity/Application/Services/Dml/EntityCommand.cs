using NGEntity.Models;

namespace NGEntity;

public class EntityCommand<TSource> : CommandData, IEntityCommand<TSource>
{
    //internal EntityCommand(ContextData contextData) : base(contextData) { }

    //public IEnumerable<object> Command(string query) 
    //{
    //    return default;
    //}
    //public IEnumerable<TReturn> Command<TReturn>(string query) where TReturn : IReturn
    //{
    //    return default;
    //}

    //public IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities) => 
    //    new EntityDml<TSource>(ContextData).Insert(FirstEntity, OtherEntities);
}
