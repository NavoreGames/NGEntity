using System;
using System.Collections.Generic;
using NGEntity.Application.Interfaces;
using NGEntity.Enums;

namespace NGEntity.Models
{
	internal class CommandData
    {
		internal Guid Identifier { get; private set; }
		internal CommandType CommandType { get; private set; }
		internal List<ICommandBase> Command { get; private set; }

		internal CommandData(CommandType commandType, List<ICommandBase> command) { Identifier = Guid.NewGuid(); CommandType = commandType; Command = command; }
		//public override string ToString() => Command.GetCommand();
		internal CommandData Copy() => new CommandData(this.CommandType, this.Command);
	}
}
