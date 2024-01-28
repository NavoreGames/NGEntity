using System;
using System.Collections.Generic;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGEntity.Interface;
using NGNotification;
using NGNotification.Enums;

namespace NGEntity
{
    public class Context
    {
        private static Dictionary<Type, ContextData> connections;
        private static Dictionary<Type, ContextData> Connections
        {
            get => IsConnectionsInitialize();
            set { connections = value; }
        }

        public Context() { Connections = new Dictionary<Type, ContextData>(); }

        private static Dictionary<Type, ContextData> IsConnectionsInitialize()
        {
            if (connections == null)
                connections = new Dictionary<Type, ContextData>();

            return connections;
        }
        private static Dba GetConnection(IConnection connection)
        {
            if (connection is NGConnection.Mysql)
                return new Mysql();
            else if (connection is NGConnection.Sqlite)
                return new Sqlite();

            return null;
        }
        internal static ContextData GetConnection(IConnectionAlias connectionName)
        {
            if (ContainsKey(connectionName))
                return Connections[connectionName.GetType()];

            return null;
        }
        internal static bool ContainsKey(IConnectionAlias connectionName)
        {
            if (Connections.ContainsKey(connectionName.GetType()) == false)
                return new Response(false, new NGMessage(Category.Warning, "Não existe uma conexão de nome: " + connectionName, "Configure a Conexão no contexto primeiramente usando Context.AddConnection(),  /r/n" +
                                                                                                                                "ou use uma conexão diferente.")).Success;

            return new Response(true).Success;
        }

        public static IConnection GetConnection<TConnectionAlias>() where TConnectionAlias : IConnectionAlias
        {
            Type connectionType = typeof(TConnectionAlias);
            if (Connections.ContainsKey(connectionType))
                return Connections[connectionType].Connection;

            return null;
        }
        public static bool AddConnection<TConnectionAlias>(IConnection connection) where TConnectionAlias : IConnectionAlias
        {
            Type connectionType = typeof(TConnectionAlias);
            if (Connections.ContainsKey(connectionType))
            {
                return new Response(false, new NGMessage(Category.Warning, @$"Já existe uma conexão de nome: {connectionType}, Você pode ter multiplas conexões do mesmo tipo, porém eles tem que conter chaves únicas. /r/n
																																Para criar novas chaves, extenda o enum ConnectionName e crie suas chaves.")).Success;
            }
            Connections.Add(connectionType, new ContextData(connection, GetConnection(connection)));

            return new Response(true).Success;
        }
        public static bool Commit()
        {

            return new Response(true).Success;
        }
    }
}
