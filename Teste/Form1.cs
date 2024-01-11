using System;
using System.Data;
using System.Linq.Expressions;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using NGConnection;
using NGConnection.Enum;
using NGEntity;
using NGEntity.Enum;
using NGConnection.Interface;

namespace Teste
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public object CreateDataBaseFromCode()
		{
			return true;
		}

		public void CreateDataBase()
		{
			
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
		private void Form1_Load(object sender, EventArgs e)
		{
			//ExecuteCoroutine(() => { return CreateDataBaseFromCode(); });

			//ExecuteCoroutine(CreateDataBaseFromCode);

			ExecuteCoroutine(() => CreateDataBase());
			ExecuteCoroutine(CreateDataBase);

			Context.AddConnection<ConnectionSqlite>(new Sqlite("", "", "", ""));

			Usuario User = new() { IdUser = 5, Email = "will@will.com", UserName = "willian", Flag = false };

			Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where(w => (w.IdUser == 1 && w.Email == "") || w.Flag == false);

			/////**************** INSERTS *************////////
			///// não verifica se a entidade e vazio ou valores padrão (não sei se devo verificar)
			Usuario.Insert<ConnectionSqlite>(new Usuario());
			///// pode inserir varias entidades de uma vez
			Usuario.Insert<ConnectionSqlite>(new Usuario(), new Usuario(), new Usuario());
			///// pode inserir as entidades com esse tipo de inicialização, ou com construtores se a entidade tiver construtores para as propriedades
			Usuario.Insert<ConnectionSqlite>(new Usuario() { IdUser = 1, Email = "will@will.com", UserName = "willian", Flag = false });
			///// pode inserir entidades passando as entidades que foram instanciadas previamente
			Usuario.Insert<ConnectionSqlite>(User);
			///// pode inserir entidades previamente instanciadas, porém assim só dá para iserir uma por vez, pois irá inserir apenas a entidade instanciada
			User.Insert<ConnectionSqlite>();
			///// ao referenciar a entidade no inicio, não pode ser inseridas entidades diferentes no parametro do insert.
			///// ocorrerá um erro no compilador.
			//Usuario.SetConnections(ConnectionName.Sqlite).Insert(new Subtitle());
			//// para inserir varias entidades diferentes, use a referencia Entity
			Entity.Insert<ConnectionSqlite>(new Usuario(), new Subtitle());

			/////**************** UPDATES *************////////
			///// para fazer update use o comando.
			Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com", UserName = "willian", Flag = false });
			///// pode fazer o update apenas dos campos necessarios.
			Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com" });
			///// o processo tentará verificar o id da sua entidade, se a sua entidade conter o comando costimizado da propriedade (exemplo abaixo)
			/////[FieldsAttributes(VariableType.Int, 0, true, Key.Pk, true)]
			///// e a propriedade do id também tem que ser declarada na inicialização.
			Usuario.Update<ConnectionSqlite>(new() { IdUser = 5, Email = "will@will.com" });
			///// caso o processo não encontrar o id automaticamente, você tem que usar o comando Where
			///// o comando where pode ser declarado com uma expressão lambda eu uma expressão string
			Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where(w => w.IdUser == 2);
			Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" }).Where("IdUser == 2");
			///// caso o comando update não tenha nenhum comando where, o update não será criado, 
			///// consequentemente não realizando nenhum tipo de alteração no banco.
			///// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
			Usuario.Update<ConnectionSqlite>(new() { Email = "will@will.com" });
			///// o comando update também não será criado se a entidade passada não conter nenhum tipo de alteração
			///// (isso não ocorrera nenhum tipo de erro de compilação ou de execução)
			Usuario.Update<ConnectionSqlite>(new());
			///// pode fazer update de entidades previamente instanciadas
			///// o princípio de não conter where ou da entidade sem alteração também se aplicam aqui
			User.Update<ConnectionSqlite>();

			/////**************** DELETE *************////////
			Usuario.Delete<ConnectionSqlite>().Where(w => w.IdUser == 1);
			Usuario.Delete<ConnectionSqlite>(User);
			User.Delete<ConnectionSqlite>();

			/////**************** SELECT *************////////
			///// para fezer select apenas da entidade e de todas as colunas usar o comando abaixo, com ou sem o comando where 
			Usuario.Select<ConnectionSqlite>();
			Usuario.Select<ConnectionSqlite>().Where(w => w.IdUser > 0);
			///// para fezer select apenas da entidade e com colunas especificas usar o comando abaixo, com ou sem o comando where 
			Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, s.Email });
			Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = s.Flag });
			Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = s.Flag }).Where(w => w.Email != "");
			///// para fazer um select com join, use a referencia Entity.
			///// use o comando select, a primeira referencia será a entidade principal do select e a segunda referencia será o retorno sempre um IDto
			//Entity.SetConnections(ConnectionName.Sqlite).Select<Usuario, UsuarioDto>().InnerJoin<Usuario, Subtitle>((j1, j2) => j1.IdUser == j2.FkLanguage && j2.IdSubtitle > 0);
			///// ver uma forma de fazer subselect //////////////////////
			//Usuario.Select<ConnectionSqlite>(s => new { s.IdUser, email = s.Email, f = (Subtitle.Select<ConnectionSqlite>(s1 => new { s1.IdSubtitle }).Where(w=> w.IdSubtitle == s.IdUser))});




			///// para comandos mais complexos usar o comando a baixo
			Entity.Command<ConnectionSqlite, UsuarioDto>("select Id from Table");
			Entity.Command<ConnectionSqlite, Usuario>("select * from Table");
			Entity.Command<ConnectionSqlite>("select * from Table");
		}
	}
}
