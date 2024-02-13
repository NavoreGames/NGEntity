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
    public class EntityDml<TSource> : EntityData, IEntityDml<TSource>, IEntityDmlStatic<TSource>
    {
        internal EntityDml(ContextDataNew contextData, IEntity entity) : base(contextData, entity) { }
        internal EntityDml(ContextDataNew contextData) : base(contextData) { }

        public IEntityCommit Insert() => Insert((TSource)this.Entity);

        public IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities)
        {
            ContextDataNew contextDataNew = ContextNew.GetContext(FirstEntity.GetType());

            //if (FirstEntity != null || (OtherEntities != null && OtherEntities.Length > 0))
            //{
            //	TConnectionAlias connectionAlias = new();
            //	//ContextData contextData = Context.GetConnection(connectionAlias);
            //	//List<ICommandBase> commands = new List<ICommandBase>();
            //	////// ADICINA PRIMEIRA ENTIDADE //////////////
            //	if (FirstEntity != null)
            //	{
            //		ICommandDml insert = null; // contextData.Dba.Insert(FirstEntity);
            //		if (insert != null)
            //			commands.Add(insert);
            //	}
            //	////// ADICIONA O RESTO DAS ENTIDADES //////////
            //	foreach (IEntity entity in OtherEntities)
            //	{
            //		if (entity != null)
            //		{
            //			ICommandDml insert = null; // contextData.Dba.Insert(FirstEntity);
            //			if (insert != null)
            //				commands.Add(insert);
            //		}
            //	}
            //	////// ADICIONA OS COMANDOS NO DICIONARIO /////////
            //	if (commands.Count > 0)
            //	{
            //		//CommandsData commandsData = new CommandsData(Enum.CommandType.Insert, commands);
            //		//contextData.Commands.Add(commandsData.Identifier, commandsData);

            //		//return new EntityCommit(commandsData, connectionAlias);
            //	}
            //}


            return default;
        }
    }
}
