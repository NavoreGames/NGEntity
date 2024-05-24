using NGEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Application.Interfaces
{
    internal interface ICommandInsert : ICommandDml
    {
        void SetValues(IEntity entity);
    }
}
