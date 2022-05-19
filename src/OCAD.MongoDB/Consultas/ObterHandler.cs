using OCAD.Core;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace OCAD.MongoDB.Consultas;

public class ExisteHandler<T> : IRequestHandler<Existe<T>, bool> where T : class, new()
{
    private readonly IMongoCollection<T> _collection;

    public ExisteHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task<bool> Handle(Existe<T> request, CancellationToken cancellationToken)
    {
        var options = new AggregateOptions { AllowDiskUse = true };
        var query = request.Builder(_collection.AsQueryable(options)) as IMongoQueryable<T?>;
        return query.AnyAsync(cancellationToken);
    }
}

public class ObterHandler<T> : IRequestHandler<Obter<T>, T?> where T : class, new()
{
    private readonly IMongoCollection<T> _collection;

    public ObterHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task<T?> Handle(Obter<T> request, CancellationToken cancellationToken)
    {
        var options = new AggregateOptions { AllowDiskUse = true };
        var query = request.Builder(_collection.AsQueryable(options)) as IMongoQueryable<T?>;
        return query.FirstOrDefaultAsync(cancellationToken);
    }
}

public class ObterHandler<T, TResult> : IRequestHandler<Obter<T, TResult>, TResult?> where T : class, new()
{
    private readonly IMongoCollection<T> _collection;

    public ObterHandler(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task<TResult?> Handle(Obter<T, TResult> request, CancellationToken cancellationToken)
    {
        var options = new AggregateOptions { AllowDiskUse = true };
        var query = request.Builder(_collection.AsQueryable(options)) as IMongoQueryable<TResult?>;
        return query.FirstOrDefaultAsync(cancellationToken);
    }
}
