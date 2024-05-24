using NGEnum;

namespace NGEntity.Enums
{
	public sealed class CommandType : NGEnums<CommandType>
	{
		public static readonly CommandType Get = new ("Get");
		public static readonly CommandType Post = new ("Post");
		public static readonly CommandType Put = new ("Put");
		public static readonly CommandType Delete = new ("Delete");
		public static readonly CommandType Drop = new ("Drop");
		public static readonly CommandType Select = new ("Select");
		public static readonly CommandType Update = new ("Update");
		public static readonly CommandType Insert = new ("Insert");
		public static readonly CommandType Alter = new ("Alter");
		public static readonly CommandType Where = new ("Where");

		public CommandType() : base(None) { }
		public CommandType(object pObject) : base(pObject) { }
		public CommandType(int pId, object pObject) : base(pId, pObject) { }

	}
}
