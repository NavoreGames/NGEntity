using NGEnum;

namespace NGEntity.Enum
{
	public sealed class CommandType : NGEnums<CommandType>
	{
		public static readonly CommandType Get = new CommandType("Get");
		public static readonly CommandType Post = new CommandType("Post");
		public static readonly CommandType Put = new CommandType("Put");
		public static readonly CommandType Delete = new CommandType("Delete");
		public static readonly CommandType Drop = new CommandType("Drop");
		public static readonly CommandType Select = new CommandType("Select");
		public static readonly CommandType Update = new CommandType("Update");
		public static readonly CommandType Insert = new CommandType("Insert");
		public static readonly CommandType Alter = new CommandType("Alter");
		public static readonly CommandType Where = new CommandType("Where");

		public CommandType() : base(None) { }
		public CommandType(object pObject) : base(pObject) { }
		public CommandType(int pId, object pObject) : base(pId, pObject) { }

	}
}
