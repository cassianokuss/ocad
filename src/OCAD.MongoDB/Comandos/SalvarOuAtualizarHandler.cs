using OCAD.Core;
using MediatR;
using MongoDB.Driver;

namespace OCAD.MongoDB.Comandos;

public class SalvarOuAtualizarHandler<T> : AsyncRequestHandler<SalvarOuAtualizar<T>> where T : new()
{
    private readonly IMongoCollection<T> _collection;

    public SalvarOuAtualizarHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    protected override Task Handle(SalvarOuAtualizar<T> request, CancellationToken cancellationToken) =>
        _collection.ReplaceOneAsync(
            filter: request.Filtro,
            replacement: request.Objeto,
            options: new ReplaceOptions { IsUpsert = true });
}
