﻿using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Exceptions;

namespace NGEntity
{
    public static class Context
    {
        private static List<ContextData> ContextsData { get; set; }
        private static List<ContextData> IsContextDataInitialize() => ContextsData ??= [new ContextData("None", null, [])];

        internal static string[] GetContextsAlias(Type type) => 
            IsContextDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.Alias).ToArray();
        internal static List<Type> GetContextTypes(Type type) =>
            IsContextDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.GetType()).ToList();
        internal static List<ContextData> GetContext(Type type) => 
            IsContextDataInitialize().Where(w=> w.Types.Contains(type)).ToList();
        internal static ContextData GetContext(string alias)
        {
            return IsContextDataInitialize().Where(w=> w.Alias == alias).FirstOrDefault();
        }
        internal static List<CommandData> GetCommandData(Guid identifier) =>
           IsContextDataInitialize().SelectMany(w => w.CommandsData.Where(w=> w.Identifier.Equals(identifier))).ToList();
        internal static void AddCommand(Type type, CommandData commandData)
        {
            List<ContextData> contexts = Context.GetContext(type);
            if (contexts == null || contexts.Count == 0)
                Context.IsContextDataInitialize().FirstOrDefault(f => f.Alias == "None")?.CommandsData.Add(commandData);
            else
                contexts.ForEach(context => { context.CommandsData.Add(commandData); });
        }
        internal static void AddCommand(string connectionAlias, CommandData commandData)
        {
            Context.IsContextDataInitialize().FirstOrDefault(f => f.Alias == connectionAlias)?.CommandsData.Add(commandData);
        }
        internal static void DeleteCommand(Guid commandIdentifier)
        {
            IsContextDataInitialize().ForEach(f => { f.CommandsData.RemoveAll(x => x.Identifier.Equals(commandIdentifier)); });
        }

        public static void AddContext(string alias, IConnection connection, params IEntity[] entities)
        {
            List<Type> types = [];
            foreach (var entity in entities) { types.Add(entity.GetType()); }

            if(IsContextDataInitialize().Any(a => a.Alias == alias))
                throw new ContextAlreadyExists($"Context with alias {alias} already exists");

            IsContextDataInitialize().Add(new ContextData(alias, connection, types));
        }

        public static bool ContextExists(string alias) => 
            IsContextDataInitialize().Any(x => x.Alias == alias);
        public static bool CommandExistsInContext(string alias, Guid commandIdentifier) => 
            IsContextDataInitialize().Any(x => x.Alias == alias && x.CommandsData.Any( x=> x.Identifier.Equals(commandIdentifier)));
        public static bool EntityExistsInContext(string alias, Type type) => 
            IsContextDataInitialize().Any(x => x.Alias == alias && x.Types.Any(x=> x.Equals(type)));
    }
}
