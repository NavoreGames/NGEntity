using Microsoft.Extensions.Primitives;
using Mysqlx.Crud;
using NGEntity.Application.Interfaces;
using NGEntity.Attributes;
using NGEntity.Enums;
using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
