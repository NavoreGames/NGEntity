using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Interfaces
{
    public interface IEntityIncludeStatic<TSource>
    {
        public IEntityIncludeStatic<TSource, TProperty> Include<TProperty>(Expression<Func<TSource, TProperty>> field);
    }
    public interface IEntityIncludeStatic<TSource, TPreviousProperty> : IEntityIncludeStatic<TSource>
    {
        public IEntityIncludeStatic<TSource, TProperty> ThenInclude<TEntity, TProperty>(Expression<Func<TPreviousProperty, TProperty>> field);
    }
}
