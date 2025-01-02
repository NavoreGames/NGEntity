namespace NGEntity
{
    internal class NGDba
	{
		/*
		internal Dba() {}

		public virtual ICommandDml Insert(IEntity entity) => (ICommandDml)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Insert"), default(ICommandBase)).Data;
		public virtual string SetInsert(Insert insert) => (string)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/SetInsert"), "").Data;
		public virtual ICommandDml Update(IEntity entity) => (ICommandDml)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Update"), default(ICommandBase)).Data;
		public virtual string SetUpdate(Update update) => (string)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/SetUpdate"), "").Data;
		public virtual ICommandDml Delete(IEntity entity) => (ICommandDml)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Delete"), null).Data;
		public virtual string SetDelete(Delete delete) => (string)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/SetDelete"), "").Data;
		public virtual ICommandWhere Where(IEntity entity) => (ICommandWhere)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Where"), null).Data;
		public virtual ICommandWhere Where(string expression) => (ICommandWhere)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/where"), null).Data;
		public virtual ICommandWhere Where(Expression expression) => (ICommandWhere)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Where"), null).Data;
		public virtual string SetWhere(Where where) => (string)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/SetWhere"), "").Data;
		public virtual ICommandDdl Alter(DataBase dataBase) => (ICommandDdl)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/Alter"), default(ICommandBase)).Data;


		protected string GetExpression(Expression expression, List<MemberInfo> members)
		{
			string ret = "";

			if (expression is BinaryExpression binaryExpression)
				ret = GetExpression(binaryExpression, members);
			else if (expression is ParameterExpression parameterExpression)
				ret = GetExpression(parameterExpression, members);
			else if (expression is ConstantExpression constantExpression)
				ret = GetExpression(constantExpression, members);
			else if (expression is UnaryExpression unaryExpression)
				ret = GetExpression(unaryExpression, members);
			else if (expression is MethodCallExpression methodCallExpression)
				ret = GetExpression(methodCallExpression, members);
			else if (expression is MemberExpression memberExpression)
				ret = GetExpression(memberExpression, members);
			else if (expression is NewExpression newExpression)
				ret = GetExpression(newExpression, members);
			#region tipos de expression (que não foram criados metodos, pois não apareceu ainda)
			else
			{
				if (expression is BlockExpression)
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

				return (string)new Response(false, 400, new NGMessage(Category.Error, $"Expression {ret} não implementada"), "").Data;
			}
			#endregion

			return ret;
		}
		protected string GetExpression(BinaryExpression expression, List<MemberInfo> members)
		{
			string ret = "";
			ret += GetExpression(expression.Left, members);
			ret += Generic.GetOperation(expression.NodeType);
			ret += GetExpression(expression.Right, members);

			return ret;
		}
		protected static string GetExpression(ParameterExpression expression, List<MemberInfo> members)
		{
			if (expression is null)
				return (string)new Response(false, 400, new NGMessage(Category.Warning, $"Expression ParameterExpression é nula"), "").Data;

			string ret = "";
			for (int i = members.Count - 1; i >= 0; i--)
			{
				ret = $"{members[i].DeclaringType.Name}.{members[i].Name}";
			}
			members.Clear();

			return ret;
		}
		protected static string GetExpression(ConstantExpression expression, List<MemberInfo> members)
		{
			object value = expression.Value;
			for (int i = members.Count - 1; i >= 0; i--)
			{
				if (members[i] is FieldInfo fieldInfo)
				{
					value = fieldInfo.GetValue(value);
				}
				if (members[i] is PropertyInfo propertyInfo)
				{
					value = propertyInfo.GetValue(value, null);
				}
				if (members[i] is MethodInfo methodInfo)
				{
					value = methodInfo.Invoke(value, null);
				}
			}
			members.Clear();

			if (value.GetType() == typeof(string))
				return $"'{value}'";
			else
				return value.ToString();
		}
		protected string GetExpression(UnaryExpression expression, List<MemberInfo> members)
		{
			return GetExpression(expression.Operand, members);
		}
		protected string GetExpression(MethodCallExpression expression, List<MemberInfo> members)
		{
			members.Add(expression.Method);
			return GetExpression(expression.Object, members);
		}
		protected string GetExpression(MemberExpression expression, List<MemberInfo> members)
		{
			members.Add(expression.Member);

			if (expression.Expression != null)
			{
				return GetExpression(expression.Expression, members);
			}
			else
			{
				object value = expression;
				for (int i = members.Count - 1; i >= 0; i--)
				{
					if (members[i] is FieldInfo fieldInfo)
					{
						value = fieldInfo.GetValue(value);
					}
					if (members[i] is PropertyInfo propertyInfo)
					{
						value = propertyInfo.GetValue(value, null);
					}
				}
				members.Clear();

				if (value.GetType() == typeof(string))
					return $"'{value}'";
				else
					return value.ToString();
			}
		}
		protected string GetExpression(NewExpression expression, List<MemberInfo> members)
		{
			return GetExpression(expression, members);
		}
		*/
	}
}
