using System.Collections.Generic;
using System.Linq;
using NGEntity.Domain;
using NGEntity.Enum;
using NGEntity.Interface;
using NGEntity.Models;


namespace NGEntity
{
	internal class Mysql : Dbo
	{
		public override ICommandDdl Alter(DataBase dataBase)
		{
			string command = "";
			string pk = "";
			List<string> fk;
			List<string> unique;
			CommandDdl alter = new CommandDdl(dataBase);

			#region CREATE TABLE
			dataBase
				.Tables
				.Where(w => w.CommandType.Equals(CommandType.Insert))
				.ToList()
				.ForEach(
					loopTables =>
					{
						pk = "";
						fk = new List<string>();
						unique = new List<string>();

						//////////  MONTA O COMANDO EM UMA STRING  //////////////////////////
						command += "CREATE TABLE IF NOT EXISTS " + loopTables.TableName.ToString() + "( \r\n";
						foreach (Column loopColumns in loopTables.Columns)
						{
							/////// ADICIONA A UMA STRING AS COLUNAS QUE SERAM PK //////////
							if (loopColumns.Key.Equals(Key.Pk))
								pk += loopColumns.ColumnName.ToString() + ", ";
							/////// ADICIONA A UMA LISTA DE STRING AS COLUNAS QUE SERAM FK //////////
							if (loopColumns.Key.Equals(Key.Fk))
								fk.Add(loopColumns.ColumnName.ToString());
							/////// ADICIONA A UMA STRING AS COLUNAS QUE SERAM UNIQUE //////////
							if (loopColumns.Key.Equals(Key.Unique))
								unique.Add(loopColumns.ColumnName.ToString());

							///////////  ADICIONA AS COLUNAS DA TABELA  ///////////////////////
							command += "	" + loopColumns.ColumnName.ToString() + " " + loopColumns.Type.ToString();
							if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
								command += "(" + loopColumns.Length.ToString() + ")";

							command += (loopColumns.NotNull == true) ? " NOT NULL" : " NULL";
							command += (loopColumns.Autoincrement == true) ? " AUTO_INCREMENT" : "";

							command += ", \r\n";
						}
						//////  ADICIONA O COMANDO PARA CRIAR A PK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
						if (pk.Trim() != "")
						{
							pk = pk.Remove(pk.LastIndexOf(','), 1).Trim();
							command += "	PRIMARY KEY (" + pk + ")";
						}
						//////  ADICIONA O COMANDO PARA CRIAR A fK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
						if (unique.Count > 0)
						{
							foreach (string loopUnique in unique)
							{
								command += ", \r\n";
								command += "	CONSTRAINT " + loopTables.TableName.ToString() + loopUnique + " UNIQUE KEY(" + loopUnique + ")";
							}
						}
						//////  ADICIONA O COMANDO PARA CRIAR A fK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
						if (fk.Count > 0)
						{
							foreach (string loopFk in fk)
							{
								command += ", \r\n";
								command += "	CONSTRAINT " + loopTables.TableName.ToString() + loopFk + " FOREIGN KEY(" + loopFk + ") \r\n";
								command += "		REFERENCES " + loopFk.Replace("Fk", "") + "(" + loopFk.Replace("Fk", "Id") + ") \r\n";
								command += "			ON UPDATE CASCADE \r\n";
								command += "			ON DELETE CASCADE";
							}
						}
						command += "\r\n); \r\n\r\n";
					}
				);
			#endregion

			#region ALTER TABLE
			dataBase
				.Tables
				.Where(w => w.CommandType.Equals(CommandType.Alter))
				.ToList()
				.ForEach(
					loopTables =>
					{
						#region ALTER TABLE NAME
						if (loopTables.AlterTableName.Equals("") == false)
						{
							command += "ALTER TABLE " + loopTables.TableName.ToString() + "\r\n";
							command += "	RENAME " + loopTables.AlterTableName + "; \r\n";
							//loopTables.TableName = loopTables.AlterTableName;
						}
						#endregion

						#region ADD COLUMN
						if (loopTables.Columns.Any(a => a.CommandType.Equals(CommandType.Insert)) == true)
						{
							command += "ALTER TABLE " + loopTables.TableName.ToString() + "\r\n";

							loopTables.Columns
								.Where(w1 => w1.CommandType.Equals(CommandType.Insert))
								.ToList()
								.ForEach(
									loopColumns =>
									{
										command += "	ADD " + loopColumns.ColumnName + " " + loopColumns.Type.ToString() + " ";
										if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
											command += "(" + loopColumns.Length.ToString() + ") ";

										command += (loopColumns.NotNull == true) ? "NOT NULL " : "NULL ";
										command += ", \r\n";
									}
								);
							command = command.Remove(command.LastIndexOf(','), 1);
							command += "; \r\n";
						}
						#endregion

						#region ALTER COLUMN
						loopTables.Columns
							.Where(w1 => w1.CommandType.Equals(CommandType.Alter))
							.ToList()
							.ForEach(
								loopColumns =>
								{
									if (loopColumns.AlterColumnName.Equals("") == false) //// ALTERA NOME DA COLUNA
									{
										command += "ALTER TABLE " + loopTables.TableName.ToString() + "\r\n";
										command += "	CHANGE COLUMN " + loopColumns.ColumnName + " " + loopColumns.AlterColumnName + " " + loopColumns.Type.ToString() + " ";
										if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
											command += "(" + loopColumns.Length.ToString() + ") ";

										command += (loopColumns.NotNull == true) ? "NOT NULL " : "NULL ";
										command += "; \r\n";
									}
									else  //// ALTERA OS ATRIBUTOS DA COLUNA
									{
										command += "ALTER TABLE " + loopTables.TableName.ToString() + "\r\n";
										command += "	MODIFY  " + loopColumns.ColumnName + " " + loopColumns.Type.ToString() + " ";
										if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
											command += "(" + loopColumns.Length.ToString() + ") ";

										command += (loopColumns.NotNull == true) ? "NOT NULL " : "NULL ";
										command += "; \r\n";
									}
								}
							);
						#endregion

						#region DELETE COLUMN
						loopTables.Columns
							.Where(w1 => w1.CommandType.Equals(CommandType.Delete))
							.ToList()
							.ForEach(
								loopColumns =>
								{
									command += "ALTER TABLE " + loopTables.TableName.ToString() + "\r\n";
									command += "	DROP COLUMN " + loopColumns.ColumnName + "; \r\n";
								}
							);
						#endregion
					}
				);
			#endregion

			#region DELETE TABLE
			dataBase
				.Tables
				.Where(w => w.CommandType.Equals(CommandType.Delete))
				.ToList()
				.ForEach(
					loopTables =>
					{
						command += "DROP TABLE IF EXISTS " + loopTables.TableName.ToString() + "; \r\n";
					}
				);
			#endregion

			alter.Command = command;

			return alter;
		}
	}
}
