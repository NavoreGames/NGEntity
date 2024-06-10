namespace NGEntity
{
    internal abstract class Dbo : Dba
	{
		/*
		public override ICommandDml Insert(IEntity entity)
		{
			if (entity != null)
			{
				PropertyInfo[] propertyInfos;
				Insert insert = new Insert();

				propertyInfos = entity.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
				insert.TableName = entity.GetType().Name;
				insert.Fields.AddRange(propertyInfos.Select(s => s.Name));
				insert.Values
					.AddRange(
						propertyInfos
							.Select(s => (s.GetCustomAttributes().Any(a => a.GetType() == typeof(FieldsAttributes))) ?
										(
											(VariableType.String == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type ||
											VariableType.DateTime == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////if
												(s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
													(VariableType.Bool == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////// else if
															(s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
															(s.GetValue(entity) ?? "null").ToString()  ////////// else
										) :
										(
											(VariableType.String == Generic.GetVariableType(s.GetType().ToString()) ||
											VariableType.DateTime == Generic.GetVariableType(s.GetType().ToString())) ? ////if
												(s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
													(VariableType.Bool == Generic.GetVariableType(s.GetType().ToString())) ? ////// else if
															(s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
															(s.GetValue(entity) ?? "null").ToString()  ////////// else
										)
									)
							);
				/////////  MONTA O COMANDO   /////////////////////////////////////////////////
				insert.Command = SetInsert(insert);

				return insert;
			}

			return null;
		}
		public override string SetInsert(Insert insert) 
		{
			return @$"
			INSERT INTO {insert.TableName}
			({string.Join(", ", insert.Fields)})
			VALUES
			({string.Join(", ", insert.Values)})";
		}
		public override ICommandDml Update(IEntity entity)
		{
			if (entity != null && entity.CommandFields.Any(a => a.Value == Enum.CommandType.Update))
			{
				PropertyInfo[] propertyInfos;
				Update update = new Update();

				propertyInfos = entity.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
				update.TableName = entity.GetType().Name;
				update.Fields.AddRange(entity.CommandFields.Where(w => w.Value == Enum.CommandType.Update).Select(s => s.Key));
				update.Values
					.AddRange(
						propertyInfos
							.Where(w => update.Fields.Any(a => a == w.Name))
							.Select(s => (s.GetCustomAttributes().Any(a => a.GetType() == typeof(FieldsAttributes))) ?
										(
											(VariableType.String == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type ||
											VariableType.DateTime == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////if
												(s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
													(VariableType.Bool == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////// else if
															(s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
															(s.GetValue(entity) ?? "null").ToString()  ////////// else
										) :
										(
											(VariableType.String == Generic.GetVariableType(s.GetType().ToString()) ||
											VariableType.DateTime == Generic.GetVariableType(s.GetType().ToString())) ? ////if
												(s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
													(VariableType.Bool == Generic.GetVariableType(s.GetType().ToString())) ? ////// else if
															(s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
															(s.GetValue(entity) ?? "null").ToString()  ////////// else
										)
									)
							);

				for (int i = 0; i < update.Fields.Count; i++)
					update.Set.Add(update.Fields[i] + "=" + update.Values[i]);

				update.Command = SetUpdate(update);

				return update;
			}

			return null;
		}
		public override string SetUpdate(Update update)
		{
			return @$"
			UPDATE {update.TableName}
			SET {String.Join(", ", update.Set)} ";
		}
		public override ICommandDml Delete(IEntity entity)
		{
			if (entity != null)
			{
				Delete delete = new Delete() { TableName = entity.GetType().Name };
				/////////  MONTA O COMANDO   /////////////////////////////////////////////////
				delete.Command = SetDelete(delete);

				return delete;
			}

			return null;
		}
		public override string SetDelete(Delete delete)
		{
			return @$"DELETE FROM {delete.TableName}";
		}
		//public ICommands Select(Expression expression)
		//{
		//	Select select = new Select
		//	{
		//		CommandType = CrossCutting.Enum.CommandType.Select
		//	};
		//	CommandExpression commandExpression = new CommandExpressionSelect();
		//	string s = commandExpression.GetExpression(expression, new List<MemberInfo>());

		//	return default;
		//}
		public override ICommandWhere Where(IEntity entity)
		{
			if (entity != null)
			{
				PropertyInfo[] propertyInfos;
				Where where = new Where();

				propertyInfos = entity.GetType().GetProperties().Where(w => w.GetCustomAttributes().Any(a => a.GetType() == typeof(FieldsAttributes)) && w.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().Any(a => a.Key == Key.Pk))?.ToArray();
				if (propertyInfos != null && propertyInfos.Length > 0)
				{
					where.Fields.AddRange(propertyInfos.Select(s => s.Name));
					where.Values
						.AddRange(
							propertyInfos
								.Select(s =>
											(
												(VariableType.String == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type ||
												VariableType.DateTime == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////if
													(s.GetValue(entity) == null) ? "null" : "'" + s.GetValue(entity) + "'" :
														(VariableType.Bool == s.GetCustomAttributes(typeof(FieldsAttributes)).Cast<FieldsAttributes>().FirstOrDefault().Type) ? ////// else if
															 (s.GetValue(entity) == null) ? "null" : (((bool)s.GetValue(entity) == true) ? 1 : 0).ToString() :
																(s.GetValue(entity) ?? "null").ToString()  ////////// else
											)
										)
								);
					for (int i = 0; i < where.Fields.Count; i++)
						where.Clause.Add(where.Fields[i] + "=" + where.Values[i]);

					where.Command = SetWhere(where);

					return where;
				}
			}

			return null;
		}
		public override ICommandWhere Where(string expression)
		{
			if (expression.Trim() != "")
			{
				Where where = new Where() { Clause = new List<string>() { expression.ToUpper().Replace("WHERE", "") } };
				where.Command = SetWhere(where);
				return where;
			}

			return null;
		}
		public override ICommandWhere Where(Expression expression)
		{
			if (expression != null)
			{
				Where where = new Where() { Clause = new List<string>() { GetExpression(expression, new List<MemberInfo>()) } };
				where.Command = SetWhere(where);
				return where;
			}
			return null;
		}
		public override string SetWhere(Where where)
		{
			return @$"
			WHERE {String.Join(" AND ", where.Clause)}";
		}
		*/
	}
}