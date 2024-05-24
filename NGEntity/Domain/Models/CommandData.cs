using System;
using System.Collections.Generic;
using System.Linq;
using NGEntity.Application.Interfaces;
using NGEntity.Enums;
using NGEntity.Interfaces;

namespace NGEntity.Models
{
	internal class CommandData
	{
		internal Guid Identifier { get; private set; }
        internal CommandType CommandType { get; private set; }
        internal IEntity Entity { get; private set; }
        internal ICommandDml Command { get; private set; }

        internal CommandData(CommandType commandType, IEntity entity, ICommandDml command) 
        { 
            Identifier = Guid.NewGuid();
            CommandType = commandType;
            Entity = entity;
            Command = command;
        }

        //public override string ToString() => Command.GetCommand();
        //internal CommandData Copy() => new CommandData(this.CommandType, this.Command);
    }
}
