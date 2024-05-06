using System;
using System.Collections.Generic;
using NGEntity.Application.Interfaces;
using NGEntity.Enums;

namespace NGEntity.Models
{
	internal class CommandsData_Bkp
	{
		internal Guid Identifier { get; private set; }
		internal CommandType CommandType { get; private set; }
		internal List<ICommandBase> Command { get; private set; }

		internal CommandsData_Bkp(CommandType commandType, List<ICommandBase> command) { Identifier = Guid.NewGuid(); CommandType = commandType; Command = command; }
		//public override string ToString() => Command.GetCommand();
		internal CommandsData_Bkp Copy() => new CommandsData_Bkp(this.CommandType, this.Command);
	}
}
