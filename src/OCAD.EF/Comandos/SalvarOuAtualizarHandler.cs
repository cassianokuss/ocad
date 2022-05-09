using Microsoft.EntityFrameworkCore;
using OCAD.Core;
using MediatR;

namespace OCAD.EF.Comandos;

public class SalvarOuAtualizarHandler<T> : AsyncRequestHandler<SalvarOuAtualizar<T>> where T : class, new()
{
    private readonly DbContext _dbContext;

    public SalvarOuAtualizarHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override Task Handle(SalvarOuAtualizar<T> request, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Attach(request.Objeto);
        return _dbContext.SaveChangesAsync();
    }
}
