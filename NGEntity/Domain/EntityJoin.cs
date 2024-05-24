using System;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Interfaces;
using NGConnection.Models;
using System.Data.Common;
using NGEntity.Domain;

namespace NGEntity;

public abstract class EntityJoin : EntityData
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }

    public IEntity Execute(IConnection connection) => new EntityCommit(CommandData).Execute(connection);
    public IEntity Execute(string contextAlias) => new EntityCommit(CommandData).Execute(contextAlias);
    public IEntity Execute() => new EntityCommit(CommandData).Execute();
}
public class EntityJoin<TSource1> : EntityJoin, IEntityJoin<TSource1>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }

    public IEntityJoin<TSource1, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity
    {
        return default;
    }

    public IEntityCommit Where(Expression<Func<TSource1, bool>> expression) =>
        new EntityWhere<TSource1>(CommandData).Where(expression);
    public IEntityInclude<TSource1, TProperty> Include<TProperty>(Expression<Func<TSource1, TProperty>> field) =>
        new EntityInclude<TSource1>(CommandData).Include(field);
}
public class EntityJoin<TSource1, TSource2> :
    EntityJoin, IEntityJoin<TSource1, TSource2>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }

    public IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityRight>
        (Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, bool>> expression) =>
       new EntityWhere<TSource1, TSource2>(CommandData).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }

    public IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3>(CommandData).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }

    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4>(CommandData).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5>(CommandData).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>(CommandData).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
{
    internal EntityJoin(CommandData commandData) : base(commandData) { }
    public IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>(CommandData).Where(expression);
}
