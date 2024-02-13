namespace NGEntity.Application.Interfaces
{
    internal interface ICommandDml : ICommandBase
    {
        public ICommandWhere Where { get; set; }
    }
}
