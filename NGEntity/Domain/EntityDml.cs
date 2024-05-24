using NGConnection.Interfaces;
using NGEntity.Application.Interfaces;
using NGEntity.Application.Services;
using NGEntity.Enums;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain
{
    internal class EntityDml<TSource> : EntityData, IEntityDml<TSource>
    {
        internal EntityDml() { }

        public IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities)
        {
            ////// UNE AS ENTIDADES EM UMA LISTA ///////
            List<TSource> sources = new(OtherEntities);
            sources.Insert(0,FirstEntity);
            ///// CRIA O OBJETO COM AS INFORMAÇÕES DO COMANDO /////////
            CommandData commandData = null;
            CommandInsert commandInsert = new();
            Type type = null;
            foreach (TSource source in sources.OrderBy(o=> o.GetType()))
            {
                if (!typeof(TSource).Equals(type))
                {
                    type = typeof(TSource);
                    commandInsert.SetValues((IEntity)source);
                    commandData = new(CommandType.Insert, (IEntity)source, commandInsert);
                }
                else
                    commandInsert.SetValues((IEntity)source);
            }
            ////// ADICIONAR O COMANDO NO CONTEXTO ///////////
            Context.AddCommand(type, commandData);

            return new EntityCommit(commandData);
        }
        public IEntityCommit Update(TSource entity) 
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
        public IEntityWhere<TSource> Updates(TSource entity)
        {
            return default;
        }
        public IEntityCommit Delete(TSource entity)
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
        public IEntityWhere<TSource> Deletes()
        {
            return default;
        }
        public IEntityJoin<TSource> Selects() { return default; }
        public IEntityWhere<TSource> Selects<TProperty>(Expression<Func<TSource, TProperty>> fields) { return default; }
    }
}