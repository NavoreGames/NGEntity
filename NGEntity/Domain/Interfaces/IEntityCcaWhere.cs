using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces;

public interface IEntityCcaWhere<TSource> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression);
}
public interface IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : IEntityCcaCommit
{
    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression);
}
