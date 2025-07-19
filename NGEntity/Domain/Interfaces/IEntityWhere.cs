using System;
using System.Linq.Expressions;

namespace NGEntity.Interfaces;

public interface IEntityWhere<TSource1> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression);
}
public interface IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : ICommandExecute
{
    public ICommandExecute Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression);
}
