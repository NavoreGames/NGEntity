using System;
using System.Linq;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Exceptions;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity;

public abstract class EntityWhere : EntityData
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntity Execute(IConnection connection) => new EntityCommit(CommandData).Execute(connection);
    public IEntity Execute(string contextAlias) => new EntityCommit(CommandData).Execute(contextAlias);
    public IEntity Execute() => new EntityCommit(CommandData).Execute();
}
public class EntityWhere<TSource1> :
    EntityWhere, IEntityWhere<TSource1>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2> : 
    EntityWhere, IEntityWhere<TSource1, TSource2>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8>
{
    internal EntityWhere(CommandData commandData) : base(commandData) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(CommandData);
    }
}
