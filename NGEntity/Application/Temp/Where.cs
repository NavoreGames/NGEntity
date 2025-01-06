using System.Linq.Expressions;
using System.Reflection;
using NGConnection.Models;

namespace NGConnection;

public class WhereTemp : Where
{

    public override void SetValues(object source)
    {
        Expression = GetExpression((Expression)source, null);
    }

    private ExpressionData GetExpression(Expression expression, MemberInfo memberInfo)
    {
        try
        {
            if (expression is LambdaExpression lambdaExpression)
                return GetExpression(lambdaExpression, memberInfo);
            if (expression is BinaryExpression binaryExpression)
                return GetExpression(binaryExpression, memberInfo);
            if (expression is MemberExpression memberExpression)
                return GetExpression(memberExpression, memberInfo);
            if (expression is ParameterExpression parameterExpression)
                return GetExpression(parameterExpression, memberInfo);
            if (expression is UnaryExpression unaryExpression)
                return GetExpression(unaryExpression, memberInfo);
            if (expression is ConstantExpression constantExpression)
                return GetExpression(constantExpression, memberInfo);
            if (expression is MethodCallExpression methodCallExpression)
                return GetExpression(methodCallExpression);
            if (expression is NewExpression newExpression)
                return GetExpression(newExpression, memberInfo);

            throw new Exception(GetTypeExpression(expression));

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private ExpressionData GetExpression(LambdaExpression expression, MemberInfo memberInfo) => GetExpression(expression.Body, memberInfo);
    protected ExpressionData GetExpression(UnaryExpression expression, MemberInfo memberInfo) => GetExpression(expression.Operand, memberInfo);
    protected ExpressionData GetExpression(BinaryExpression expression, MemberInfo memberInfo)
    {
        ExpressionData expressionData = new();

        string s = GetTypeExpression(expression.Left);
        string s1 = GetTypeExpression(expression.Right);

        expressionData.ExpressionType = expression.NodeType;
        expressionData.ExpressionLeft = GetExpression(expression.Left, memberInfo);
        expressionData.ExpressionRight = GetExpression(expression.Right, memberInfo);

        return expressionData;
    }
    private ExpressionData GetExpression(MemberExpression expression, MemberInfo memberInfo)
    {
        //members.Add(expression.Member);

        if (expression.Expression != null)
        {
            return GetExpression(expression.Expression, expression.Member);
        }
        else
        {
            //object value = expression;
            //for (int i = members.Count - 1; i >= 0; i--)
            //{
            //    if (members[i] is FieldInfo fieldInfo)
            //    {
            //        value = fieldInfo.GetValue(value);
            //    }
            //    if (members[i] is PropertyInfo propertyInfo)
            //    {
            //        value = propertyInfo.GetValue(value, null);
            //    }
            //}
            //members.Clear();

            //if (value.GetType() == typeof(string))
            //    return $"'{value}'";
            //else
            //    return value.ToString();
        }

        return default;
    }
    private ExpressionData GetExpression(ParameterExpression expression, MemberInfo memberInfo)
    {
        ExpressionData expressionData = new()
        {
            Type = memberInfo.DeclaringType,
            Value = memberInfo.Name
        };

        return expressionData;
    }
    private ExpressionData GetExpression(ConstantExpression expression, MemberInfo memberInfo)
    {
        ExpressionData expressionData = new();
        if (memberInfo == null)
        {
            expressionData.Type = expression.Type;
            expressionData.Value = expression.Value;
        }
        else
        {
            if (memberInfo is FieldInfo fieldInfo)
            {
                expressionData.Value = fieldInfo.GetValue(expression.Value);
            }
            if (memberInfo is PropertyInfo propertyInfo)
            {
                expressionData.Value = propertyInfo.GetValue(expression.Value, null);
            }
            if (memberInfo is MethodInfo methodInfo)
            {
                expressionData.Value = methodInfo.Invoke(expression.Value, null);
            }
            expressionData.Type = expressionData.Value.GetType();
        }

        return expressionData;
    }
    protected ExpressionData GetExpression(MethodCallExpression expression)
    {
        return GetExpression(expression.Object, expression.Method);
    }
    private ExpressionData GetExpression(NewExpression expression, MemberInfo memberInfo)
    {
        return GetExpression(expression, memberInfo);
    }

    private Expression GetTpe(Expression expression)
    {
        string type = expression.GetType().Name;
        return type switch
        {
            "LogicalBinaryExpression" => (BinaryExpression)expression,
            //ExpressionType.AddAssignChecked => ExpressionType.AddChecked,
            //ExpressionType.SubtractAssign => ExpressionType.Subtract,
            //ExpressionType.SubtractAssignChecked => ExpressionType.SubtractChecked,
            //ExpressionType.MultiplyAssign => ExpressionType.Multiply,
            //ExpressionType.MultiplyAssignChecked => ExpressionType.MultiplyChecked,
            //ExpressionType.DivideAssign => ExpressionType.Divide,
            //ExpressionType.ModuloAssign => ExpressionType.Modulo,
            //ExpressionType.PowerAssign => ExpressionType.Power,
            //ExpressionType.AndAssign => ExpressionType.And,
            //ExpressionType.OrAssign => ExpressionType.Or,
            //ExpressionType.RightShiftAssign => ExpressionType.RightShift,
            //ExpressionType.LeftShiftAssign => ExpressionType.LeftShift,
            //ExpressionType.ExclusiveOrAssign => ExpressionType.ExclusiveOr,
            _ => expression,
        };
    }
    private string GetTypeExpression(Expression expression)
    {
        string ret = "";
        //SetValue(expression);
        if (expression is BinaryExpression binaryExpression)
            ret = "BinaryExpression";
        else if (expression is ParameterExpression parameterExpression)
            ret = "ParameterExpression";
        else if (expression is ConstantExpression constantExpression)
            ret = "ConstantExpression";
        else if (expression is UnaryExpression unaryExpression)
            ret = "UnaryExpression";
        else if (expression is MethodCallExpression methodCallExpression)
            ret = "MethodCallExpression";
        else if (expression is MemberExpression memberExpression)
            ret = "MemberExpression";
        else if (expression is NewExpression newExpression)
            ret = "NewExpression";
        ///////tipos de expression (que não foram criados metodos, pois não apareceu ainda)
        else if (expression is BlockExpression)
            ret = "BlockExpression";
        else if (expression is ConditionalExpression)
            ret = "ConditionalExpression";
        else if (expression is DebugInfoExpression)
            ret = "DebugInfoExpression";
        else if (expression is DefaultExpression)
            ret = "DefaultExpression";
        else if (expression is DynamicExpression)
            ret = "DynamicExpression";
        else if (expression is GotoExpression)
            ret = "GotoExpression";
        //else if (expression is IArgumentProvider)
        //	s = "IArgumentProvider";
        //else if (expression is IDynamicExpression)
        //	s = "IDynamicExpression";
        else if (expression is IndexExpression)
            ret = "IndexExpression";
        else if (expression is InvocationExpression)
            ret = "InvocationExpression";
        else if (expression is LabelExpression)
            ret = "LabelExpression";
        else if (expression is LambdaExpression)
            ret = "LambdaExpression";
        else if (expression is ListInitExpression)
            ret = "ListInitExpression";
        else if (expression is LoopExpression)
            ret = "LoopExpression";
        else if (expression is MemberInitExpression)
            ret = "MemberInitExpression";
        else if (expression is NewArrayExpression)
            ret = "NewArrayExpression";
        else if (expression is RuntimeVariablesExpression)
            ret = "RuntimeVariablesExpression";
        else if (expression is SwitchExpression)
            ret = "SwitchExpression";
        else if (expression is TryExpression)
            ret = "TryExpression";
        else if (expression is TypeBinaryExpression)
            ret = "TypeBinaryExpression";

        return ret;
    }
}
