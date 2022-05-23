using OCAD.Core;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace OCAD.MongoDB.Consultas;

public class ListarHandler<T> : IRequestHandler<Listar<T>, List<T>> where T : new()
{
    private readonly IMongoCollection<T> _collection;

    public ListarHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task<List<T>> Handle(Listar<T> request, CancellationToken cancellationToken)
    {
        var options = new AggregateOptions { AllowDiskUse = true };
        var query = request.Builder(_collection.AsQueryable(options)) as IMongoQueryable<T>;
        return query.ToListAsync(cancellationToken);
    }
}

public class ListarHandler<T, TResult> : IRequestHandler<Listar<T, TResult>, List<TResult>> where T : new()
{
    private readonly IMongoCollection<T> _collection;

    public ListarHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task<List<TResult>> Handle(Listar<T, TResult> request, CancellationToken cancellationToken)
    {
        var options = new AggregateOptions { AllowDiskUse = true };
        var query = request.Builder(_collection.AsQueryable(options)) as IMongoQueryable<TResult>;
        return query.ToListAsync(cancellationToken);
    }
}
