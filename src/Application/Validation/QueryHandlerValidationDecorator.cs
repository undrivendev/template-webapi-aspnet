using FluentValidation;
using HumbleMediator;

namespace WebApiTemplate.Application.Validation;

/// <summary>
/// Decorator for validating query handlers.
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TQueryResult"></typeparam>
public sealed class QueryHandlerValidationDecorator<TQuery, TQueryResult>
    : BaseValidationDecorator<TQuery>,
        IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryHandlerValidationDecorator{TQuery, TQueryResult}"/> class.
    /// </summary>
    /// <param name="decorated">The query handler to decorate.</param>
    /// <param name="validators">The validators to use.</param>
    public QueryHandlerValidationDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        IEnumerable<IValidator<TQuery>> validators
    )
        : base(validators)
    {
        _decorated = decorated;
    }

    /// <summary>
    /// Validates the query and handles it.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TQueryResult> Handle(TQuery request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        return await _decorated.Handle(request, cancellationToken);
    }
}
