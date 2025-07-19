using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGEntity.Interfaces;
using NGEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity
{
    internal static class ContextHandle
    {
        private static ContextNew Context { get; set; }
        private static readonly Dictionary<Guid, ICommand> commands = [];

        internal static void OnCreateContext(ContextNew context)
        {
            if (Context == null)
            {
                Context = context;
                CommandHandle.Register(OnCreateCommand);
                CommandHandle.Register(OnGetCommand);
                CommandHandle.Register(OnExecuteCommand);
            }
            else
                throw new ContextAlreadyExists();
        }
        private static void OnCreateCommand(ICommand command)
        {
            var contextsPerType = Context.GetContextsAlias(command.EntityType);
            if (contextsPerType.Length > 0)
            {
                foreach (string connectionAlias in contextsPerType)
                    Context.AddCommand(connectionAlias, command);
            }
            else
                commands.TryAdd(command.Identifier, command);
        }

        private static string OnGetCommand(Guid identifier, string contextAlias, IConnection connection)
        {
            if (connection != null)
                return OnGetCommand(identifier, connection);
            if (contextAlias != null)
                return OnGetCommand(identifier, contextAlias);

            return OnGetCommand(identifier);
        }
        private static string OnGetCommand(Guid identifier, string contextAlias)
        {
            if (commands.TryGetValue(identifier, out ICommand command))
                return Context.GetQuery(command, contextAlias);

            return Context.GetQuery(identifier, contextAlias);
        }
        private static string OnGetCommand(Guid identifier, IConnection connection)
        {
            if(commands.TryGetValue(identifier, out ICommand value))
                return Context.GetQuery(value, connection);

            return Context.GetQuery(identifier, connection);
        }
        private static string OnGetCommand(Guid identifier)
        {
            if (commands.ContainsKey(identifier))
                throw new CommandNotGenerated();

            return Context.GetQuery(identifier);
        }

        internal static bool OnExecuteCommand(Guid identifier, string contextAlias, IConnection connection)
        {
            if (connection != null)
                return OnExecuteCommand(identifier, connection);
            if (contextAlias != null)
                return OnExecuteCommand(identifier, contextAlias);

            return OnExecuteCommand(identifier);
        }
        private static bool OnExecuteCommand(Guid identifier, string contextAlias)
        {
            if (commands.TryGetValue(identifier, out ICommand command))
                return Context.ExecuteNonQuery(command, contextAlias);

            return Context.ExecuteNonQuery(identifier, contextAlias);
        }
        private static bool OnExecuteCommand(Guid identifier, IConnection connection)
        {
            if (commands.TryGetValue(identifier, out ICommand value))
                return Context.ExecuteNonQuery(value, connection);

            return Context.ExecuteNonQuery(identifier, connection);
        }
        private static bool OnExecuteCommand(Guid identifier)
        {
            if (commands.ContainsKey(identifier))
                throw new CommandNotGenerated();

            return Context.ExecuteNonQuery(identifier);
        }
    }
}