using NGConnection.Interfaces;
using NGEntity.Domain.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain
{
    public class EntityCommand<TSource> : EntityData, IEntityCommand<TSource>
    {
        internal EntityCommand(ContextDataNew contextData) : base(contextData) { }

        public IEnumerable<object> Command(string query) 
        {
            return default;
        }
        public IEnumerable<TReturn> Command<TReturn>(string query) where TReturn : IReturn
        {
            return default;
        }

        public IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities) => 
            new EntityDml<TSource>(ContextData).Insert(FirstEntity, OtherEntities);
    }
}
