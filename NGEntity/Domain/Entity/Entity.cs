using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel;
using NGConnection.Interfaces;
using NGEntity.Interfaces;
using NGEntity.Domain;
using NGEntity.Models;

namespace NGEntity
{
    //public abstract class Entity<TSource> where TSource : Entity<TSource>, new()
    public abstract class Entity<TSource> where TSource : IEntity, INotifyPropertyChanged, new()
	{
		public event PropertyChangedEventHandler PropertyChanged;

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

		public IEntityCommit Insert<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Insert<TConnectionAlias>((TSource)(IEntity)this);
		public static IEntityCommit Insert<TConnectionAlias>(TSource FirstEntity, params TSource[] OtherEntities) where TConnectionAlias : IConnectionAlias, new() => Entity.Insert<TConnectionAlias>(FirstEntity, OtherEntities as IEntity[]);

		public IEntityWhereCommit<TSource> Update<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Update<TConnectionAlias>((TSource)(IEntity)this);
		public static IEntityWhereCommit<TSource> Update<TConnectionAlias>(TSource entity) where TConnectionAlias : IConnectionAlias, new()
		{
			if (entity != null)
			{
				TConnectionAlias connectionAlias = new TConnectionAlias();
				ContextData contextData = Context.GetConnection(connectionAlias);
				ICommandDml update = contextData.Dba.Update(entity);
				if (update != null)
				{
					update.Where = contextData.Dba.Where(entity);
					CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { update });
					contextData.Commands.Add(commandsData.Identifier, commandsData);

					return new EntityWhereCommit<TSource>(commandsData, connectionAlias);
				}
			}

			return new EntityWhereCommit<TSource>();
		}

		public IEntityWhereCommit<TSource> Delete<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new() => Delete<TConnectionAlias>((TSource)(IEntity)this);
		public static IEntityWhereCommit<TSource> Delete<TConnectionAlias>(TSource entity = default) where TConnectionAlias : IConnectionAlias, new()
		{
			TConnectionAlias connectionAlias = new TConnectionAlias();
			ContextData contextData = Context.GetConnection(connectionAlias);
			entity = (entity == null) ? new TSource() : entity;
			ICommandDml delete = contextData.Dba.Delete(entity);
			if (delete != null)
			{
				delete.Where = contextData.Dba.Where(entity);
				CommandsData commandsData = new CommandsData(Enum.CommandType.Update, new List<ICommandBase>() { delete });
				contextData.Commands.Add(commandsData.Identifier, commandsData);

				return new EntityWhereCommit<TSource>(commandsData, connectionAlias);
			}

			return new EntityWhereCommit<TSource>();
		}

		public static IEntityQuery<TSource> Select<TConnectionAlias>() where TConnectionAlias : IConnectionAlias, new()
		{

			return default;
		}
		public static IEntityQuery<TSource> Select<TConnectionAlias>(Expression<Func<TSource, object>> fields) where TConnectionAlias : IConnectionAlias, new()
		{
			//ICon connection = Context.GetConnection(connectionName);
			//ICommands select = connection.Select(fields.Body);

			return default;
		}
	}

	public static class Entity
	{
		public static IEnumerable<object> Command<TConnectionAlias>(string query) where TConnectionAlias : IConnectionAlias, new()
		{

			return default;
		}
		public static IEnumerable<TReturn> Command<TConnectionAlias, TReturn>(string query) where TReturn : IReturn
		{
			return default;
		}
		public static IEntityCommit Insert<TConnectionAlias>(IEntity FirstEntity, params IEntity[] OtherEntities) where TConnectionAlias : IConnectionAlias, new()
		{
			if (FirstEntity != null || (OtherEntities != null && OtherEntities.Length > 0))
			{
				TConnectionAlias connectionAlias = new TConnectionAlias();
				ContextData contextData = Context.GetConnection(connectionAlias);
				List<ICommandBase> commands = new List<ICommandBase>();
				////// ADICINA PRIMEIRA ENTIDADE //////////////
				if (FirstEntity != null)
				{
					ICommandDml insert = contextData.Dba.Insert(FirstEntity);
					if (insert != null)
						commands.Add(insert);
				}
				////// ADICIONA O RESTO DAS ENTIDADES //////////
				foreach (IEntity entity in OtherEntities)
				{
					if (entity != null)
					{
						ICommandDml insert = contextData.Dba.Insert(FirstEntity);
						if (insert != null)
							commands.Add(insert);
					}
				}
				////// ADICIONA OS COMANDOS NO DICIONARIO /////////
				if (commands.Count > 0)
				{
					CommandsData commandsData = new CommandsData(Enum.CommandType.Insert, commands);
					contextData.Commands.Add(commandsData.Identifier, commandsData);

					return new EntityCommit(commandsData, connectionAlias);
				}
			}
			return new EntityCommit();
		}
		public static IEntityCommit Alter<TConnectionAlias>(DataBase dataBase) where TConnectionAlias : IConnectionAlias, new()
		{
			TConnectionAlias connectionAlias = new TConnectionAlias();
			ContextData contextData = Context.GetConnection(connectionAlias);

			List<ICommandBase> commands = new List<ICommandBase>();
			ICommandDdl alter = contextData.Dba.Alter(dataBase);

			if (alter != null)
				commands.Add(alter);
			if (commands.Count > 0)
			{
				CommandsData commandsData = new CommandsData(Enum.CommandType.Alter, commands);
				contextData.Commands.Add(commandsData.Identifier, commandsData);

				return new EntityCommit(commandsData, connectionAlias);
			}

			return new EntityCommit();
		}
	}
}
 