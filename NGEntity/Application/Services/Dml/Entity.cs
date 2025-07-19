using System.Linq.Expressions;
using NGEntity.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using NGConnection.Domain.Models;
//using NGEntity.Application.Interfaces;


namespace NGEntity
{
    //public abstract class Entity<TSource> where TSource : Entity<TSource>, new()
    //[AddINotifyPropertyChangedInterface]
    public abstract class Entity<TSource> : ObservableObject, IEntity
        where TSource : IEntity, new()
    {
        //      //public event PropertyChangedEventHandler PropertyChanged;
        //      //[DoNotNotify]
        //      public CommandType CommandObject { get; private set; }
        //      //[DoNotNotify]
        //      public Dictionary<string, CommandType> CommandFields { get; private set; }
        //      public Entity() { CommandFields = []; }

        //      protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        //      {
        //          string s = "";
        //      }
        //      protected void OnPropertyChanged(string propertyName, object before, object after)
        //{
        //          Console.WriteLine(propertyName);
        //          CommandObject = DmlCommandType.Update;
        //          if (CommandFields.ContainsKey(propertyName))
        //              CommandFields.Add(propertyName, DmlCommandType.Update);
        //          else
        //              CommandFields[propertyName] = DmlCommandType.Update;


        //          // do something with before/after
        //          //var propertyChanged = PropertyChanged;
        //          //if (propertyChanged != null)
        //          //{
        //          //	propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //          //}
        //      }

        protected static TTarget MapOne<TTarget>(
            Expression<Func<TTarget, object>> targeRelation, Expression<Func<TSource, object>> sourceRelation)
                where TTarget : IEntity, new()
        {
            return default;
        }
        protected static TTarget MapOne<TTarget>(
            params (Expression<Func<TTarget, object>> targeRelation, Expression<Func<TSource, object>> sourceRelation)[] relations)
                where TTarget : IEntity, new()
        {
            return default;
        }
        protected static IEnumerable<TTarget> MapMany<TTarget>(
             Expression<Func<TTarget, object>> targeRelation, Expression<Func<TSource, object>> sourceRelation)
                where TTarget : IEntity, new()
        {
            return default;
        }
        protected static IEnumerable<TTarget> MapMany<TTarget>(
            params (Expression<Func<TTarget, object>> targeRelation, Expression<Func<TSource, object>> sourceRelation)[] relations)
                where TTarget : IEntity, new()
        {
            return default;
        }

        public ICommandExecute Insert() =>
            new EntityDml<TSource>().Insert((TSource)(IEntity)this);
        public static ICommandExecute Inserts(TSource firstEntity, params TSource[] otherEntities) =>
            new EntityDml<TSource>().Insert(firstEntity, otherEntities);

        public ICommandExecute Update() =>
            new EntityDml<TSource>().Update((TSource)(IEntity)this);
        public static IEntityWhere<TSource> Updates(TSource fields) =>
          new EntityDml<TSource>().Updates(fields);

        public ICommandExecute Delete() =>
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
        public static bool CreateEntitiesFromCode(DataBase dataBase)
        {
            return default;
        }
        public static bool CreateEntitiesFromDataBase()
        {
            return default;
        }
        //public static IEntityCcaDmlStatic SetConnections(IConnection connection) =>
        //    new EntityCcaDml(connection);

        //public static void Inserts(IEntity FirstEntity, params IEntity[] OtherEntities)
        //{ }

        //public static IEntityCcaCommit Query(string query) { return default; }

        //      public static ICommandCommit Alter<TConnectionAlias>(DataBase dataBase) where TConnectionAlias : IConnectionAlias, new()
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
 