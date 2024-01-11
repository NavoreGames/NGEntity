using System;
using System.Collections.Generic;
using NGConnection.Enum;
using NGEntity.Enum;
using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal class CommandsData
	{
		internal Guid Identifier { get; private set; }
		internal CommandType CommandType { get; private set; }
		internal List<ICommandBase> Command { get; private set; }

		internal CommandsData(CommandType commandType, List<ICommandBase> command) { Identifier = Guid.NewGuid(); CommandType = commandType; Command = command; }
		//public override string ToString() => Command.GetCommand();
		internal CommandsData Copy() => new CommandsData(this.CommandType, this.Command);
	}
}
