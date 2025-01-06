﻿using NGConnection.Interfaces;

namespace NGEntity;

public abstract class EntityWhere : EntityData
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntity Execute(IConnection connection) => new EntityCommit(Identifier).Execute(connection);
    public IEntity Execute(string contextAlias) => new EntityCommit(Identifier).Execute(contextAlias);
    public IEntity Execute() => new EntityCommit(Identifier).Execute();
}
public class EntityWhere<TSource1> :
    EntityWhere, IEntityWhere<TSource1>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, bool>> expression)
    {
        Where Where = new();
        Where.SetValues(expression);

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2> : 
    EntityWhere, IEntityWhere<TSource1, TSource2>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
public class EntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : 
    EntityWhere, IEntityWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8>
{
    internal EntityWhere(Guid Identifier) : base(Identifier) { }

    public IEntityCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCommit(Identifier);
    }
}
