using Microsoft.EntityFrameworkCore;
using OCAD.Core;
using MediatR;

namespace OCAD.EF.Consultas;

public class ListarHandler<T> : IRequestHandler<Listar<T>, List<T>> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ListarHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<T>> Handle(Listar<T> request, CancellationToken cancellationToken)
    {
        var query = request.Builder(_dbContext.Set<T>().AsQueryable());
        return query.ToListAsync(cancellationToken);
    }
}

public class ListarHandler<T, TResult> : IRequestHandler<Listar<T, TResult>, List<TResult>> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ListarHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<TResult>> Handle(Listar<T, TResult> request, CancellationToken cancellationToken)
    {
        var query = request.Builder(_dbContext.Set<T>().AsQueryable());
        return query.ToListAsync(cancellationToken);
    }
}
