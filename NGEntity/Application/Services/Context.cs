using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NGEntity;

public static class Context
{
    private const string ALIAS_UNKNOWN = "Unknown";

    public static bool PrintCommandsInConsole { get; set; } = false;
    private static List<ContextData> ContextsData { get; set; }
    private static List<ContextData> IsContextsDataInitialize() => ContextsData ??= [new(ALIAS_UNKNOWN, null, [])];

    internal static string[] GetContextsAlias(Type type) => 
        IsContextsDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.Alias).ToArray();
    internal static List<Type> GetContextTypes(Type type) =>
        IsContextsDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.GetType()).ToList();
    internal static List<ContextData> GetContext(Type type) => 
        IsContextsDataInitialize().Where(w=> w.Types.Contains(type)).ToList();
    internal static ContextData GetContext(string alias) =>
        IsContextsDataInitialize().Where(w=> w.Alias == alias).FirstOrDefault();
    internal static ContextData GetContext(Guid identifier) =>
        IsContextsDataInitialize().Where(w => w.Commands.Any(a=> a.Identifier.Equals(identifier))).FirstOrDefault();

    internal static List<ICommand> GetCommands(Guid identifier) =>
       IsContextsDataInitialize().SelectMany(w => w.Commands.Where(w=> w.Identifier.Equals(identifier))).ToList();
    internal static void AddCommand(ICommand command) =>
        IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command);
    internal static void AddCommand(Type type, ICommand command)
    {
        List<ContextData> contexts = GetContext(type);
        if (contexts == null || contexts.Count == 0)
            IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command);
        else
            contexts.ForEach(context => { context.Commands.Add(command); });
    }
    internal static void AddCommand(string connectionAlias, ICommand command) =>
        IsContextsDataInitialize().FirstOrDefault(f => f.Alias == connectionAlias)?.Commands.Add(command);

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

        ContextData contextData = GetContext(ALIAS_UNKNOWN);
        if (!ConnectionIsValidDataBases(contextData.Connection))
            throw new InvalidConnection($"{contextData.Connection.GetType()} is an invalid connection.");

        //// COMO A CONEXÃO FOI PASSADA NO PARÂMETRO, ELA IRÁ SOBREESCREVER AS OUTRAS
        //// ENTÃO OS COMANDOS IRAM SER TRANSFERIDOS TODOS PARA O DESCONHECIDO E SETADO A CONEXÃO LÁ
        List<ICommand> command = new List<ICommand>(GetCommands(commandIdentifier));
        DeleteCommand(commandIdentifier);
        contextData.Connection = connection;
        contextData.Commands.AddRange(command);
        //// CRIA O COMANDO NA VARIAVEL QUERY DO OBJETO
        SetCommand(contextData.Alias, commandIdentifier);
        //// PEGA UMA UNICA STRING COM TODOS OS COMANDO DO IDENTIFICADOR
        string query = GetQuery(contextData.Alias, commandIdentifier);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return query;
    }
    internal static string GetQuery(Guid commandIdentifier, string contextAlias)
    {
        if (!CommandExists(commandIdentifier))
            throw new CommandNotExists($"Command not exists");
        if (!ContextExists(contextAlias))
            throw new ContextNotExists($"Context with alias {contextAlias} not exists");

        ContextData contextData = GetContext(contextAlias);
        if (!ConnectionIsValidDataBases(contextData.Connection))
            throw new InvalidConnection($"{contextData.Connection.GetType()} is an invalid connection.");

        //// COMO O ALIAS DA CONEXÃO FOI PASSADA NO PARÂMETRO, ELA IRÁ SOBREESCREVER AS OUTRAS
        //// ENTÃO OS COMANDOS IRAM SER TRANSFERIDOS TODOS PARA A CONEXÃO ENCONTRADA DO ALIAS
        List<ICommand> command = new List<ICommand>(GetCommands(commandIdentifier));
        DeleteCommand(commandIdentifier);
        contextData.Commands.AddRange(command);
        //// CRIA O COMANDO NA VARIAVEL QUERY DO OBJETO
        SetCommand(contextData.Alias, commandIdentifier);
        //// PEGA UMA UNICA STRING COM TODOS OS COMANDO DO IDENTIFICADOR
        string query = GetQuery(contextData.Alias, commandIdentifier);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return query;
    }
    internal static string GetQuery(Guid commandIdentifier)
    {
        if (!CommandExists(commandIdentifier))
            throw new CommandNotExists($"command not exists");
        if (!ContextExists())
            throw new ContextNotExists($"there is no context initialize");

        ContextData contextData = GetContext(commandIdentifier);
        if(contextData.Alias == ALIAS_UNKNOWN)
        {
            if (ContextAreMany())
                throw new ContextAreMany($"there are to many contexts");

            contextData = IsContextsDataInitialize().Where(w => w.Alias != ALIAS_UNKNOWN).FirstOrDefault();
        }
        if (!ConnectionIsValidDataBases(contextData.Connection))
            throw new InvalidConnection($"{contextData.Connection.GetType()} is an invalid connection.");

        //// ENTÃO OS COMANDOS IRAM SER TRANSFERIDOS TODOS PARA A CONEXÃO ENCONTRADA DIFERENTE DE DESCONHECIDO
        List<ICommand> command = new List<ICommand>(GetCommands(commandIdentifier));
        DeleteCommand(commandIdentifier);
        contextData.Commands.AddRange(command);
        //// CRIA O COMANDO NA VARIAVEL QUERY DO OBJETO
        SetCommand(contextData.Alias, commandIdentifier);
        //// RETORNA UMA UNICA STRING COM TODOS OS COMANDO DO IDENTIFICADOR
        return GetQuery(contextData.Alias, commandIdentifier);
    }

    internal static bool SaveChanges(Guid commandIdentifier, IConnection connection)
    {
        string query = GetQuery(commandIdentifier, connection);
        ((IConnectionDataBases)connection).ExecuteNonQuery(query);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal static bool SaveChanges(Guid commandIdentifier, string contextAlias)
    {
        string query = GetQuery(commandIdentifier, contextAlias);
        ((IConnectionDataBases)GetContext(contextAlias).Connection).ExecuteNonQuery(query);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }
    internal static bool SaveChanges(Guid commandIdentifier)
    {
        string query = GetQuery(commandIdentifier);
        ((IConnectionDataBases)GetContext(commandIdentifier).Connection).ExecuteNonQuery(query);
        //// DELETA O OBJETO COMANDO COM O IDENTIFICADOR, NOVAMENTE E DEFINITIVO
        DeleteCommand(commandIdentifier);

        return true;
    }

    public static bool SaveChanges(IConnection connection)
    {

        return default;
    }
    public static bool SaveChanges(string contextAlias)
    {
        if (!ContextExists(contextAlias))
            throw new ContextNotExists($"Context with alias {contextAlias} not exists");

        ContextData contextData = Context.GetContext(contextAlias);
        //contextData.Connection

        return default;
    }
    public static bool SaveChanges()
    {
        //var v = Context.GetCommands(Identifier);

        return default;
    }

    public static void AddContext(string alias, IConnection connection, params IEntity[] entities)
    {
        List<Type> types = [];
        foreach (var entity in entities) { types.Add(entity.GetType()); }

        if(IsContextsDataInitialize().Any(a => a.Alias == alias))
            throw new ContextAlreadyExists($"Context with alias {alias} already exists");

        IsContextsDataInitialize().Add(new ContextData(alias, connection, types));
    }

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


    //public static bool EntityExistsInContext(string alias, Type type) => 
    //    IsContextsDataInitialize().Any(x => x.Alias == alias && x.Types.Any(x=> x.Equals(type)));
}
