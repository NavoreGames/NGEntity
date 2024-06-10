using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Application.Interfaces
{
    internal interface ICommandUpdate : ICommandDml
    {
        void SetValues(IEntity entity);
    }
}
