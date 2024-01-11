namespace NGEntity.Interface
{
	internal interface ICommandDml : ICommandBase
	{
		public ICommandWhere Where { get; set; }
	}
}
