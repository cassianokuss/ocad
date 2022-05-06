using MediatR;
using SimpleInjector;
using OCAD.MongoDB.Comandos;
using OCAD.MongoDB.Consultas;

namespace OCAD.MongoDB;
public static class ContainerExtension
{
    public static Container RegistrarHandlers(this Container container)
    {
        container.Register(typeof(IRequestHandler<,>), typeof(ObterHandler<>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(ObterHandler<,>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(ListarHandler<>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(ListarHandler<,>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(SalvarOuAtualizarHandler<>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(InserirHandler<>), Lifestyle.Scoped);
        container.Register(typeof(IRequestHandler<,>), typeof(ExcluirHandler<>), Lifestyle.Scoped);

        return container;
    }
}
