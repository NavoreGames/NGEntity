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
		internal Guid Identifier { get; set; }
        internal CommandType CommandType { get; set; }
        internal Type ConnectionType { get; set; }
        internal ICommandDml Command { get; set; }

        internal CommandData() { }
        internal CommandData(CommandType commandType, ICommandDml command) 
        { 
            Identifier = Guid.NewGuid();
            CommandType = commandType;
            Command = command;
        }

        public CommandData SetCommand(Type connectionType) 
        { 
            return new()
            {
                Identifier = this.Identifier,
                CommandType = this.CommandType,
                ConnectionType = connectionType,
                Command = this.Command.SetCommand(connectionType)
            };
        }

        public override string ToString() => Command.ToString();
    }
}
