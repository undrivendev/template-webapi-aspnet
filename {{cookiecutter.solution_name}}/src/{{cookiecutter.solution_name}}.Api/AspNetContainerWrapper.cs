using {{cookiecutter.solution_name}}.Core.Mediator.DependencyInjection;

namespace {{cookiecutter.solution_name}}.Api;

public class AspNetContainerWrapper : IContainer
{
    private readonly IServiceProvider _container;

    public AspNetContainerWrapper(IServiceProvider container)
    {
        _container = container;
    }


    public TService Resolve<TService>() where TService : notnull
        => _container.GetRequiredService<TService>();
}