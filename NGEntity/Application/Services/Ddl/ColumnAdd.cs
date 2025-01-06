using NGConnection;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;
using System.Xml.Linq;
namespace NGEntity;

public class ColumnAdd : TableCreate, IColumnAdd
{
    internal ColumnAdd(Guid Identifier) : base(Identifier) { }

    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length, bool notNull, bool autoincrement)
    {
        Table table =
            (Table)Context.
                GetCommandData(Identifier)
                    .Where(w => w.Command is Table)?
                    .LastOrDefault()?
               .Command;
        Column column = new Column(table, name, alias, key, type, length, notNull, autoincrement);
        CommandData commandData = new CommandData(Identifier, DdlActionType.Add, column);
        Context.AddCommand(commandData);

        return new ColumnAdd(Identifier);
    }
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, bool autoincrement) =>
        AddColumn(name, alias, key, type, 0, autoincrement, autoincrement);
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length, bool notNul) =>
        AddColumn(name, alias, key, type, length, notNul, false);
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type, int length) =>
        AddColumn(name, alias, key, type, length, false, false);
    public IColumnAdd AddColumn(string name, string alias, Key key, VariableType type) =>
        AddColumn(name, alias, key, type, 0, false, false);

    public IColumnAdd AddColumn(string name, string alias, VariableType type, int length, bool notNul) =>
         AddColumn(name, alias, Key.None, type, length, notNul, false);
    public IColumnAdd AddColumn(string name, string alias, VariableType type, int length) =>
        AddColumn(name, alias, Key.None, type, length, false, false);
    public IColumnAdd AddColumn(string name, string alias, VariableType type) =>
        AddColumn(name, alias, Key.None, type, 0, false, false);
    public IColumnAdd AddColumn(string name, Key key, VariableType type, bool autoincrement) =>
        AddColumn(name, "", key, type, 0, autoincrement, autoincrement);
    public IColumnAdd AddColumn(string name, Key key, VariableType type, int length, bool notNul) =>
        AddColumn(name, "", key, type, length, notNul, false);
    public IColumnAdd AddColumn(string name, Key key, VariableType type, int length) =>
        AddColumn(name, "", key, type, length, false, false);
    public IColumnAdd AddColumn(string name, Key key, VariableType type) =>
        AddColumn(name, "", key, type, 0, false, false);

    public IColumnAdd AddColumn(string name, VariableType type, int length, bool notNul) =>
        AddColumn(name, "", Key.None, type, length, notNul, false);
    public IColumnAdd AddColumn(string name, VariableType type, int length) =>
        AddColumn(name, "", Key.None, type, length, false, false);
    public IColumnAdd AddColumn(string name, VariableType type) =>
        AddColumn(name, "", Key.None, type, 0, false, false);
}
