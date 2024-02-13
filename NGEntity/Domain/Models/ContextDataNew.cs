using System;
using System.Collections.Generic;
using NGConnection.Interfaces;

namespace NGEntity.Models
{
    internal class ContextDataNew
    {
        public string Alias { get; private set; }
        public IConnection Connection { get; private set; }
        public List<Type> Types { get; private set; }
        public List<CommandDataNew> CommandsData { get; private set; }

        internal ContextDataNew(string alias, IConnection connection, List<Type> types)
        {
            Alias = alias;
            Connection = connection;
            Types = types;
            CommandsData = [];
        }
    }
}