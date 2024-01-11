using NGEntity.Interface;

namespace NGEntity.Domain
{
	internal abstract class CommandDml : CommandBase, ICommandDml
	{
		internal IEntity Entity { get; private set; }
		internal string TableName { get; set; }
		public ICommandWhere Where { get; set; }
		internal CommandDml() { }
		internal CommandDml(IEntity entity) { Entity = entity; }
	}
}
