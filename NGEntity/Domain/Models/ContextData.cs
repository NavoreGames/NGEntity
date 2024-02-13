using System;
using System.Collections.Generic;
using NGConnection.Interfaces;
using NGEntity.Application.Interfaces;

namespace NGEntity.Models
{
    internal class ContextData
    {
        internal IConnection Connection { get; set; }
        internal IDba Dba { get; set; }
        internal Dictionary<Guid, CommandsData> Commands { get; set; }

        internal ContextData() { Commands = new Dictionary<Guid, CommandsData>(); }
        internal ContextData(IConnection connection, IDba dba) { Commands = new Dictionary<Guid, CommandsData>(); Connection = connection; Dba = dba; }
    }
}