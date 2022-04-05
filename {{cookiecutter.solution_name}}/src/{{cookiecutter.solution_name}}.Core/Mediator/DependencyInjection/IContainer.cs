namespace {{cookiecutter.solution_name}}.Core.Mediator.DependencyInjection;

public interface IContainer
{
    public TService Resolve<TService>() where TService : notnull;
}