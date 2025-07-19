using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;
using System.Data.Common;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NGEntity;

public class ContextNew
{
    public bool PrintCommandsInConsole { get; set; } = false;
    private Dictionary<string, ContextData> ContextsData { get; set; }

    public ContextNew()
    {
        ContextsData = [];
        ContextHandle.OnCreateContext(this);
    }
    public void AddContext(string alias, IConnectionDataBases connection, params IEntity[] entities)
    {
        //connection.TestConnection();

        if (ContextsData.ContainsKey(alias))
            throw new ContextAlreadyExists(alias);

        List<Type> types = [];
        foreach (var entity in entities)
            types.Add(entity.GetType());
         
        ContextsData.Add(alias, new ContextData(alias, connection, types));
    }
    internal void AddCommand(string contextAlias, ICommand command)
    {
        if (!ContextsData.TryGetValue(contextAlias, out ContextData contextData))
            throw new ContextNotExists(contextAlias);

        contextData.Commands.Add(command.Clone());
    }
    internal void DeleteCommand(Guid commandIdentifier) =>
        ContextsData.Select(s=> s.Value).ToList().ForEach(f => { f.Commands.RemoveAll(x => x.Identifier.Equals(commandIdentifier)); });

    internal string[] GetContextsAlias(Type type) =>
        ContextsData.Where(w => w.Value.Types.Contains(type)).Select(s => s.Key).ToArray();
    internal string[] GetContextsAlias(Guid identifier) =>
       ContextsData.Where(w => w.Value.Commands.Any(a=> a.Identifier == identifier)).Select(s => s.Key).ToArray();
    internal List<ContextData> GetContextsData(Guid identifier) =>
        ContextsData.Where(w => w.Value.Commands.Any(a => a.Identifier.Equals(identifier))).Select(s=> s.Value).ToList();
    internal ContextData GetContextsData(string contextAlias)
    {
        if (!ContextsData.TryGetValue(contextAlias, out ContextData contextData))
            throw new ContextNotExists(contextAlias);

        return contextData;
    }

    internal string GetQuery(Guid commandIdentifier, string contextAlias)
    {
        ContextData contextDataAlias = GetContextsData(contextAlias);
        ContextData contextDataGuid =
            GetContextsData(commandIdentifier).FirstOrDefault() ??
                throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ICommand command in contextDataGuid.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
        {
            command.SetCommand(contextDataAlias.Connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
    }
    internal string GetQuery(Guid commandIdentifier, IConnection connection)
    {
        ContextData contextData = 
            GetContextsData(commandIdentifier).FirstOrDefault() ?? 
                throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ICommand command in contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
        {
            command.SetCommand(connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
    }
    internal string GetQuery(Guid commandIdentifier)
    {
        List<ContextData> contextsData = GetContextsData(commandIdentifier);
        if ((contextsData?.Count ?? 0) <= 0)
            throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ContextData contextData in contextsData)
        {
            foreach (ICommand command in contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
            {
                command.SetCommand(contextData.Connection);
                query.AppendLine(String.Join(';', command.ToString()));
            }
        }

        return query.ToString();
    }
    internal string GetQuery(ICommand command, string contextAlias)
    {
        ContextData contextData = GetContextsData(contextAlias);

        command.SetCommand(contextData.Connection);
        return command.ToString();
    }
    internal string GetQuery(ICommand command, IConnection connection)
    {
        if (connection == null)
            throw new InvalidConnection();

        command.SetCommand(connection);
        return command.ToString();
    }
    

    internal bool ExecuteNonQuery(Guid commandIdentifier, string contextAlias)
    {
        ContextData contextDataAlias = GetContextsData(contextAlias);
        ContextData contextDataGuid =
            GetContextsData(commandIdentifier).FirstOrDefault() ??
                throw new CommandNotExists(commandIdentifier);

        bool hasTransactionLocal = false;

        try
        {
            hasTransactionLocal = ((IConnectionDataBases)contextDataAlias.Connection).HasTransaction;
            if (!hasTransactionLocal)
                ((IConnectionDataBases)contextDataAlias.Connection).BeginTransaction();

            foreach (ICommand command in contextDataGuid.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
            {
                command.SetCommand(contextDataAlias.Connection);
                ((IConnectionDataBases)contextDataAlias.Connection).ExecuteNonQuery(command);
            }

            if (!hasTransactionLocal)
                ((IConnectionDataBases)contextDataAlias.Connection).CommitTransaction();
        }
        catch (Exception)
        {
            if (!hasTransactionLocal)
                ((IConnectionDataBases)contextDataAlias.Connection).RollbackTransaction();

            throw;
        }
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal bool ExecuteNonQuery(Guid commandIdentifier, IConnection connection)
    {
        ContextData context =
            GetContextsData(commandIdentifier).FirstOrDefault() ??
                throw new CommandNotExists(commandIdentifier);

        bool hasTransactionLocal = false;

        try
        {
            hasTransactionLocal = ((IConnectionDataBases)connection).HasTransaction;
            if (!hasTransactionLocal)
                ((IConnectionDataBases)connection).BeginTransaction();

            foreach (ICommand command in context.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
            {
                command.SetCommand(connection);
                ((IConnectionDataBases)connection).ExecuteNonQuery(command);
            }

            if (!hasTransactionLocal)
                ((IConnectionDataBases)connection).CommitTransaction();
        }
        catch (Exception)
        {
            if (!hasTransactionLocal)
                ((IConnectionDataBases)connection).RollbackTransaction();

            throw;
        }
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal bool ExecuteNonQuery(Guid commandIdentifier)
    {
        List<ContextData> contextsData = GetContextsData(commandIdentifier);
        if ((contextsData?.Count ?? 0) <= 0)
            throw new CommandNotExists(commandIdentifier);

        bool hasTransactionLocal = false;
        foreach (ContextData context in contextsData)
        {
            try
            {
                hasTransactionLocal = ((IConnectionDataBases)context.Connection).HasTransaction;
                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).BeginTransaction();

                foreach (ICommand command in context.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
                {
                    command.SetCommand(context.Connection);
                    ((IConnectionDataBases)context.Connection).ExecuteNonQuery(command);
                }

                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).CommitTransaction();
            }
            catch (Exception)
            {
                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).RollbackTransaction();

                throw;
            }
        }
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal bool ExecuteNonQuery(ICommand command, string contextAlias)
    {
        ContextData contextData = GetContextsData(contextAlias);

        command.SetCommand(contextData.Connection);
        return true;


       
    }
    internal bool ExecuteNonQuery(ICommand command, IConnection connection)
    {
        if (connection == null)
            throw new InvalidConnection();

        command.SetCommand(connection);
        return true;
    }
    

    internal string ExecuteReader(Guid commandIdentifier, string contextAlias)
    {
        ContextData contextDataAlias = GetContextsData(contextAlias);
        ContextData contextDataGuid =
            GetContextsData(commandIdentifier).FirstOrDefault() ??
                throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ICommand command in contextDataGuid.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
        {
            command.SetCommand(contextDataAlias.Connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
    }
    internal string ExecuteReader(Guid commandIdentifier, IConnection connection)
    {
        ContextData contextData =
            GetContextsData(commandIdentifier).FirstOrDefault() ??
                throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ICommand command in contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
        {
            command.SetCommand(connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
    }
    internal string ExecuteReader(ICommand command, string contextAlias)
    {
        ContextData contextData = GetContextsData(contextAlias);

        command.SetCommand(contextData.Connection);
        return command.ToString();
    }
    internal string ExecuteReader(ICommand command, IConnection connection)
    {
        if (connection == null)
            throw new InvalidConnection();

        command.SetCommand(connection);
        return command.ToString();
    }
    internal string ExecuteReader(Guid commandIdentifier)
    {
       





        List<ContextData> contextsData = GetContextsData(commandIdentifier);
        if ((contextsData?.Count ?? 0) <= 0)
            throw new CommandNotExists(commandIdentifier);

        StringBuilder query = new();
        foreach (ContextData contextData in contextsData)
        {
            foreach (ICommand command in contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
            {
                command.SetCommand(contextData.Connection);
                query.AppendLine(String.Join(';', command.ToString()));
            }
        }

        return query.ToString();
    }

    
    /*
    public static void BeginTransaction()
    {
        foreach (ContextData context in IsContextsDataInitialize())
            ((IConnectionDataBases)context.Connection)?.BeginTransaction();
    }
    public static bool CommitTransaction()
    {
        foreach (ContextData context in IsContextsDataInitialize())
            ((IConnectionDataBases)context.Connection)?.CommitTransaction();

        return true;
    }
    public static bool RollbackTransaction()
    {
        foreach (ContextData context in IsContextsDataInitialize())
            ((IConnectionDataBases)context.Connection)?.RollbackTransaction();

        return true;
    }


    

    

    internal static bool SaveChanges(Guid commandIdentifier, IConnection connection)
    {
        string query = GetQuery(commandIdentifier, connection);
        //((IConnectionDataBases)connection).ExecuteNonQuery(query);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal static bool SaveChanges(Guid commandIdentifier, string contextAlias)
    {
        string query = GetQuery(commandIdentifier, contextAlias);
        //((IConnectionDataBases)GetContext(contextAlias).Connection).ExecuteNonQuery(query);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal static bool SaveChanges(Guid commandIdentifier)
    {
        bool hasTransactionLocal = false;
        foreach (ContextData context in GetContext(commandIdentifier))
        {
            try
            {
                hasTransactionLocal = ((IConnectionDataBases)context.Connection).HasTransaction;
                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).BeginTransaction();

                IEnumerable<ICommand> commands = context.Commands.Where(w => w.Identifier == commandIdentifier);
                SetCommand(context.Alias, commandIdentifier);
                foreach (ICommand command in commands)
                    ((IConnectionDataBases)context.Connection).ExecuteNonQuery(command);

                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).CommitTransaction();
            }
            catch (Exception)
            {
                if (!hasTransactionLocal)
                    ((IConnectionDataBases)context.Connection).RollbackTransaction();

                throw;
            }
        }
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }

    //public static bool SaveChanges(IConnection connection)
    //{

    //    return default;
    //}
    //public static bool SaveChanges(string contextAlias)
    //{
    //    if (!ContextExists(contextAlias))
    //        throw new ContextNotExists($"Context with alias {contextAlias} not exists");

    //    ContextData contextData = Context.GetContext(contextAlias);
    //    //contextData.Connection

    //    return default;
    //}
    //public static bool SaveChanges()
    //{
    //    //var v = Context.GetCommands(Identifier);

    //    return default;
    //}
    */

    //private bool ContextAreMany() =>
    //    ContextsData.Count(x => x.Alias != ALIAS_UNKNOWN) > 1;
    //private bool ContextExists() =>
    //    ContextsData.Any(x => x.Alias != ALIAS_UNKNOWN);
    //private bool ContextExists(string alias) =>
    //    ContextsData.Any(x => x.Alias == alias);
    //private bool CommandExists(Guid commandIdentifier) =>
    //    ContextsData.Any(x => x.Commands.Any(x => x.Identifier.Equals(commandIdentifier)));
    //private static bool ConnectionIsValidDataBases(IConnection connection) =>
    //    connection is IConnectionDataBases;
}
