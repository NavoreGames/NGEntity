﻿using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain.Interfaces
{
    public interface IEntityCommand<TSource>
    {
        //IEnumerable<object> Command(string query);
        //IEnumerable<TReturn> Command<TReturn>(string query) where TReturn : IReturn;
        //IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities);
    }
}