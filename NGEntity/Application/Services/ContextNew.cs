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

    public void BeginTransaction(string contextAlias)
    {
        if (!ContextsData.TryGetValue(contextAlias, out ContextData context))
            throw new ContextNotExists(contextAlias);

        ((IConnectionDataBases)context.Connection)?.BeginTransaction();
    }
    public void BeginTransaction()
    {
        foreach (var context in ContextsData)
            ((IConnectionDataBases)context.Value.Connection)?.BeginTransaction();
    }
    public bool CommitTransaction(string contextAlias)
    {
        if (!ContextsData.TryGetValue(contextAlias, out ContextData context))
            throw new ContextNotExists(contextAlias);

        ((IConnectionDataBases)context.Connection)?.CommitTransaction();

        return true;
    }
    public bool CommitTransaction()
    {
        foreach (var context in ContextsData)
            ((IConnectionDataBases)context.Value.Connection)?.CommitTransaction();

        return true;
    }
    public bool RollbackTransaction(string contextAlias)
    {
        if (!ContextsData.TryGetValue(contextAlias, out ContextData context))
            throw new ContextNotExists(contextAlias);

        ((IConnectionDataBases)context.Connection)?.RollbackTransaction();

        return true;
    }
    public void RollbackTransaction()
    {
        foreach (var context in ContextsData)
            ((IConnectionDataBases)context.Value.Connection)?.RollbackTransaction();
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
        ContextsData.Select(s => s.Value).ToList().ForEach(f => { f.Commands.RemoveAll(x => x.Identifier.Equals(commandIdentifier)); });

    internal string[] GetContextsAlias(Type type) =>
        ContextsData.Where(w => w.Value.Types.Contains(type)).Select(s => s.Key).ToArray();
    internal string[] GetContextsAlias(Guid identifier) =>
       ContextsData.Where(w => w.Value.Commands.Any(a => a.Identifier == identifier)).Select(s => s.Key).ToArray();
    internal List<ContextData> GetContextsData(Guid identifier) =>
        ContextsData.Where(w => w.Value.Commands.Any(a => a.Identifier.Equals(identifier))).Select(s => s.Value).ToList();
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
    internal string GetQuery(IEnumerable<ICommand> commands, string contextAlias)
    {
        ContextData contextData = GetContextsData(contextAlias);

        StringBuilder query = new();
        foreach (ICommand command in commands)
        {
            command.SetCommand(contextData.Connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
    }
    internal string GetQuery(IEnumerable<ICommand> commands, IConnection connection)
    {
        if (connection == null)
            throw new InvalidConnection();

        StringBuilder query = new();
        foreach (ICommand command in commands)
        {
            command.SetCommand(connection);
            query.AppendLine(String.Join(';', command.ToString()));
        }

        return query.ToString();
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
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR
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
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR
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
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal bool ExecuteNonQuery(IEnumerable<ICommand> commands, string contextAlias)
    {
        ContextData context = GetContextsData(contextAlias);

        bool hasTransactionLocal = false;

        try
        {
            hasTransactionLocal = ((IConnectionDataBases)context.Connection).HasTransaction;
            if (!hasTransactionLocal)
                ((IConnectionDataBases)context.Connection).BeginTransaction();

            foreach (ICommand command in commands)
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

        return true;
    }
    internal bool ExecuteNonQuery(IEnumerable<ICommand> commands, IConnection connection)
    {
        if (connection == null)
            throw new InvalidConnection();

        bool hasTransactionLocal = false;

        try
        {
            hasTransactionLocal = ((IConnectionDataBases)connection).HasTransaction;
            if (!hasTransactionLocal)
                ((IConnectionDataBases)connection).BeginTransaction();

            foreach (ICommand command in commands)
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

        return true;
    }

    internal bool ExecuteReader(Guid commandIdentifier, string contextAlias)
    {
        return true;
    }
    internal bool ExecuteReader(Guid commandIdentifier, IConnection connection)
    {
        return true;
    }
    internal bool ExecuteReader(Guid commandIdentifier)
    {
        return true;
    }
    internal bool ExecuteReader(IEnumerable<ICommand> commands, string contextAlias)
    {
        return true;
    }
    internal bool ExecuteReader(IEnumerable<ICommand> commands, IConnection connection)
    {
        return true;
    }
}
