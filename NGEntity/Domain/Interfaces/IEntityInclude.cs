using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Interfaces
{
    public interface IEntityInclude<TSource>
    {
        public IEntityInclude<TSource, TProperty> Include<TProperty>(Expression<Func<TSource, TProperty>> field);
    }
    public interface IEntityInclude<TSource, TPreviousProperty> : IEntityInclude<TSource>
    {
        public IEntityInclude<TSource, TProperty> ThenInclude<TEntity, TProperty>(Expression<Func<TPreviousProperty, TProperty>> field);
    }
}
