using System.Linq.Expressions;
using System;
using NGEntity.Interfaces;

namespace NGEntity.Application.Interfaces
{
    internal interface ICommandWhere
    {
        void SetExpression(Expression expression);
    }
}
