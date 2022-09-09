using MediatR;
using SimpleInjector;
using OCAD.MongoDB.Comandos;
using OCAD.MongoDB.Consultas;

namespace OCAD.MongoDB;
public static class ContainerExtension
{
    public static Container RegistrarHandlers(this Container container)
    {
        container.Register(typeof(IRequestHandler<,>), typeof(ExisteHandler<>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(ObterHandler<>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(ObterHandler<,>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(ListarHandler<>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(ListarHandler<,>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(SalvarOuAtualizarHandler<>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(InserirHandler<>), Lifestyle.Transient);
        container.Register(typeof(IRequestHandler<,>), typeof(ExcluirHandler<>), Lifestyle.Transient);

        return container;
    }
}
