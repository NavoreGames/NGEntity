using System;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Interfaces;
using NGConnection.Models;
using System.Data.Common;
using NGEntity.Domain;
using Mysqlx.Expr;
using System.Collections;
using System.Collections.Generic;

namespace NGEntity;

public abstract class EntityJoin : CommandData
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }

    public bool SaveChanges(IConnection connection) => new CommandCommit(Identifier).SaveChanges(connection);
    public bool SaveChanges(string contextAlias) => new CommandCommit(Identifier).SaveChanges(contextAlias);
    public bool SaveChanges() => new CommandCommit(Identifier).SaveChanges();
}
public class EntityJoin<TSource1> : EntityJoin, IEntityJoin<TSource1>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }

    public IEntityJoin<TSource1, TEntityRight> InnerJoin<TEntityRight>(
            Expression<Func<TSource1, TEntityRight, bool>> expression)
                where TEntityRight : IEntity
    {
        return default;
    }

    public ICommandCommit Where(Expression<Func<TSource1, bool>> expression) =>
        new EntityWhere<TSource1>(Identifier).Where(expression);
    public IEntityInclude<TSource1, TProperty> Include<TProperty>(Expression<Func<TSource1, TProperty>> field) where TProperty : IEnumerable<IEntity> =>
        new EntityInclude<TSource1>(Identifier).Include(field);
}
public class EntityJoin<TSource1, TSource2> :
    EntityJoin, IEntityJoin<TSource1, TSource2>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }

    public IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityRight>
        (Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }

    public ICommandCommit Where(Expression<Func<TSource1, TSource2, bool>> expression) =>
       new EntityWhere<TSource1, TSource2>(Identifier).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }

    public IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
        Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public ICommandCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3>(Identifier).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }

    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public ICommandCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4>(Identifier).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public ICommandCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5>(Identifier).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public ICommandCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>(Identifier).Where(expression);
}
public class EntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> :
    EntityJoin, IEntityJoin<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
{
    internal EntityJoin(Guid Identifier) : base(Identifier) { }
    public IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityRight>(
        Expression<Func<TSource1, TEntityRight, bool>> expression)
            where TEntityRight : IEntity
    { return default; }
    public IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TEntityRight> InnerJoin<TEntityLeft, TEntityRight>(
       Expression<Func<TEntityLeft, TEntityRight, bool>> expression)
           where TEntityRight : IEntity
    { return default; }
    public ICommandCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression) =>
       new EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>(Identifier).Where(expression);
}
