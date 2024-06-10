using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using Enum = NGEntity.Enums;
using NGEntity.Interfaces;
using NGEntity.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
//using NGEntity.Application.Interfaces;


namespace NGEntity
{
    //public abstract class Entity<TSource> where TSource : Entity<TSource>, new()
    //[AddINotifyPropertyChangedInterface]
	public abstract class Entity<TSource> : ObservableObject where TSource : IEntity, new()
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //[DoNotNotify]
        public Enum.CommandType CommandObject { get; private set; }
        //[DoNotNotify]
        public Dictionary<string, Enum.CommandType> CommandFields { get; private set; }
  
        public Entity() { CommandFields = []; }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            string s = "";
        }

        protected void OnPropertyChanged(string propertyName, object before, object after)
		{
            Console.WriteLine(propertyName);
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
        public static IEntityCommit Inserts(TSource firstEntity, params TSource[] otherEntities) =>
            new EntityDml<TSource>().Insert(firstEntity, otherEntities);

        public IEntityCommit Update() =>
            new EntityDml<TSource>().Update((TSource)(IEntity)this);
        public static IEntityWhere<TSource> Updates(TSource fields) =>
          new EntityDml<TSource>().Updates(fields);

        public IEntityCommit Delete() =>
           new EntityDml<TSource>().Delete((TSource)(IEntity)this);
        public static IEntityWhere<TSource> Deletes() =>
          new EntityDml<TSource>().Deletes();

        public static IEntityJoin<TSource> Selects() =>
            new EntityDml<TSource>().Selects();
        public static IEntityWhere<TSource> Selects<TProperty>(Expression<Func<TSource, TProperty>> fields) =>
             new EntityDml<TSource>().Selects(fields);
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
 