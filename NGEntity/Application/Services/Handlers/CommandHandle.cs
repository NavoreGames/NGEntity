using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity
{
    internal delegate void CreateCommandEvent(ICommand command);
    internal delegate string GetCommandEvent(Guid identifier, string contextAlias, IConnection connection);
    internal delegate bool ExecuteCommandEvent(Guid identifier, string contextAlias, IConnection connection);


    internal static class CommandHandle
    {
        private static event CreateCommandEvent OnCreateCommand;
        private static event GetCommandEvent OnGetCommand;
        private static event ExecuteCommandEvent OnExecuteCommand;

        internal static void RaiseOnCreateCommand(ICommand command)
        {
            OnCreateCommand?.Invoke(command);
        }
        internal static string RaiseOnGetCommand(Guid identifier, string contextAlias, IConnection connection)
        {
            if (OnCreateCommand != null)
                return OnGetCommand.Invoke(identifier, contextAlias, connection);

            return null;
        }
        internal static bool RaiseOnExecuteCommand(Guid identifier, string contextAlias, IConnection connection)
        {
            if (OnExecuteCommand != null)
                return OnExecuteCommand.Invoke(identifier, contextAlias, connection);

            return false;
        }

        internal static void Register(CreateCommandEvent handler) =>
            OnCreateCommand ??= handler;
        internal static void Register(GetCommandEvent handler) =>
            OnGetCommand ??= handler;
        internal static void Register(ExecuteCommandEvent handler) =>
            OnExecuteCommand ??= handler;
    }
}
