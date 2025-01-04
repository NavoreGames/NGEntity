using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

public class CommandColumnTemp : CommandTemp
{
    public Column Column { get; private set; }
    public CommandColumnTemp(Column column) { Column = column; }
}
