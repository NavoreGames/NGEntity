using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel;
using PropertyChanged;
using NGConnection.Interfaces;
using Enum = NGEntity.Enums;
using NGEntity.Interfaces;
using NGEntity.Models;
using NGEntity.Domain;
using NGEntity.Domain.Interfaces;
//using NGEntity.Application.Interfaces;

namespace NGEntity
{
    //public abstract class Entity<TSource> where TSource : Entity<TSource>, new()
    [AddINotifyPropertyChangedInterface]
	public abstract class Entity<TSource> where TSource : IEntity, new()
	{
		//public event PropertyChangedEventHandler PropertyChanged;

		public Enum.CommandType CommandObject { get; private set; }
		public Dictionary<string, Enum.CommandType> CommandFields { get; private set; }

		public Entity() { CommandFields = new Dictionary<string, Enum.CommandType>(); }

		protected void OnPropertyChanged(string propertyName, object before, object after)
		{
			CommandObject = Enum.CommandType.Update;
			if (CommandFields.ContainsKey(propertyName))
				CommandFields.Add(propertyName, Enum.CommandType.Update);
			else
				CommandFields[propertyName] = Enum.CommandType.Update;


			// do something with before/after
			//var propertyChanged = PropertyChanged;
			//if (propertyChanged != null)
			//{
			//	propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			//}
		}


        public IEntityDml<TSource> Context(string alias) => 
			new EntityDml<TSource>(ContextNew.GetContext(alias), (IEntity)this);
        public static IEntityDmlStatic<TSource> Contexts(string alias) => 
			new EntityDml<TSource>(ContextNew.GetContext(alias));

		public IEntityCommit Insert() => 
			new EntityDml<TSource>(ContextNew.GetContext(this.GetType())).Insert((TSource)(IEntity)this);
		public static IEntityCommit Insert(TSource FirstEntity, params TSource[] OtherEntities) => 
			new EntityDml<TSource>(ContextNew.GetContext((new TSource()).GetType())).Insert(FirstEntity, OtherEntities);

        //public IEntityCommit Insert<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Insert<TConnectionAlias>((TSource)(IEntity)this);
        //public static IEntityCommit Insert<TConnectionAlias>(TSource FirstEntity, params TSource[] OtherEntities) where TConnectionAlias : IConnectionAlias, new() => Entity.Insert<TConnectionAlias>(FirstEntity, OtherEntities as IEntity[]);

  //      public IEntityWhere<TSource> Update<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Update<TConnectionAlias>((TSource)(IEntity)this);
		//public static IEntityWhere<TSource> Update<TConnectionAlias>(TSource entity) where TConnectionAlias : IConnectionAlias, new()
		//{
		//	if (entity != null)
		//	{
		//		//TConnectionAlias connectionAlias = new TConnectionAlias();
		//		//ContextData contextData = Context.GetConnection(connectionAlias);
		//		//ICommandDml update = contextData.Dba.Update(entity);
		//		//if (update != null)
		//		//{
		//		//	update.Where = contextData.Dba.Where(entity);
		//		//	CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { update });
		//		//	contextData.Commands.Add(commandsData.Identifier, commandsData);

		//		//	return new EntityWhere<TSource>(commandsData, connectionAlias);
		//		//}
		//	}

		//	return new EntityWhere<TSource>();
		//}

		//public IEntityWhere<TSource> Delete<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Delete<TConnectionAlias>((TSource)(IEntity)this);
		//public static IEntityWhere<TSource> Delete<TConnectionAlias>(TSource entity = default) where TConnectionAlias : IConnectionAlias, new()
		//{
		//	//TConnectionAlias connectionAlias = new TConnectionAlias();
		//	//ContextData contextData = Context.GetConnection(connectionAlias);
		//	//entity = (entity == null) ? new TSource() : entity;
		//	//ICommandDml delete = contextData.Dba.Delete(entity);
		//	//if (delete != null)
		//	//{
		//	//	delete.Where = contextData.Dba.Where(entity);
		//	//	CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { delete });
		//	//	contextData.Commands.Add(commandsData.Identifier, commandsData);

		//	//	return new EntityWhere<TSource>(commandsData, connectionAlias);
		//	//}

		//	return new EntityWhere<TSource>();
		//}

		//public static IEntityJoin<TSource> Select<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new()
		//{

		//	return default;
		//}
		//public static IEntityJoin<TSource> Select<TConnectionAlias>(Expression<Func<TSource, object>> fields) where TConnectionAlias : IConnectionAlias, new()
		//{
		//	//ICon connection = Context.GetConnection(connectionName);
		//	//ICommands select = connection.Select(fields.Body);

		//	return default;
		//}
	}

	public static class Entity
	{
        public static IEntityCommand<IEntity> Contexts(string alias) => new EntityCommand<IEntity>(ContextNew.GetContext(alias));

		public static IEntityCommit Insert(IEntity FirstEntity, params IEntity[] OtherEntities) => 
			new EntityDml<IEntity>(ContextNew.GetContext(FirstEntity.GetType())).Insert(FirstEntity, OtherEntities);


        public static IEntityCommit Alter<TConnectionAlias>(DataBase dataBase) where TConnectionAlias : IConnectionAlias, new()
		{
			//TConnectionAlias connectionAlias = new TConnectionAlias();
			//ContextData contextData = Context.GetConnection(connectionAlias);

			//List<ICommandBase> commands = new List<ICommandBase>();
			//ICommandDdl alter = contextData.Dba.Alter(dataBase);

			//if (alter != null)
			//	commands.Add(alter);
			//if (commands.Count > 0)
			//{
			//	CommandsData commandsData = new CommandsData(Enum.CommandType.Alter, commands);
			//	contextData.Commands.Add(commandsData.Identifier, commandsData);

			//	return new EntityCommit(commandsData, connectionAlias);
			//}

			return default;
		}
	}
}
 