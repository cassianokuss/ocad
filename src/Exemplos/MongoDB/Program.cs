using System.Reflection;
using Exemplos.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OCAD.Core;
using OCAD.MongoDB;
using OCAD.MongoDB.Consultas;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Exemplos.EF;

public static class Program
{
    private static readonly Container container = new();

    public static async Task Main()
    {
        Configurar();

        using (AsyncScopedLifestyle.BeginScope(container))
        {
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
        }
    }

    private static void Configurar()
    {
        var assemblies = GetAssemblies().ToArray();

        var services = new ServiceCollection()
            .AddSimpleInjector(container)
            .AddMongoDb();

        services
            .BuildServiceProvider(validateScopes: true)
            .UseSimpleInjector(container);

        container.RegisterSingleton<IMediator, Mediator>();
        container.Register(typeof(IRequestHandler<>), assemblies, Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), assemblies, Lifestyle.Scoped);
        container.Collection.Register(typeof(IPipelineBehavior<,>), assemblies);

        container.RegistrarHandlers();

        container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
    }

    private static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(IMediator).GetTypeInfo().Assembly;
        yield return typeof(ObterHandler<>).GetTypeInfo().Assembly;
    }

    public static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        Mapeamentos.Registrar();

        services.AddSingleton<ConexaoMongoDb>();
        services.AddSingleton(provider => provider.GetRequiredService<ConexaoMongoDb>().DataBase.GetCollection<Usuario>("usuario"));
        services.AddSingleton(provider => provider.GetRequiredService<ConexaoMongoDb>().DataBase.GetCollection<Perfil>("pefil"));
        services.AddSingleton(provider => provider.GetRequiredService<ConexaoMongoDb>().DataBase.GetCollection<Pessoa>("pessoa"));

        return services;
    }
}
