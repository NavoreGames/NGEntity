using System;
using System.Collections.Generic;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGEntity.Models;
using NGEntity.Interfaces;
using NGNotification;
using NGNotification.Enums;
using System.Linq;
using NGEntity.Exceptions;

namespace NGEntity
{
    public static class Context
    {
        internal static List<ContextData> ContextDataNews { get; private set; }
        private static List<ContextData> IsContextDataInitialize()
        {
            if (ContextDataNews == null)
                ContextDataNews = new();

            return ContextDataNews;
        }
        internal static string[] GetAlias(Type type)
        {
            string[] retorno = IsContextDataInitialize().Where(w => w.Types.Contains(type)).Select(s => s.Alias).ToArray();

            if (retorno.Length <= 0)
                throw new TypeNotExistInContext($"type {type} not exists in any context");

            return retorno;
        }
        internal static ContextData GetContext(Type type)
        {
            if (!IsContextDataInitialize().SelectMany(s => s.Types).Any(a => a.Equals(type)))
                throw new TypeNotExistInContext($"type {type} not exists in any context");

            return IsContextDataInitialize().Where(w=> w.Types.Contains(type)).FirstOrDefault();
        }
        internal static ContextData GetContext(string alias)
        {
            if(!IsContextDataInitialize().Any(a => a.Alias == alias))
                throw new ContextNotExists($"Context with alias {alias} not exists");

            return IsContextDataInitialize().Where(w=> w.Alias == alias).FirstOrDefault();
        }

        public static void AddContext(string alias, IConnection connection, params IEntity[] entities)
        {
            List<Type> types = new();
            foreach (var entity in entities) { types.Add(entity.GetType()); }

            if(IsContextDataInitialize().Any(a => a.Alias == alias))
                throw new ContextAlreadyExists($"Context with alias {alias} already exists");

            IsContextDataInitialize().Add(new ContextData(alias, connection, types));
        }



            //private static Dictionary<Type, ContextData> connections;
            //private static Dictionary<Type, ContextData> Connections
            //{
            //    get => IsConnectionsInitialize();
            //    set { connections = value; }
            //}

            //public ContextNew() { Connections = new Dictionary<Type, ContextData>(); }


            /*
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

                return true;
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

                return true;
            }
            public static bool Commit()
            {

                return new Response(true).Success;
            }
            */
        }
}
