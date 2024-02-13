using NGEntity.Enums;

namespace NGEntity.Models
{
    public class Column
    {
		#region PROPERTY
		public string ColumnName { get; private set; }
		public CommandType CommandType { get; private set; }
		public VariableType Type { get; private set; }
		public int Length { get; private set; }
		public bool NotNull { get; private set; }
		public bool Autoincrement { get; private set; }
		public Key Key { get; private set; }
		public string AlterColumnName { get; private set; }
		#endregion

		private Column(string columnName, CommandType commandType, VariableType type, int length, bool notNull, bool autoincrement, Key key, string alterColumnName)
		{
			ColumnName = columnName;
			CommandType = commandType;
			Type = type;
			Length = length;
			NotNull = notNull;
			Autoincrement = autoincrement;
			Key = key;
			AlterColumnName = alterColumnName;
		}

		public Column(string columnName, CommandType commandType, VariableType type, bool autoincrement, Key key) : 
			this(columnName, commandType, type, 0, true, autoincrement, key, ""){ }
		public Column(string columnName, CommandType commandType, VariableType type, Key key) :
			this(columnName, commandType, type, 0, true, false, key, ""){ }
		public Column(string columnName, CommandType commandType, VariableType type, int length, Key key) :
			this(columnName, commandType, type, length, true, false, key, ""){ }
		public Column(string columnName, CommandType commandType, VariableType type, int length, bool notNull) :
			this(columnName, commandType, type, length, notNull, false, Key.None, ""){ }
		/// <summary>
		/// SOBRECARGA PARA ALTERAR O NOME DA TABELA.
		/// </summary>
		public Column(string columnName, string alterColumnName) :
			this(columnName, CommandType.Alter, VariableType.None, 0, false, false, Key.None, alterColumnName){ }
	}
}
