using NGEntity.Models;
using System.Linq.Expressions;

namespace NGEntity.Interface
{
	internal interface IDba
	{
		public ICommandDml Insert(IEntity entity);
		public ICommandDml Update(IEntity entity);
		public ICommandDml Delete(IEntity entity);
		//ICommands Select(Expression expression);
		public ICommandWhere Where(IEntity entity);
		public ICommandWhere Where(string expression);
		public ICommandWhere Where(Expression expression);
		public ICommandDdl Alter(DataBase dataBase);
	}
}
