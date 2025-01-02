using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class ColumnAdd : TableCreate, IColumnAdd
{
    internal ColumnAdd(Guid Identifier) : base(Identifier) { }

    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, bool autoincrement)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length, bool notNul)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type)
    {
        return default;
    }

    public IColumnAdd AddColumn(string name, string alias, VariableType type, int length, bool notNul)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, string alias, VariableType type, int length)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, string alias, VariableType type)
    {
        return default;
    }

    public IColumnAdd AddColumn(string name, Key key, VariableType type, bool autoincrement)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, Key key, VariableType type, int length, bool notNul)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, Key key, VariableType type, int length)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, Key key, VariableType type)
    {
        return default;
    }

    public IColumnAdd AddColumn(string name, VariableType type, int length, bool notNul)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, VariableType type, int length)
    {
        return default;
    }
    public IColumnAdd AddColumn(string name, VariableType type)
    {
        return default;
    }
}
