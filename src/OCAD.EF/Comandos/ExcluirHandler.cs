using Microsoft.EntityFrameworkCore;
using OCAD.Core;
using MediatR;

namespace OCAD.EF.Comandos;

public class ExcluirHandler<T> : AsyncRequestHandler<Excluir<T>> where T : class, new()
{
    private readonly DbContext _dbContext;

    public ExcluirHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override Task Handle(Excluir<T> request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Set<T>().AsQueryable().Where(request.Filtro);
        _dbContext.Set<T>().RemoveRange(query);
        return _dbContext.SaveChangesAsync();
    }
}