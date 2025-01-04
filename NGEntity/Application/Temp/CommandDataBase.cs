using NGConnection.Models;

namespace NGConnection;

public class CommandDataBaseTemp : CommandTemp
{
    public DataBase DataBase { get; private set; }
    public CommandDataBaseTemp(DataBase dataBase) { DataBase = dataBase; }
}
