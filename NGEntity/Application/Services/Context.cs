using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;
using System.Data.Common;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NGEntity;

public static class Context
{
    private const string ALIAS_UNKNOWN = "Unknown";

    public static bool PrintCommandsInConsole { get; set; } = false;
    private static List<ContextData> ContextsData { get; set; }
    private static List<ContextData> IsContextsDataInitialize() => ContextsData ??= [new(ALIAS_UNKNOWN, null, [])];

    public static void AddContext(string alias, IConnection connection, params IEntity[] entities)
    {
        List<Type> types = [];
        foreach (var entity in entities) { types.Add(entity.GetType()); }

        if (IsContextsDataInitialize().Any(a => a.Alias == alias))
            throw new ContextAlreadyExists($"Context with alias {alias} already exists");

        IsContextsDataInitialize().Add(new ContextData(alias, connection, types));
    }

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

    internal static string[] GetContextsAlias(Type type) => 
        IsContextsDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.Alias).ToArray();
    internal static List<Type> GetContextTypes(Type type) =>
        IsContextsDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.GetType()).ToList();
    internal static List<ContextData> GetContext(Type type) => 
        IsContextsDataInitialize().Where(w=> w.Types.Contains(type)).ToList();
    internal static ContextData GetContext(string alias) =>
        IsContextsDataInitialize().Where(w=> w.Alias == alias).FirstOrDefault();
    internal static List<ContextData> GetContext(Guid identifier) =>
        IsContextsDataInitialize().Where(w => w.Commands.Any(a=> a.Identifier.Equals(identifier))).ToList();

    internal static List<ICommand> GetCommands(Guid identifier) =>
       IsContextsDataInitialize().SelectMany(w => w.Commands.Where(w=> w.Identifier.Equals(identifier))).ToList();
    internal static List<ICommand> GetCommandsFromOneContext(Guid identifier)
    {
       ContextData context = IsContextsDataInitialize().FirstOrDefault(w => w.Commands.Any(a=> a.Identifier.Equals(identifier)));
       return context.Commands.Where(w => w.Identifier.Equals(identifier)).ToList();
    }

    internal static void AddCommand(ICommand command) =>
        IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command.Clone());
    internal static void AddCommand(Type type, ICommand command)
    {
        List<ContextData> contexts = GetContext(type);
        if (contexts == null || contexts.Count == 0)
            IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command.Clone());
        else
            contexts.ForEach(context => { context.Commands.Add(command.Clone()); });
    }
    internal static void AddCommand(string connectionAlias, ICommand command) =>
        IsContextsDataInitialize().FirstOrDefault(f => f.Alias == connectionAlias)?.Commands.Add(command.Clone());

    internal static void DeleteCommand(Guid commandIdentifier) =>
        IsContextsDataInitialize().ForEach(f => { f.Commands.RemoveAll(x => x.Identifier.Equals(commandIdentifier)); });

    private static void SetCommand(string alias, Guid commandIdentifier)
    {
        ContextData contextData = GetContext(alias);
        foreach(ICommand command in contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)))
            command.SetCommand(contextData.Connection);
    }
    private static string GetQuery(string alias, Guid commandIdentifier)
    {
        ContextData contextData = GetContext(alias);
        return String.Join(';',contextData.Commands.Where(w => w.Identifier.Equals(commandIdentifier)).Select(s=> s.ToString()));
    }

    internal static string GetQuery(Guid commandIdentifier, IConnection connection)
    {
        if (!CommandExists(commandIdentifier))
            throw new CommandNotExists($"Command not exists");
        if (!ConnectionIsValidDataBases(connection))
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");
        //// COMO A CONEXÃO FOI PASSADA NO PARÂMETRO, ELA IRÁ SOBREESCREVER AS OUTRAS
        //// ENTÃO OS COMANDOS IRAM SER TRANSFERIDOS TODOS PARA O DESCONHECIDO E SETADO A CONEXÃO LÁ
        List<ICommand> command = new List<ICommand>(GetCommandsFromOneContext(commandIdentifier));
        DeleteCommand(commandIdentifier);
        ContextData contextData = GetContext(ALIAS_UNKNOWN);
        contextData.Connection = connection;
        contextData.Commands.AddRange(command);
        //// CRIA O COMANDO NA VARIAVEL QUERY DO OBJETO
        SetCommand(contextData.Alias, commandIdentifier);
        //// PEGA UMA UNICA STRING COM TODOS OS COMANDO DO IDENTIFICADOR
        return GetQuery(contextData.Alias, commandIdentifier);
    }
    internal static string GetQuery(Guid commandIdentifier, string contextAlias)
    {
        if (!CommandExists(commandIdentifier))
            throw new CommandNotExists($"Command not exists.");
        if (!ContextExists(contextAlias))
            throw new ContextNotExists($"Context with alias {contextAlias} not exists. Initialize context with AddContext or use another overload.");

        ContextData context = GetContext(contextAlias);
        if (!ConnectionIsValidDataBases(context.Connection))
            throw new InvalidConnection($"{context.Connection.GetType()} is an invalid connection.");

        //// COMO O ALIAS DA CONEXÃO FOI PASSADA NO PARÂMETRO, ELA IRÁ SOBREESCREVER AS OUTRAS
        //// ENTÃO OS COMANDOS IRAM SER TRANSFERIDOS TODOS PARA A CONEXÃO ENCONTRADA DO ALIAS
        List<ICommand> command = new List<ICommand>(GetCommandsFromOneContext(commandIdentifier));
        //command
        DeleteCommand(commandIdentifier);
        context.Commands.AddRange(command);
        //// CRIA O COMANDO NA VARIAVEL QUERY DO OBJETO
        SetCommand(context.Alias, commandIdentifier);
        //// PEGA UMA UNICA STRING COM TODOS OS COMANDO DO IDENTIFICADOR
        return GetQuery(context.Alias, commandIdentifier);

    }
    internal static string GetQuery(Guid commandIdentifier)
    {
        if (!CommandExists(commandIdentifier))
            throw new CommandNotExists($"command not exists.");
        if (!ContextExists())
            throw new ContextNotExists($"Context not exists. Initialize context with AddContext or use another overload.");

        List<ContextData> contexts = GetContext(commandIdentifier);
        if(contexts.Any(a=> a.Alias == ALIAS_UNKNOWN))
            throw new ContextNotExists($"Context not exists for entity. Initialize context with AddContext or use another overload.");

        StringBuilder query = new();
        foreach(ContextData context in contexts)
        {
            if (!ConnectionIsValidDataBases(context.Connection))
                throw new InvalidConnection($"{context.Connection.GetType()} is an invalid connection.");

            SetCommand(context.Alias, commandIdentifier);
            query.AppendLine(GetQuery(context.Alias, commandIdentifier));
        }

        return query.ToString();
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

    private static bool ContextAreMany() =>
        IsContextsDataInitialize().Count(x => x.Alias != ALIAS_UNKNOWN) > 1;
    private static bool ContextExists() =>
        IsContextsDataInitialize().Any(x => x.Alias != ALIAS_UNKNOWN);
    private static bool ContextExists(string alias) => 
        IsContextsDataInitialize().Any(x => x.Alias == alias);
    private static bool CommandExists(Guid commandIdentifier) =>
        IsContextsDataInitialize().Any(x => x.Commands.Any(x => x.Identifier.Equals(commandIdentifier)));
    private static bool ConnectionIsValidDataBases(IConnection connection) =>
        connection is IConnectionDataBases;
}
