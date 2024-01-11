using System.Collections.Generic;
using System.Linq;
using NGEntity.Domain;
using NGEntity.Enum;
using NGEntity.Interface;
using NGEntity.Models;

namespace NGEntity
{
	internal class Sqlite : Dbo
	{
		public override ICommandDdl Alter(DataBase dataBase)
		{
			string command = "";
			string pk = "";
			List<string> fk;
			string unique;
			int countPrimary = 0;
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
							unique = "";
							countPrimary = loopTables.Columns.Count(c => c.Key != Key.None && c.Key.Equals(Key.Pk) == true);
							//////////  MONTA O COMANDO EM UMA STRING  //////////////////////////
							command += "CREATE TABLE IF NOT EXISTS " + loopTables.TableName.ToString() + "(";
							foreach (Column loopColumns in loopTables.Columns)
							{
								command += "\r\n";
								/////// ADICIONA A UMA STRING AS COLUNAS QUE SERAM PK //////////
								if (loopColumns.Key.Equals(Key.Pk))
									pk += loopColumns.ColumnName.ToString() + ", ";
								/////// ADICIONA A UMA LISTA DE STRING AS COLUNAS QUE SERAM FK //////////
								if (loopColumns.Key.Equals(Key.Fk))
									fk.Add(loopColumns.ColumnName.ToString());
								/////// ADICIONA A UMA STRING AS COLUNAS QUE SERAM UNIQUE //////////
								if (loopColumns.Key.Equals(Key.Unique))
									unique += loopColumns.ColumnName.ToString() + ", ";

								///////////  ADICIONA AS COLUNAS DA TABELA  ///////////////////////
								command += "	" + loopColumns.ColumnName.ToString() + " " + ((loopColumns.Type.Equals(VariableType.Int)) ? "Integer" : loopColumns.Type.ToString());
								if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
									command += "(" + loopColumns.Length.ToString() + ")";

								if (countPrimary > 1 || loopColumns.Key.Equals(Key.None))
								{
									command += (loopColumns.NotNull == true) ? " NOT NULL" : " NULL";
								}
								else if (loopColumns.Key.Equals(Key.Pk))
								{
									command += " PRIMARY KEY";
									command += (loopColumns.Autoincrement == true) ? " AUTOINCREMENT" : "";
								}

								command += ",";
							}
							command = command.Remove(command.LastIndexOf(','), 1).Trim();
							//////  ADICIONA O COMANDO PARA CRIAR A PK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
							if (countPrimary > 1 && pk.Trim() != "")
							{
								pk = pk.Remove(pk.LastIndexOf(','), 1).Trim();
								command += ", \r\n";
								command += "	PRIMARY KEY (" + pk + ")";
							}
							//////  ADICIONA O COMANDO PARA CRIAR A fK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
							if (unique.Trim() != "")
							{
								unique = unique.Remove(unique.LastIndexOf(','), 1).Trim();
								command += ", \r\n";
								command += "	UNIQUE (" + unique + ")";
							}
							//////  ADICIONA O COMANDO PARA CRIAR A fK COM AS COLUNAS QUE FORAM ADD ACIMA  ////////////
							if (fk.Count > 0)
							{
								foreach (string loopFk in fk)
								{
									command += ", \r\n";
									command += "	CONSTRAINT " + loopFk + " FOREIGN KEY(" + loopFk + ") \r\n";
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
							command += "	RENAME TO " + loopTables.AlterTableName + "; \r\n";
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
										command += "	ADD COLUMN " + loopColumns.ColumnName + " " + loopColumns.Type.ToString() + " ";
										if (loopColumns.Type.Equals(VariableType.Varchar) || loopColumns.Type.Equals(VariableType.String))
											command += "(" + loopColumns.Length.ToString() + ") ";

										command += (loopColumns.NotNull == true) ? "NOT NULL DEFAULT " + ((loopColumns.Type.Equals(VariableType.String)) ? "\"\"" : (loopColumns.Type.Equals(VariableType.Bool)) ? "false" : "0") : "NULL ";
										command += ", \r\n";
									}
								);
							command = command.Remove(command.LastIndexOf(','), 1);
							command += "; \r\n";
						}
							#endregion

						/////////////////////////////////////////////////////////
						/////  SQLITE NÃO SUPORTA ALTERAR E DELETAR COLUNAS  //////
						/////  PARA FAZER ISSO TEM QUE CRIAR OUTRA TABELA,  //////
						/////  COPIAR OS DADOS DA ANTIGA TABELA, E DELETAR A ANTIGA ////
						/////  TEM QUE FAZER, AINDA NÃO FOI FEITO (PREGUIÇA!!!!!) /////
						///
						#region ALTER COLUMN
						loopTables.Columns
						.Where(w1 => w1.CommandType.Equals(CommandType.Alter) || w1.CommandType.Equals(CommandType.Delete))
						.ToList()
						.ForEach(
							loopColumns =>
							{
								/////// AQUI VAI OS PASSO CITADOS ACIMA  //////////////
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
