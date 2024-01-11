using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal abstract class CommandBase : ICommandBase
	{
		internal string Command { get; set; }
		internal CommandBase() { }
		internal new virtual string ToString() => Command;
	}
}
