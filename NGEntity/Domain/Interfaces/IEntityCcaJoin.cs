using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
    public interface IEntityCcaJoin<TSource1> : 
        IEntityCcaWhere<TSource1>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2> : 
        IEntityCcaWhere<TSource1, TSource2>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityRight>
            (Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
            Expression<Func<TEntityLeft, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2, TSource3> : 
        IEntityCcaWhere<TSource1, TSource2, TSource3>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
            Expression<Func<TEntityLeft, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4> : 
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5> : 
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : 
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>, IEntityCcaCommit
    {
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityCcaJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : 
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>, IEntityCcaCommit
    {
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression) 
                where TEntityRight : IEntity;
        IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
}
