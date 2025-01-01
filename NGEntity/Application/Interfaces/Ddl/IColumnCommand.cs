using Mysqlx.Expr;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Interfaces
{
    public interface IColumnCommand : ITableCommand
    {
        public IColumnCommand AddColumn(string name, string alias, Key key, VariableType type, bool autoincrement);
        public IColumnCommand AddColumn(string name, string alias, Key key, VariableType type, int length, bool notNul);
        public IColumnCommand AddColumn(string name, string alias, Key key, VariableType type, int length);
        public IColumnCommand AddColumn(string name, string alias, Key key, VariableType type);

        public IColumnCommand AddColumn(string name, string alias, VariableType type, int length, bool notNul);
        public IColumnCommand AddColumn(string name, string alias, VariableType type, int length);
        public IColumnCommand AddColumn(string name, string alias, VariableType type);

        public IColumnCommand AddColumn(string name, Key key, VariableType type, bool autoincrement);
        public IColumnCommand AddColumn(string name, Key key, VariableType type, int length, bool notNul);
        public IColumnCommand AddColumn(string name, Key key, VariableType type, int length);
        public IColumnCommand AddColumn(string name, Key key, VariableType type);

        public IColumnCommand AddColumn(string name, VariableType type, int length, bool notNul);
        public IColumnCommand AddColumn(string name, VariableType type, int length);
        public IColumnCommand AddColumn(string name, VariableType type);
    }
}
