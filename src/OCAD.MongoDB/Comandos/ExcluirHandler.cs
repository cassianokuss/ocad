using OCAD.Core;
using MediatR;
using MongoDB.Driver;

namespace OCAD.MongoDB.Comandos;

public class ExcluirHandler<T> : AsyncRequestHandler<Excluir<T>> where T : new()
{
    private readonly IMongoCollection<T> _collection;

    public ExcluirHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    protected override Task Handle(Excluir<T> request, CancellationToken cancellationToken) =>
        _collection.DeleteManyAsync(request.Filtro, cancellationToken: cancellationToken);
}