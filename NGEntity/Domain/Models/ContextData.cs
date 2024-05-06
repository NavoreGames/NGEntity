using System;
using System.Collections.Generic;
using NGConnection.Interfaces;

namespace NGEntity.Models
{
    internal class ContextData
    {
        public string Alias { get; private set; }
        public IConnection Connection { get; private set; }
        public List<Type> Types { get; private set; }
        public List<CommandData> CommandsData { get; private set; }

        internal ContextData(string alias, IConnection connection, List<Type> types)
        {
            Alias = alias;
            Connection = connection;
            Types = types;
            CommandsData = new();
        }
    }
}