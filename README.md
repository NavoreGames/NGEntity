# NGEntity

### Definição: 
- O pacote NGEntity é um framework que contém estruturas de entidades para manipulação de comandos sql.

### Vantagens: 
- Entidades para facilitar a manipulação de comandos sql para vários tipos de banco de dados.
- Padronização dos comandos em formato de Expressões lambda e funções anônimas para os comandos.
- Estruturas de contextos multiplos.

# Documentação

### Usings:

```ruby
using NGEntity;
```

### Implementação:

Para usar o NGEntity deve-se herdar o objeto da entidade da classe Entity<Tsource> e da interface IEntity

O exemplo abaixo foi criado um objeto User, ele será usado como exemplo para o restante da documentação.
```ruby
public class User : Entity<User>, IEntity
{
	public int? IdUser { get; set; }
	public string Email { get; set; }
	public string UserName { get; set; }
	public bool Flag { get; set; }

	public User() { }
}
```

Para usar a entidade deve-se ter uma conexão instanciada do NGConnection.
```ruby
  Sqlite sqlite = new Sqlite("IpAddress", "DataBaseName", "UserName", "Password");
  Mysql mysql = new Mysql($@"Server = {IpAddress}; Database = {DataBaseName}; Uid = {UserName}; Pwd = {Password}; Connection Timeout = {TimeOut};");
```
Há duas formas de usar a conexão com a entidade. Usando a extrutura de contexto do pacote (fortemente recomendado) ou passando a conexão na execução do comando.
primeiramente explicaremos como usar a estrutura de contexto, posteriormente nessa documentação explicaremos o uso sem contexto.

Iniciando o contexto:
 - Para iniciar o contexto use o método AddContext do objeto estatico Context.
   O método sempre pede o parâmetro alias que pode ser qualquer nome desde que seja único, retornando um erro ao tentar inserir um alias já existente.
   O segundo parâmetro é um IConection, que é o objeto que carrega a sua conexão.
   O último parâmetro é uma lista das entidades, as entidade são objetos que herdam do IEntity, que farão parte daquele contexto, apesar de ser um parâmetro opcional recomenda-se o uso.
 - No primeiro exemplo abaixo foi adicionado uma conexão mysql com o nome SERVER e adicionado a entidade User fazendo parte do contexto.
 - No segundo exemplo foi adicionado a conexão LOCAL porém não foi adicionado entidades para o contexto.
```ruby
  Context.AddContext("SERVER", mysql, new User());
  Context.AddContext("LOCAL", new Sqlite("IpAddress", "DataBaseName", "UserName", "Password"));
  
```
> [!NOTE]
> Apesar de aceitar adicionar contexto sem entidades recomenda-se fortemente sempre adicionar as entidades que serão usadas pelo contexto para poder usar todos os recursos do contexto.
>

Para inserir dados no banco usaremos os comando Insert e Inserts

O comando Insert é usado com um objeto entity previamente instanciado enquanto o comando Inserts é um método statico da entidade.

Como mencionado anteriormente a conexão deve ser passado no começo do comando, logo após o objeto, com os métodos SetConnection, SetConnections.
```ruby
User user = new() { IdUser = 1, Email = "email@email.com", UserName = "teste", Flag = false };

user.SetConnection(sqlite).Insert().Execute();
User.SetConnections(sqlite).Inserts(User, new Usuario(), new Usuario()).Execute();
```
> [!NOTE]
> Note que no objeto previamente instanciado o comando insert não leva nenhum argumento, pois o objeto iniciado que será inserido.
>
> Já o Insert statico necessita ser passado nos parâmetros os objetos que serão inseridos, pode ser inserido vários objetos desde que sejam do mesmo tipo
>
> Obs. Para inserir vários objetos de entidades diferentes existe outro comando que será mostrado posteriormente.
