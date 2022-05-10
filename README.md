# OCAD - Outra (mais uma) camada de acesso a dados.

Uma forma simples de acesso a dados usando [MediatR](https://github.com/jbogard/MediatR) e [SimpleInjector](https://github.com/simpleinjector/SimpleInjector).

O Objetivo desse projeto é proporcionar acesso e manipulação de dados de forma simples e genérica usando MediatR. A recomendação é que seja usado em consultas simples que não demandam de otimização. Em casos mais complexos deve-se criar uma query específica.

A principal vantagem desse técnica é a dependência somente de IMediator facilitando testes e mocks.

[Exemplos](https://github.com/cassianokuss/ocad/tree/main/src/exemplos) de utilização com [MongoDB](https://www.mongodb.com) e [Entity Framework](https://github.com/dotnet/efcore).

## Como usar

### Com MongoDB

```csharp
var mediator = container.GetInstance<IMediator>();

await mediator.Send(new Inserir<Perfil>(new Perfil { Id = 1, Nome = "Perfil 1" }));
var perfil = await mediator.Send(new Obter<Perfil>(e => e.Where(x => x.Id == 1)));

await mediator.Send(new Inserir<Pessoa>(new Pessoa { Id = 1, Nome = "Pessoa 1", Cpf = "1", Telefone = "123" }));
var pessoa = await mediator.Send(new Obter<Pessoa>(e => e.Where(x => x.Id == 1)));

if (perfil == null || pessoa == null) throw new Exception();

await mediator.Send(new Inserir<Usuario>(new Usuario { Id = 1, Login = "12345", Pessoa = pessoa, Perfis = new List<Perfil> { perfil } }));

var usuario = await mediator.Send(new Obter<Usuario>(e => e
            .Where(x => x.Id == 1)
));

Console.WriteLine(usuario?.Login);
```

### Com Entity Framework

```csharp
var mediator = container.GetInstance<IMediator>();

await mediator.Send(new Inserir<Perfil>(new Perfil { Id = 1, Nome = "Perfil 1" }));
var perfil = await mediator.Send(new Obter<Perfil>(e => e.Where(x => x.Id == 1)));

await mediator.Send(new Inserir<Pessoa>(new Pessoa { Id = 1, Nome = "Pessoa 1", Cpf = "1", Telefone = "123" }));
var pessoa = await mediator.Send(new Obter<Pessoa>(e => e.Where(x => x.Id == 1)));

if (perfil == null || pessoa == null) throw new Exception();

await mediator.Send(new Inserir<Usuario>(new Usuario { Id = 1, Login = "12345", Pessoa = pessoa, Perfis = new List<Perfil> { perfil } }));

var usuario = await mediator.Send(new Obter<Usuario>(e => e
    .Where(x => x.Id == 1)
    .Include(x => x.Pessoa)
    .Include(x => x.Perfis)
));

Console.WriteLine(usuario?.Login);

```
