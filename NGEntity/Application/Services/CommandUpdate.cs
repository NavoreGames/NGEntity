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
    internal class CommandUpdate : CommandDml, ICommandUpdate
    {
        public List<string> Fields { get; set; }
        public List<string> Values { get; set; }
        public List<string> Set {  get; set; }
        public ICommandWhere CommandWhere { get; set; }
        public void SetValues(IEntity entity)
        {
            IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(entity);
            Fields = [.. GetFields(propertyInfos).Split(',')];
            Values = [.. GetValues(entity, propertyInfos).Split(',')];
            Set = Fields.Zip(Values, (fields, values) => $"{fields}={values}" ).ToList();
            Table = GetTableName(entity);
        }
        public override ICommandDml SetCommand(Type connectionType)
        {
            Command = @$"UPDATE {Table} SET {String.Join(',', Set)}";

            return this;
        }
    }
}
