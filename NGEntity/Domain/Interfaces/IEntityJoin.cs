using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces
{
    public interface IEntityJoin<TSource1> :
        //IEntityInclude<TSource1>, 
        IEntityWhere<TSource1>, ICommandExecute
    {
        IEntityJoin<TSource1, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2> :
        IEntityWhere<TSource1, TSource2>, ICommandExecute
    {
        IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityRight>
            (Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
            Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2, TSource3> :
        IEntityWhere<TSource1, TSource2, TSource3>, ICommandExecute
    {
        IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
            Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2, TSource3, TSource4> :
        IEntityWhere<TSource1, TSource2, TSource3, TSource4>, ICommandExecute
    {
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5> :
        IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5>, ICommandExecute
    {
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> :
        IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>, ICommandExecute
    {
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
    public interface IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> :
        IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>, ICommandExecute
    {
        IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity;
        IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
           Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
               where TEntityRight : IEntity;
    }
}
