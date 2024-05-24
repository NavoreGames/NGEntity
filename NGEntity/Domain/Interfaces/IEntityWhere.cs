using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces;

public interface IEntityWhere<TSource> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : IEntityCommit
{
    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression);
}
