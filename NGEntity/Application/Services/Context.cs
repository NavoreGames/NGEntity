using NGConnection.Interfaces;
using NGConnection.Models;

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
    internal static ContextData GetContext(string alias)
    {
        return IsContextsDataInitialize().Where(w=> w.Alias == alias).FirstOrDefault();
    }
    internal static List<ICommand> GetCommands(Guid identifier) =>
       IsContextsDataInitialize().SelectMany(w => w.Commands.Where(w=> w.Identifier.Equals(identifier))).ToList();
    internal static void AddCommand(ICommand command)
    {
        IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command);
    }
    internal static void AddCommand(Type type, ICommand command)
    {
        List<ContextData> contexts = Context.GetContext(type);
        if (contexts == null || contexts.Count == 0)
            IsContextsDataInitialize().FirstOrDefault(w => w.Alias == ALIAS_UNKNOWN)?.Commands.Add(command);
        else
            contexts.ForEach(context => { context.Commands.Add(command); });
    }
    internal static void AddCommand(string connectionAlias, ICommand command)
    {
        Context.IsContextsDataInitialize().FirstOrDefault(f => f.Alias == connectionAlias)?.Commands.Add(command);
    }
    internal static void DeleteCommand(Guid commandIdentifier)
    {
        IsContextsDataInitialize().ForEach(f => { f.Commands.RemoveAll(x => x.Identifier.Equals(commandIdentifier)); });
    }

    public static void AddContext(string alias, IConnection connection, params IEntity[] entities)
    {
        List<Type> types = [];
        foreach (var entity in entities) { types.Add(entity.GetType()); }

        if(IsContextsDataInitialize().Any(a => a.Alias == alias))
            throw new ContextAlreadyExists($"Context with alias {alias} already exists");

        IsContextsDataInitialize().Add(new ContextData(alias, connection, types));
    }

    public static bool ContextExists(string alias) => 
        IsContextsDataInitialize().Any(x => x.Alias == alias);
    //public static bool CommandExistsInContext(string alias, Guid commandIdentifier) => 
    //    IsContextsDataInitialize().Any(x => x.Alias == alias && x.CommandsData.Any( x=> x.Identifier.Equals(commandIdentifier)));
    //public static bool EntityExistsInContext(string alias, Type type) => 
    //    IsContextsDataInitialize().Any(x => x.Alias == alias && x.Types.Any(x=> x.Equals(type)));
}
