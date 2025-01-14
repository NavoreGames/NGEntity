﻿using NGConnection.Enums;
using NGConnection;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity.Models;

namespace NGEntity;

public class TableCreate : CommandData, ITableCreate
{
    internal TableCreate(Guid Identifier) : base(Identifier) { }

    public bool Execute(IConnection connection) => new CommandCommit(Identifier).Execute(connection);
    public bool Execute(string contextAlias) => new CommandCommit(Identifier).Execute(contextAlias);
    public bool Execute() => new CommandCommit(Identifier).Execute();

    public IColumnAdd CreateTable(string name, string alias)
    {
        DataBase dataBase =
            (DataBase)Context.
                GetCommands(Identifier)
                    .Where(w => w is DataBase)?
                    .FirstOrDefault();

        Table table = new Table(Identifier, DdlCommandType.Create, dataBase, name, alias);
        Context.AddCommand(table);

        return new ColumnAdd(Identifier);
    }
    public IColumnAdd CreateTable(string name) => CreateTable(name, "");
}
