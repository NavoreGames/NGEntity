# NGEntity

### Definição: 
- O pacote NGEntity é um frameworke que contém estruturas de entidades para manipulação de comandos sql.

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
Há duas formas de usar a conexão com a entidade. Passando a conexão no inicio do comando ou usando a extrutura de contexto do pacote.
> [!NOTE]
> Explicaremos inicialmente o método passando a conexão no comando. O contexto será explicado posteriormente nessa documentação.

Para inserir dados no banco usaremos os comando Insert e Inserts

O comando Insert é usado com um objeto entity previamente instanciado enquanto o comando Inserts é um método statico da entidade.

Como mencionado anteriormente a conexão deve ser passado no começo do comando, logo após o objeto, com os métodos SetConnection, SetConnections.
```ruby
User User = new() { IdUser = 1, Email = "email@email.com", UserName = "teste", Flag = false };

User.SetConnection(sqlite).Insert().Execute();
Usuario.SetConnections(sqlite).Inserts(User, new Usuario(), new Usuario()).Execute();
```
> [!NOTE]
> Note que no objeto previamente instanciado o comando insert não leva nenhum argumento, pois o objeto iniciado que será inserido.
>
> Já o Insert statico necessita ser passado nos parâmetros os objetos que serão inseridos, pode ser inserido vários objetos desde que sejam do mesmo tipo
>
>   Obs. Para inserir vários objetos de entidades diferentes existe outro comando que será mostrado posteriormente.
 
> [!NOTE]
> Note que no objeto previamente instanciado o comando insert não leva nenhum argumento, pois o objeto iniciado que será inserido.

Outra forma de criar um enum é herdar de outro enum já criado ao invés da base.
```ruby
public class HerdadoDeOutroEnum : NomeDoSeuEnum
{
  public static readonly NomeDoSeuEnum ChaveDoEnumHerdado = new NomeDoSeuEnum("ChaveDoEnumHerdado");
  public static readonly NomeDoSeuEnum OutraChaveHerdado = new NomeDoSeuEnum("OutraChaveHerdado");
}
```
> [!NOTE]
> Note que as propriedades são do tipo do enum pai, e a classe não precisa de construtor.

Como os enums podem ser herdados infinitamente, se necessário pode-se selar a classe para ela não poder ser mais herdada.
```ruby
public sealed class HerdadoDeOutroEnum : NomeDoSeuEnum
{
  public static readonly NomeDoSeuEnum ChaveDoEnumHerdado = new NomeDoSeuEnum("ChaveDoEnumHerdado");
  public static readonly NomeDoSeuEnum OutraChaveHerdado = new NomeDoSeuEnum("OutraChaveHerdado");
}
```

### Métodos de conversão:

Os métodos de conversão são métodos get para acessar os atributos, inteiro, string e objeto
```ruby
NomeDoSeuEnum.ChaveDoEnum.ToInt();
NomeDoSeuEnum.ChaveDoEnum.ToString();
NomeDoSeuEnum.ChaveDoEnum.ToObject();
```

### Métodos de comparação:

Para comparação simples do objeto pode-se usar os métodos de comparação padrão ==, !=, Equals(recomendado).
```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.ChaveDoEnum;
NomeDoSeuEnum objeto2 = NomeDoSeuEnum.OutraChave;

if (objeto1 == objeto2)
  Console.WriteLine("objeto é igual");
if (objeto1 != objeto2)
  Console.WriteLine("objeto é diferente");
if (objeto1.Equals(objeto2))
  Console.WriteLine("objeto é igual");

//Saída:
//  objeto é diferente
```

Para comparar somente as propriedades use os métodos:
  - CompareId, para comparar somente o id do enum.
  - CompareKey, para comparar a string.
  - CompareObject, para comparar somente o objeto passado (funciona para string também se o objeto passado for uma chave string, mas recomendamos usar o CompareKey para tal comparação).
```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.ChaveDoEnum;
NomeDoSeuEnum objeto2 = NomeDoSeuEnum.ChaveDoEnum;

if (objeto1.CompareId(objeto2.ToInt())
  Console.WriteLine("o id do objeto é o igual");
if (objeto1.CompareKey("ChaveDoEnum"))
  Console.WriteLine("a chave do objeto é igual");
if (objeto1.CompareObject("ChaveDoEnum"))
  Console.WriteLine("o objeto do objeto é igual");

//Saída:
//  o id do objeto é o igual
//  a chave do objeto é igual
//  o objeto do objeto é igual
```

NGEnum também possibilita a criação de enums compostos, pode-se adicionar elementos em um objeto já criado usando o método Add
> [!NOTE]
> O método Add retorna um novo enum com os elementos adicionados, ele deve ser atribuído.
> [!NOTE]
> O id do enum composto será criado automaticamente.

```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.ChaveDoEnum;
objeto1 = objeto1.Add(NomeDoSeuEnum.OutraChave);

Console.WriteLine(objeto1.ToString());

//Saída:
//  ChaveDoEnum|OutraChave
```

Também podemos criar um enum composto usando o método New.
```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.New(NomeDoSeuEnum.ChaveDoEnum, NomeDoSeuEnum.OutraChave);

Console.WriteLine(objeto1.ToString());

//Saída:
//  ChaveDoEnum|OutraChave
```

Para comparar enum composto use o método CompareExact.

Ele irá comparar se o enum é exatamente o mesmo passado no parâmetro, os mesmos elementos na mesma ordem.
> [!NOTE]
> O método irá funcionar com enum simples, mas recomendamos usar apenas para enum composto.

```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.New(NomeDoSeuEnum.ChaveDoEnum, NomeDoSeuEnum.OutraChave); 

if (objeto1.CompareExact(NomeDoSeuEnum.ChaveDoEnum, NomeDoSeuEnum.OutraChave))
  Console.WriteLine("o enum composto é igual");
if (!objeto1.CompareExact(NomeDoSeuEnum.OutraChave, NomeDoSeuEnum.ChaveDoEnum))
  Console.WriteLine("o enum composto é diferente");


//Saída:
//  o enum composto é igual
//  o enum composto é diferente
```

Também podemos verificar se existem o elemento no enum composto usando o método CompareSome.
Ele irá verificar se existe os elementos não importando a ordem.
> [!NOTE]
> O método irá funcionar com enum simples, mas recomendamos usar apenas para enum composto.

```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.New(NomeDoSeuEnum.ChaveDoEnum, NomeDoSeuEnum.OutraChave); 

if (objeto1.CompareSome(NomeDoSeuEnum.ChaveDoEnum))
  Console.WriteLine("O elemento existe no enum");
if (objeto1.CompareSome(NomeDoSeuEnum.OutraChave, NomeDoSeuEnum.ChaveDoEnum))
  Console.WriteLine("Os elementos existem no enum");
```

Também podemos verificar se existem algum dos enums usando o método CompareAny.
Ele irá verificar se existe qualquer dos elementos passados no parâmetro
> [!NOTE]
> O método irá funcionar com enum simples, mas recomendamos usar apenas para enum composto.

```ruby
NomeDoSeuEnum objeto1 = NomeDoSeuEnum.New(NomeDoSeuEnum.ChaveDoEnum, NomeDoSeuEnum.OutraChave);

Console.WriteLine(objeto1.ToString());

Saída: ChaveDoEnum|OutraChave


NomeDoSeuEnum objeto1 = NomeDoSeuEnum.New(NomeDoSeuEnum.ChaveDoEnum); 

if (objeto1.CompareAny(NomeDoSeuEnum.ChaveDoEnum))
Console.WriteLine("Existe o enums");
if (objeto1.CompareAny(NomeDoSeuEnum.OutraChave, NomeDoSeuEnum.ChaveDoEnum))
Console.WriteLine("Existe algum dos enums");
```
