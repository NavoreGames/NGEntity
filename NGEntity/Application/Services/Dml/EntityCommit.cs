﻿using NGConnection.Interfaces;
using NGEntity.Exceptions;
using NGEntity.Models;

namespace NGEntity
{
    public class EntityCommit : EntityData, IEntityCommit
	{
        internal EntityCommit(Guid Identifier) : base(Identifier) { }

        public IEntity Execute(IConnection connection) 
        {
            Context.DeleteCommand(Identifier);

            return default; 
        }
		public IEntity Execute(string contextAlias) 
        {
            if(!Context.ContextExists(contextAlias))
                throw new ContextNotExists($"Context with alias {contextAlias} not exists");

            Context.DeleteCommand(Identifier);

            return default; 
        }
        public IEntity Execute() 
        {

            return default; 
        }
    }
}
