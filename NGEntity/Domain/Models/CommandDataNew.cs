using System;
using System.Collections.Generic;
using NGEntity.Application.Interfaces;
using NGEntity.Enums;

namespace NGEntity.Models
{
	internal class CommandDataNew
    {
		internal Guid Identifier { get; private set; }
		internal CommandType CommandType { get; private set; }
		internal List<ICommandBase> Command { get; private set; }

		internal CommandDataNew(CommandType commandType, List<ICommandBase> command) { Identifier = Guid.NewGuid(); CommandType = commandType; Command = command; }
		//public override string ToString() => Command.GetCommand();
		internal CommandDataNew Copy() => new CommandDataNew(this.CommandType, this.Command);
	}
}
