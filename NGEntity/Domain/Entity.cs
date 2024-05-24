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

		public Entity() { CommandFields = []; }

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

        public IEntityCommit Insert() =>
           new EntityDml<TSource>().Insert((TSource)(IEntity)this);
        public static IEntityCommit Inserts(TSource FirstEntity, params TSource[] OtherEntities) =>
            new EntityDml<TSource>().Insert(FirstEntity, OtherEntities);

        public IEntityCommit Update() =>
            new EntityDml<TSource>().Update((TSource)(IEntity)this);
        public static IEntityWhere<TSource> Updates<TProperty>(Expression<Func<TSource, TProperty>> fields) =>
          new EntityDml<TSource>().Update(fields);

        public IEntityCommit Delete() =>
           new EntityDml<TSource>().Delete((TSource)(IEntity)this);
        public static IEntityWhere<TSource> Deletes() =>
          new EntityDml<TSource>().Delete();
    }

    public static class Entity
	{
        //public static IEntityCcaDmlStatic SetConnections(IConnection connection) =>
        //    new EntityCcaDml(connection);

        //public static void Inserts(IEntity FirstEntity, params IEntity[] OtherEntities)
        //{ }

        //public static IEntityCcaCommit Query(string query) { return default; }

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
 