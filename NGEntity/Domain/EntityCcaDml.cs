using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity;

internal class EntityCcaDml : EntityData, IEntityCcaDmlStatic
{
    internal EntityCcaDml(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaDml(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Inserts(IEntity FirstEntity, params IEntity[] OtherEntities)
    { return default; }

    public IEntityCcaCommit Query(string query) { return default; }
}

internal class EntityCcaDml<TSource> : EntityData, IEntityCcaDml<TSource>, IEntityCcaDmlStatic<TSource>
{
    internal EntityCcaDml(IConnection connection, IEntity entity) : base(connection, entity) { }
    internal EntityCcaDml(IConnection connection) : base(connection) { }

    public IEntityCcaCommit Insert() => Inserts((TSource)this.Entity); 
    public IEntityCcaCommit Inserts(TSource FirstEntity, params TSource[] OtherEntities)
    {
        //    ContextData contextDataNew = Context.GetContext(FirstEntity.GetType());

        //    //if (FirstEntity != null || (OtherEntities != null && OtherEntities.Length > 0))
        //    //{
        //    //	TConnectionAlias connectionAlias = new();
        //    //	//ContextData contextData = Context.GetConnection(connectionAlias);
        //    //	//List<ICommandBase> commands = new List<ICommandBase>();
        //    //	////// ADICINA PRIMEIRA ENTIDADE //////////////
        //    //	if (FirstEntity != null)
        //    //	{
        //    //		ICommandDml insert = null; // contextData.Dba.Insert(FirstEntity);
        //    //		if (insert != null)
        //    //			commands.Add(insert);
        //    //	}
        //    //	////// ADICIONA O RESTO DAS ENTIDADES //////////
        //    //	foreach (IEntity entity in OtherEntities)
        //    //	{
        //    //		if (entity != null)
        //    //		{
        //    //			ICommandDml insert = null; // contextData.Dba.Insert(FirstEntity);
        //    //			if (insert != null)
        //    //				commands.Add(insert);
        //    //		}
        //    //	}
        //    //	////// ADICIONA OS COMANDOS NO DICIONARIO /////////
        //    //	if (commands.Count > 0)
        //    //	{
        //    //		//CommandsData commandsData = new CommandsData(Enum.CommandType.Insert, commands);
        //    //		//contextData.Commands.Add(commandsData.Identifier, commandsData);

        //    //		//return new EntityCommit(commandsData, connectionAlias);
        //    //	}
        //    //}


        return default;
    }
    public IEntityCcaCommit Update() { return default;  }
    public IEntityCcaWhere<TSource> Updates(TSource entity) { return default; }
    public IEntityCcaCommit Delete() { return default; }
    public IEntityCcaWhere<TSource> Deletes() { return default; }
    public IEntityCcaJoin<TSource> Selects() { return default;  }
    public IEntityCcaJoin<TSource> Selects(Expression<Func<TSource, object>> fields) { return default; }
}