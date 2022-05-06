using System.Data.Entity;
using OCAD.Core;
using MediatR;

namespace OCAD.EF.Comandos;

public class InserirHandler<T> : AsyncRequestHandler<Inserir<T>> where T : class, new()
{
    private readonly DbContext _dbContext;

    public InserirHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override Task Handle(Inserir<T> request, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Attach(request.Objeto);
        return _dbContext.SaveChangesAsync();
    }
}
