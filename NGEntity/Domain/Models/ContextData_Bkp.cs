using System;
using System.Collections.Generic;
using NGConnection.Interfaces;
using NGEntity.Application.Interfaces;

namespace NGEntity.Models
{
    internal class ContextData_Bkp
    {
        internal IConnection Connection { get; set; }
        internal IDba Dba { get; set; }
        internal Dictionary<Guid, CommandsData_Bkp> Commands { get; set; }

        internal ContextData_Bkp() { Commands = new Dictionary<Guid, CommandsData_Bkp>(); }
        internal ContextData_Bkp(IConnection connection, IDba dba) { Commands = new Dictionary<Guid, CommandsData_Bkp>(); Connection = connection; Dba = dba; }
    }
}