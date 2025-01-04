using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

public class CommandTableTemp : CommandTemp
{
    public Table Table { get; private set; }
    public CommandTableTemp(Table table) { Table = table; }
}
