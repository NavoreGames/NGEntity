using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGEntity.Domain.Models
{
    internal class ExpressionData
    {
        public ExpressionData ExpressionLeft { get; set; }
        public ExpressionType ExpressionType { get; set; }
        public ExpressionData ExpressionRight { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}
