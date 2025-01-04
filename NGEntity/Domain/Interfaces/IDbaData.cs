using NGConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Interfaces
{
    public interface IDbaData
    {
       string ToString(IConnection connection) { return default; }
       string ToString(string connectionAlias) { return default; }

       string ToObject() { return default; }
       string ToObject(IConnection connection) { return default; }
       string ToObject(string connectionAlias) { return default; }
    }
}
