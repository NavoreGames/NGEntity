using NGEntity.Interface;
using NGEntity.Models;

namespace NGEntity.Domain
{
	internal class CommandDdl : CommandBase, ICommandDdl
	{
		internal DataBase DataBase { get; private set; }
		internal CommandDdl() { }
		internal CommandDdl(DataBase dataBase) { DataBase = dataBase; }
	}
}