using System;
using NGEntity.Application.Interfaces;
using NGEntity.Interfaces;

namespace NGEntity.Application.Services
{
    internal class CommandDelete : CommandDml, ICommandDelete
    {
        public ICommandWhere CommandWhere { get; set; }

        public void SetValues(IEntity entity)
        {
            Table = GetTableName(entity);
        }
        public override ICommandDml SetCommand(Type connectionType)
        {
            Command = @$"DELETE FROM {Table}";

            return this;
        }
    }
}
