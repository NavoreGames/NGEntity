using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain
{
    internal class EntityFcaDml<TSource> : EntityData
    {
        internal EntityFcaDml(string[] connectionsAlias, IEntity entity) : base(connectionsAlias, entity) { }
        internal EntityFcaDml(string[] connectionsAlias) : base(connectionsAlias) { }

        public void Insert() => Inserts((TSource)this.Entity);
        public void Inserts(TSource FirstEntity, params TSource[] OtherEntities)
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
        }
        public void Update() => Updates((TSource)this.Entity);
        public IEntityFcaWhere<TSource> Updates(TSource entity) 
        {
            //	if (entity != null)
            //	{
            //		//TConnectionAlias connectionAlias = new TConnectionAlias();
            //		//ContextData contextData = Context.GetConnection(connectionAlias);
            //		//ICommandDml update = contextData.Dba.Update(entity);
            //		//if (update != null)
            //		//{
            //		//	update.Where = contextData.Dba.Where(entity);
            //		//	CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { update });
            //		//	contextData.Commands.Add(commandsData.Identifier, commandsData);

            //		//	return new EntityWhere<TSource>(commandsData, connectionAlias);
            //		//}
            //	}

            //	return new EntityWhere<TSource>();
            return default;  
        }
        public void Delete() { }
        public IEntityFcaWhere<TSource> Deletes() 
        {
            //	//TConnectionAlias connectionAlias = new TConnectionAlias();
            //	//ContextData contextData = Context.GetConnection(connectionAlias);
            //	//entity = (entity == null) ? new TSource() : entity;
            //	//ICommandDml delete = contextData.Dba.Delete(entity);
            //	//if (delete != null)
            //	//{
            //	//	delete.Where = contextData.Dba.Where(entity);
            //	//	CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { delete });
            //	//	contextData.Commands.Add(commandsData.Identifier, commandsData);

            //	//	return new EntityWhere<TSource>(commandsData, connectionAlias);
            //	//}

            //	return new EntityWhere<TSource>();
            return default; 
        }
    }
}
