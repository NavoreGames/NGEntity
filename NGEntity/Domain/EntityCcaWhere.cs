using System;
using System.Linq;
using System.Linq.Expressions;
using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;

namespace NGEntity;

public abstract class EntityCcaWhere : EntityData
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public bool Execute() => new EntityCcaCommit(_connection, _entity).Execute();
}
public class EntityCcaWhere<TSource1> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1>
	{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, bool>> expression)
		{
			//if (Command != null)
			//{
			//	ContextData contextData = Context.GetConnection(ConnectionAlias);
			//	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
			//}

			return new EntityCcaCommit(_connection);
		}
	}
public class EntityCcaWhere<TSource1, TSource2> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3, TSource4> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
public class EntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : 
    EntityCcaWhere, IEntityCcaWhere<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8>
{
    internal EntityCcaWhere(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaWhere(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Where(Expression<Func<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, bool>> expression)
    {
        //if (Command != null)
        //{
        //	ContextData contextData = Context.GetConnection(ConnectionAlias);
        //	Command.Command.ToList().ForEach(f => { ((ICommandDml)f).Where = contextData.Dba.Where(expression); });
        //}

        return new EntityCcaCommit(_connection);
    }
}
