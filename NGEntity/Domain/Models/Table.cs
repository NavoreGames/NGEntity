using System;
using System.Collections.Generic;
using NGEntity.Enums;

namespace NGEntity.Models
{
	public class Table
	{
		public string TableName { get; private set; }
		public CommandType CommandType { get; private set; }
		public List<Column> Columns { get; private set; }
		public string AlterTableName { get; private set; }

		private Table(string tableName, CommandType commandType, List<Column> columns, string alterTableName)
		{
			TableName = tableName;
			CommandType = commandType;
			Columns = columns ??= [];
			AlterTableName = alterTableName;
		}
		public Table(string tableName, CommandType commandType, List<Column> columns = null) : this(tableName, commandType, columns, ""){ }
		public Table(string tableName, string alterTableName) : this(tableName, CommandType.Alter, null, alterTableName) { }
	}
}
