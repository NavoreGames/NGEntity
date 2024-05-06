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

        public IEntityCcaDml<TSource> SetConnection(IConnection connection) =>
            new EntityCcaDml<TSource>(connection, (IEntity)this);
        public static IEntityCcaDmlStatic<TSource> SetConnections(IConnection connection) =>
            new EntityCcaDml<TSource>(connection);

        public void Insert() =>
            new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType()), (IEntity)this).Insert();
        public static void Inserts(TSource FirstEntity, params TSource[] OtherEntities) =>
            new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType())).Inserts(FirstEntity, OtherEntities);

        public void Update() =>
            new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType()), (IEntity)this).Update();
        public static IEntityFcaWhere<TSource> Updates(TSource entity) =>
          new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType())).Updates(entity);

        public void Delete() =>
           new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType()), (IEntity)this).Delete();
        public static IEntityFcaWhere<TSource> Deletes() =>
          new EntityFcaDml<TSource>(Context.GetAlias(new TSource().GetType())).Deletes();

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
        //public static IEntityCcaDmlStatic<TSource> SetConnections(IConnection connection) =>
        //    new EntityCcaDml<TSource>(connection);

        //public static void Inserts(IEntity FirstEntity, params IEntity[] OtherEntities) =>
        //    new EntityFcaDml<IEntity>(Context.GetContext(FirstEntity.GetType())).Insert(FirstEntity, OtherEntities);


        //      public static IEntityCommit Alter<TConnectionAlias>(DataBase dataBase) where TConnectionAlias : IConnectionAlias, new()
        //{
        //	//TConnectionAlias connectionAlias = new TConnectionAlias();
        //	//ContextData contextData = Context.GetConnection(connectionAlias);

        //	//List<ICommandBase> commands = new List<ICommandBase>();
        //	//ICommandDdl alter = contextData.Dba.Alter(dataBase);

        //	//if (alter != null)
        //	//	commands.Add(alter);
        //	//if (commands.Count > 0)
        //	//{
        //	//	CommandsData commandsData = new CommandsData(Enum.CommandType.Alter, commands);
        //	//	contextData.Commands.Add(commandsData.Identifier, commandsData);

        //	//	return new EntityCommit(commandsData, connectionAlias);
        //	//}

        //	return default;
        //}
    }
}
 