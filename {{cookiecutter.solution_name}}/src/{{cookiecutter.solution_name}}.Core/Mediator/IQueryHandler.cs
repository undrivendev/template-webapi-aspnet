namespace {{cookiecutter.solution_name}}.Core.Mediator;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken = default);
}