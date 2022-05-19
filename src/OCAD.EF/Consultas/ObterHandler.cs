using Microsoft.EntityFrameworkCore;
using OCAD.Core;
using MediatR;

namespace OCAD.EF.Consultas;

public class ExisteHandler<T> : IRequestHandler<Existe<T>, bool> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ExisteHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> Handle(Existe<T> request, CancellationToken cancellationToken)
    {
        var query = request.Builder(_dbContext.Set<T>().AsQueryable());
        return query.AnyAsync(cancellationToken);
    }
}

public class ObterHandler<T> : IRequestHandler<Obter<T>, T?> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ObterHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<T?> Handle(Obter<T> request, CancellationToken cancellationToken)
    {
        var query = request.Builder(_dbContext.Set<T>().AsQueryable());
        return query.FirstOrDefaultAsync(cancellationToken);
    }
}

public class ObterHandler<T, TResult> : IRequestHandler<Obter<T, TResult>, TResult?> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ObterHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<TResult?> Handle(Obter<T, TResult> request, CancellationToken cancellationToken)
    {
        var query = request.Builder(_dbContext.Set<T>().AsQueryable());
        return query.FirstOrDefaultAsync(cancellationToken);
    }
}
