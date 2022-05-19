using System.Linq.Expressions;
using MediatR;

namespace OCAD.Core;

/// <summary>
/// Obtem o primeiro objeto T da query. 
/// </summary>
public record Existe<T>(Func<IQueryable<T>, IQueryable<T>> Builder) : IRequest<bool>;

/// <summary>
/// Obtem o primeiro objeto T da query. 
/// </summary>
public record Obter<T>(Func<IQueryable<T>, IQueryable<T>> Builder) : IRequest<T?>;

/// <summary>
/// Obtem o primeiro objeto TResult da query. 
/// </summary>
public record Obter<T, TResult>(Func<IQueryable<T>, IQueryable<TResult>> Builder) : IRequest<TResult?>;

/// <summary>
/// Lista os objetos T da query. 
/// </summary>
public record Listar<T>(Func<IQueryable<T>, IQueryable<T>> Builder) : IRequest<List<T>>;

/// <summary>
/// Lista os objetos TResult da query.
/// </summary>
public record Listar<T, TResult>(Func<IQueryable<T>, IQueryable<TResult>> Builder) : IRequest<List<TResult>>;

/// <summary>
/// Insere ou atualiza um objeto T baseado no filtro.
/// </summary>
public record SalvarOuAtualizar<T>(T Objeto, Expression<Func<T, bool>> Filtro) : IRequest;

/// <summary>
/// Insere um objeto T.
/// </summary>
public record Inserir<T>(T Objeto) : IRequest;

/// <summary>
/// Exclui os objetos T que atendam ao filtro.
/// </summary>
public record Excluir<T>(Expression<Func<T, bool>> Filtro) : IRequest;
