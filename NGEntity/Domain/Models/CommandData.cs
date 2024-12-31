using NGConnection.Enums;
using NGEntity.Application.Interfaces;

namespace NGEntity.Models
{
	internal class CommandData
	{
		internal Guid Identifier { get; set; }
        internal DmlCommandType DmlCommandType { get; set; }
        internal Type ConnectionType { get; set; }
        internal ICommandDml Command { get; set; }

        internal CommandData() { }
        internal CommandData(DmlCommandType dmlCommandType, ICommandDml command) 
        { 
            Identifier = Guid.NewGuid();
            DmlCommandType = dmlCommandType;
            Command = command;
        }

        public CommandData SetCommand(Type connectionType) 
        { 
            return new()
            {
                Identifier = this.Identifier,
                DmlCommandType = this.DmlCommandType,
                ConnectionType = connectionType,
                Command = this.Command.SetCommand(connectionType)
            };
        }

        public override string ToString() => Command.ToString();
    }
}
