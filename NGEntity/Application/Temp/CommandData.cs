using NGConnection.Interfaces;

namespace NGConnection.Models
{
	public class CommandDataTemp
	{
		public Guid Identifier { get; protected set; }
        public Enums.CommandType CommandType { get; protected set; }
        public ICommandTemp Command { get; set; }

        internal CommandDataTemp() { }
        public CommandDataTemp(Guid identifier, Enums.CommandType commandType, ICommandTemp command)
        {
            Identifier = identifier;
            CommandType = commandType;
            Command = command;
        }
        public CommandDataTemp(Enums.CommandType commandType, ICommandTemp command) 
        { 
            Identifier = Guid.NewGuid();
            CommandType = commandType;
            Command = command;
        }

        //public CommandDataTemp SetCommand(Type connectionType)
        //{
        //    return new()
        //    {
        //        Identifier = this.Identifier,
        //        CommandType = this.CommandType,
        //        ConnectionType = connectionType,
        //        Command = this.Command.SetCommand(connectionType)
        //    };
        //}

        public override string ToString() => Command.ToString();
    }
}
