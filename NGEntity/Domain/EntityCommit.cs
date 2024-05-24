using NGConnection.Interfaces;
using NGEntity.Exceptions;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;

namespace NGEntity
{
    public class EntityCommit : EntityData, IEntityCommit
	{
        internal EntityCommit(CommandData commandData) : base(commandData) { }

        public IEntity Execute(IConnection connection) 
        {
            Context.DeleteCommand(CommandData.Identifier);

            return default; 
        }
		public IEntity Execute(string contextAlias) 
        {
            if(!Context.ContextExists(contextAlias))
                throw new ContextNotExists($"Context with alias {contextAlias} not exists");

            Context.DeleteCommand(CommandData.Identifier);

            return default; 
        }
        public IEntity Execute() 
        {

            return default; 
        }
    }
}
