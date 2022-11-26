using FluentValidation;
using HumbleMediator;

namespace WebApiTemplate.Application.Validation;

public sealed class QueryHandlerValidationDecorator<TQuery, TQueryResult>
    : BaseValidationDecorator<TQuery>,
        IQueryHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    private readonly IQueryHandler<TQuery, TQueryResult> _decorated;

    public QueryHandlerValidationDecorator(
        IQueryHandler<TQuery, TQueryResult> decorated,
        IEnumerable<IValidator<TQuery>> validators
    ) : base(validators)
    {
        _decorated = decorated;
    }

    public async Task<TQueryResult> Handle(TQuery command, CancellationToken cancellationToken)
    {
        await Validate(command, cancellationToken);
        return await _decorated.Handle(command, cancellationToken);
    }
}
