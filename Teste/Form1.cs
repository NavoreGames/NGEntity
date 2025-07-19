using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using NGConnection;
using NGConnection.Enums;
using NGEntity;
using NGEntity.Domain;
using NGConnection.Models;
using System.Runtime.CompilerServices;
using NGEntity.Interfaces;
using System.DirectoryServices.ActiveDirectory;

namespace Teste
{
    public partial class Form1 : Form
    {
        const string LOCAL = "Local";
        const string SERVER = "Server";

        const string IpAddress = "0.0.0.0";
        const string DataBaseName = "YourDataBase";
        const string UserName = "UserName";
        const string Password = "********";
        const string TimeOut = "30";

        Sqlite sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
        Mysql mysql = new Mysql(IpAddress, DataBaseName, UserName, Password);


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Teste();
                //ExecuteInsert();
                //ExecuteEntitysCommands();
                //CreateDataBaseFromCode();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Teste()
        {
            ContextNew contextNew = new ContextNew();
            //ContextNew contextNew1 = new ContextNew();
            contextNew.AddContext(LOCAL, sqlite, new User());
            //contextNew.AddContext(SERVER, mysql, new User());

            User user = new() { IdUser = 1, Email = "will@will.com", Name = "willian", Flag = false };
            User User1 = new() { IdUser = 1, Email = "w@w.com", Name = "will", Flag = false };

            //var v = Address.Inserts(new Address()).ToString(sqlite);
            var v1 = user.Insert().ToString();

            //string erro;
            //User user = null;
            //if (user.Existe() is (false, var mensagem))
            //    erro = mensagem;
        }

        public void CreateDataBaseFromCode()
        {
            Sqlite sqlite = new("IpAddress", "DataBaseName", "UserName", "Password");

            Context.AddContext(LOCAL, sqlite);
            //Context.AddContext(SERVER, new Mysql("", "", "", ""), new User());

            //Context.AddContext(SERVER, new Http("", "", "", ""));

            var v = Dba
                .CreateDataBase("DataBaseTest")
                    .CreateTable("Usr001", "User")
                    //    .AddColumn("UsrId", "UserId", Key.Pk, VariableType.Bigint, true)
                    //.CreateTable("Adr002", "Adress")
                    //.ToString(sqlite);
                    .Execute();


        }
        public void CreateModelsFromDataBase()
        {

        }
        private void ExecuteInsert()
        {
            //Context.AddContext(LOCAL, sqlite, new User());
            //Context.AddContext(SERVER, new Mysql("", "", "", ""),new User());
            Context.PrintCommandsInConsole = true;
            Context.BeginTransaction();

            User user = new() { IdUser = 1, Email = "will@will.com", Name = "willian", Flag = false };
            User User1 = new() { IdUser = 1, Email = "w@w.com", Name = "will", Flag = false };
            //var v1 = User.Inserts(user, User1).ToString();
            //var v2 = user.Insert().ToString(SERVER);
            //var v3 = user.Insert().ToString(sqlite);

            var v = user.Insert().ToString();
            //user.Insert().Execute(LOCAL);
            //user.Insert().Execute(sqlite);

            Context.RollbackTransaction();
            //Context.CommitTransaction();
        }

        private void ExecuteEntitysCommands()
        {
            int id = 2;

            TesteEntidade teste = new() { Test = "dfsd" };

            User user = new() { IdUser = 1, Email = "will@will.com", Name = "willian", Flag = false };
            user.Name = "will";
            User user2 = new() { IdUser = 2, Email = "will1@will1.com", Name = "will", Flag = false };
            Address address = new() { IdAddress = null, Street = "Street" };

            Sqlite sqlite = new("IpAddress", "DataBaseName", "UserName", "Password");

            Context.AddContext(LOCAL, sqlite);
            Context.AddContext(SERVER, new Mysql("", "", "", ""), new User());

            string s = User.Inserts(user).ToString();
            //user.Insert();
            //user.Insert().Execute();
            //user.Insert().Execute(LOCAL);
            //user.Insert().Execute(sqlite);

            //user.Update().Execute();
            s = User.Updates(new User() { Name = "Updade", Email = "update@update.com" }).Where(w => w.IdUser == 1 && (w.Name == "Will" || w.Flag == false)).ToString();
            //User.Updates(new User() { Name = "Updade", Email = "update@update.com" }).Where(w => w.Name.Contains("Will")).Execute();

            user.Delete().Execute();
            User.Deletes().Where(w => 1 == 1).Execute();

            User.Selects().Execute();
            User.Selects().Where(w => w.IdUser == 1).Execute();
            User.Selects(s => new { s.IdUser, s.Email }).Where(w => w.IdUser == 1).Execute();
            User
                .Selects()
                    .InnerJoin<Address>((user, address) => user.FkAddress == address.IdAddress)
                    .InnerJoin<Address, Subtitle>((address, subtitle) => address.IdAddress == subtitle.IdSubtitle)
                .Where((user, address, subtitle) => user.IdUser == 1 && address.IdAddress == 1)
                .Execute();

            User
                .Selects()
                    .InnerJoin<Subtitle>((j1, j2) => j1.IdUser == j2.FkLanguage && j2.IdSubtitle > 0)
                    .InnerJoin<Address>((j1, j2) => j1.FkAddress == j2.IdAddress)
                    .InnerJoin<Subtitle, Address>((j1, j2) => j1.FkLanguage == j2.IdAddress)
                .Execute();

            //User.Selects().Include(x => x.Address);
            //User.Selects().Include(x => x.Addresses);

            ///==================== INSERTS ====================////////
            //         ///// não verifica se a entidade e vazio ou valores padrão (não sei se devo verificar)
            //         User.Insert(new User());
            /////// pode inserir varias entidades de uma vez
            //User.Insert(new User(), new User(), new User());
            /////// pode inserir as entidades com esse tipo de inicialização, ou com construtores se a entidade tiver construtores para as propriedades
            //User.Insert(new User() { IdUser = 1, Email = "will@will.com", Name = "willian", Flag = false });
            /////// pode inserir entidades passando as entidades que foram instanciadas previamente
            //User.Insert(user);
            /////// pode inserir entidades previamente instanciadas, porém assim só dá para iserir uma por vez, pois irá inserir apenas a entidade instanciada
            //user.Insert();

            ///// ao referenciar a entidade no inicio, não pode ser inseridas entidades diferentes no parametro do insert.
            ///// ocorrerá um erro no compilador.
            //Usuario.SetConnections(ConnectionName.Sqlite).Insert(new Subtitle());
            ////// para inserir varias entidades diferentes, use a referencia Entity
            //Entity.Insert(new Usuario(), new Subtitle());
            //Entity.Contexts(LOCAL).Insert(new Usuario(), new Subtitle());

            //Usuario.Contexts(LOCAL).Insert(User);
            //User.Context(SERVER).Insert();

            ///////==================== UPDATES ====================////////
            /////// para fazer update use o comando.
            //User.Updates(new User() { IdUser = 5, Email = "will@will.com", Name = "willian", Flag = false });
            /////// pode fazer o update apenas dos campos necessarios.
            //User.Updates(new User() { IdUser = 5, Email = "will@will.com" });
            /////// o processo tentará verificar o id da sua entidade, se a sua entidade conter o comando costimizado da propriedade (exemplo abaixo)
            ///////[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
            /////// e a propriedade do id também tem que ser declarada na inicialização.
            //User.Updates((User)new() { IdUser = 5, Email = "will@will.com" });
            /////// caso o processo não encontrar o id automaticamente, você tem que usar o comando Where
            /////// o comando where pode ser declarado com uma expressão lambda eu uma expressão string
            //User.Updates(new() { Email = "will@will.com" }).Where(w => w.IdUser == 2);
            /////// caso o comando update não tenha nenhum comando where, o update não será criado, 
            /////// consequentemente não realizando nenhum tipo de alteração no banco.
            /////// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
            //User.Updates((User)new() { Email = "will@will.com" });
            /////// o comando update também não será criado se a entidade passada não conter nenhum tipo de alteração
            /////// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
            //User.Updates((User)new());
            /////// pode fazer update de entidades previamente instanciadas
            /////// o princípio de não conter where ou da entidade sem alteração também se aplicam aqui
            //user.Update();



            //         //ExecuteCoroutine(() => { return CreateDataBaseFromCode(); }); 
            //         //ExecuteCoroutine(CreateDataBaseFromCode);
            //         ExecuteCoroutine(() => CreateDataBase());
            //ExecuteCoroutine(CreateDataBase);

            //Context.AddConnection<ConnectionSqlite>(new Sqlite("", "", "", ""));

            //Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where(w => (w.IdUser == 1 && w.Email == "") || w.Flag == false);

            /////**************** INSERTS *************////////
            /////// não verifica se a entidade e vazio ou valores padrão (não sei se devo verificar)
            //Usuario.Insert<ConnectionSqlite>(new Usuario());
            /////// pode inserir varias entidades de uma vez
            //Usuario.Insert<ConnectionSqlite>(new Usuario(), new Usuario(), new Usuario());
            /////// pode inserir as entidades com esse tipo de inicialização, ou com construtores se a entidade tiver construtores para as propriedades
            //Usuario.Insert<ConnectionSqlite>(new Usuario() { IdUser = 1, Email = "will@will.com", UserName = "willian", Flag = false });
            /////// pode inserir entidades passando as entidades que foram instanciadas previamente
            //Usuario.Insert<ConnectionSqlite>(User);
            /////// pode inserir entidades previamente instanciadas, porém assim só dá para iserir uma por vez, pois irá inserir apenas a entidade instanciada
            //User.Insert<ConnectionSqlite>();
            /////// ao referenciar a entidade no inicio, não pode ser inseridas entidades diferentes no parametro do insert.
            /////// ocorrerá um erro no compilador.
            ////Usuario.SetConnections(ConnectionName.Sqlite).Insert(new Subtitle());
            //////// para inserir varias entidades diferentes, use a referencia Entity
            //Entity.Insert<ConnectionSqlite>(new Usuario(), new Subtitle());

            //         /////**************** UPDATES *************////////
            //         ///// para fazer update use o comando.
            //         Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com", UserName = "willian", Flag = false });
            /////// pode fazer o update apenas dos campos necessarios.
            //Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com" });
            /////// o processo tentará verificar o id da sua entidade, se a sua entidade conter o comando costimizado da propriedade (exemplo abaixo)
            ///////[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
            /////// e a propriedade do id também tem que ser declarada na inicialização.
            //Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com" });
            /////// caso o processo não encontrar o id automaticamente, você tem que usar o comando Where
            /////// o comando where pode ser declarado com uma expressão lambda eu uma expressão string
            //Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where(w => w.IdUser == 2);
            //Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where("IdUser == 2");
            /////// caso o comando update não tenha nenhum comando where, o update não será criado, 
            /////// consequentemente não realizando nenhum tipo de alteração no banco.
            /////// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
            //Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" });
            /////// o comando update também não será criado se a entidade passada não conter nenhum tipo de alteração
            /////// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
            //Usuario.Update<ConnectionSqlite>(new());
            /////// pode fazer update de entidades previamente instanciadas
            /////// o princípio de não conter where ou da entidade sem alteração também se aplicam aqui
            //User.Update<ConnectionSqlite>();

            ///////**************** DELETE *************////////
            //Usuario.Delete<ConnectionSqlite>().Where(w => w.IdUser == 1);
            //Usuario.Delete<ConnectionSqlite>(User);
            //User.Delete<ConnectionSqlite>();

            ///////**************** SELECT *************////////
            /////// para fezer select apenas da entidade e de todas as colunas usar o comando abaixo, com ou sem o comando where 
            //Usuario.Select<ConnectionSqlite>();
            //Usuario.Select<ConnectionSqlite>().Where(w => w.IdUser > 0);
            /////// para fezer select apenas da entidade e com colunas especificas usar o comando abaixo, com ou sem o comando where 
            //Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, s.Email });
            //Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = s.Flag });
            //Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = s.Flag }).Where(w => w.Email != "");
            /////// para fazer um select com join, use a referencia Entity.
            /////// use o comando select, a primeira referencia será a entidade principal do select e a segunda referencia será o retorno sempre um IDto
            ////Entity.SetConnections(ConnectionName.Sqlite).Select<Usuario, UsuarioDto>().InnerJoin<Usuario, Subtitle>((j1, j2) => j1.IdUser == j2.FkLanguage && j2.IdSubtitle > 0);
            /////// ver uma forma de fazer subselect //////////////////////
            ////Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = (Subtitle.Select<ConnectionSqlite>(s1 => new { s1.IdSubtitle }).Where(w=> w.IdSubtitle == s.IdUser))});




            ///// para comandos mais complexos usar o comando a baixo
            //         Entity.Contexts(LOCAL).Command<UsuarioDto>("select Id from Table");
            //Entity.Contexts(LOCAL).Command<Usuario>("select * from Table");
            //Entity.Contexts(LOCAL).Command("select * from Table");
        }

        public object ExecuteCoroutine(Expression<Func<object>> callbackExpression)
        {
            var methodCall = callbackExpression.Body as MethodCallExpression;
            if (methodCall != null)
            {
                string methodName = methodCall.Method.Name;
                var v1 = methodCall.Method.DeclaringType.Name;
            }


            return true;
        }
        private string ExecuteCoroutine(Expression<Action> callbackExpression)
        {
            var v3 = callbackExpression.Name;
            var methodCall = callbackExpression.Body as MethodCallExpression;
            if (methodCall != null)
            {
                string methodName = methodCall.Method.Name;
                var v1 = methodCall.Method.DeclaringType.Name;
            }

            return "";
        }
        public void ExecuteCoroutine(Action action, object[] methodParameters = null)
        {
            var v = action.Method.Name;
            var v1 = action.Method.DeclaringType.Name;
        }
    }

    public static class Extension
    {
        public static (bool resultado, string mensagem) Existe<T>(this T objeto) where T : IEntity
        {
            if(objeto == null)
                return (false, Erro.EntidadeNaoEncontrada<T>());

            return (true, "");
        }
    }
    public class Erro
    {
        public static string EntidadeNaoEncontrada<T>() where T : IEntity =>
            $"{nameof(T)} não encontrado";
        public static string EntidadeNaoEncontrada<T, P>(Expression<Func<T, P>> propriedade, string valor) where T : IEntity =>
            $"{nameof(T)} de {propriedade} {valor} não encontrado";
    }
}
