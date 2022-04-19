using WebApiTemplate.Core.Mediator.DependencyInjection;

namespace WebApiTemplate.Api;

public class AspNetServiceProviderWrapper : IContainer
{
    private readonly IServiceProvider _container;

    public AspNetServiceProviderWrapper(IServiceProvider container)
    {
        _container = container;
    }

    public TService Resolve<TService>() where TService : notnull
        => _container.GetRequiredService<TService>();
}