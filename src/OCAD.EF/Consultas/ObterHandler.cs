using OCAD.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace OCAD.EF.Consultas;

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
