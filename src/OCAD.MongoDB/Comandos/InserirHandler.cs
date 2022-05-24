using OCAD.Core;
using MediatR;
using MongoDB.Driver;

namespace OCAD.MongoDB.Comandos;

public class InserirHandler<T> : AsyncRequestHandler<Inserir<T>> where T: class, new()
{
    private readonly IMongoCollection<T> _collection;

    public InserirHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    protected override Task Handle(Inserir<T> request, CancellationToken cancellationToken) =>
        _collection.InsertOneAsync(request.Objeto, cancellationToken: cancellationToken);
}
