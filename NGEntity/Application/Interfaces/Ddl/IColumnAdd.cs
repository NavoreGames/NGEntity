using Mysqlx.Expr;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGEntity.Interfaces
{
    public interface IColumnAdd : ITableCreate
    {
        public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, bool autoincrement);
        public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length, bool notNul);
        public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length);
        public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type);

        public IColumnAdd AddColumn(string name, string alias, VariableType type, int length, bool notNul);
        public IColumnAdd AddColumn(string name, string alias, VariableType type, int length);
        public IColumnAdd AddColumn(string name, string alias, VariableType type);

        public IColumnAdd AddColumn(string name, Key key, VariableType type, bool autoincrement);
        public IColumnAdd AddColumn(string name, Key key, VariableType type, int length, bool notNul);
        public IColumnAdd AddColumn(string name, Key key, VariableType type, int length);
        public IColumnAdd AddColumn(string name, Key key, VariableType type);

        public IColumnAdd AddColumn(string name, VariableType type, int length, bool notNul);
        public IColumnAdd AddColumn(string name, VariableType type, int length);
        public IColumnAdd AddColumn(string name, VariableType type);
    }
}
