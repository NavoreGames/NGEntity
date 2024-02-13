using NGEntity.Enums;
using System.Linq.Expressions;

namespace NGEntity
{
	internal static class Generic
	{
		public static VariableType GetVariableType(string pValue)
		{
			switch(pValue)
            {
				case "smallint":
					return VariableType.Smallint;
				case "integer":
				case "int":
					return VariableType.Int;
				case "bigint":
				case "int64":
					return VariableType.Bigint;
				case "string":
				case "varchar":
					return VariableType.String;
				case "decimal":
				case "real":
				case "float":
					return VariableType.Decimal;
				case "boolean":
				case "bool":
				case "tinyint":
					return VariableType.Bool;
				case "datetime":
					return VariableType.DateTime;
				default:
					return VariableType.None;
			}
		}
		internal static string GetOperation(ExpressionType value)
		{
			switch(value)
            {
				case ExpressionType.OrElse:
					return " OR ";
				case ExpressionType.AndAlso:
					return " AND ";
				case ExpressionType.Equal:
					return " = ";
				case ExpressionType.NotEqual:
					return " <> ";
				default: 
					return "";
            }
		}
	}
}
