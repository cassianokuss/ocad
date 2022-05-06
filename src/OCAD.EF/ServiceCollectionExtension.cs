using MediatR;
using SimpleInjector;
using OCAD.EF.Consultas;
using OCAD.EF.Comandos;

namespace OCAD.EF;
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
