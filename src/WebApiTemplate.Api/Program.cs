using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using SimpleInjector;
using WebApiTemplate.Api;
using WebApiTemplate.Application;
using WebApiTemplate.Application.Customers;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;
using WebApiTemplate.Core.Mediator.DependencyInjection;
using WebApiTemplate.Infrastructure.Customers;
using WebApiTemplate.Infrastructure.Persistence;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(); // replace built-in logging with Serilog

// Add services to the container.
    builder.Services.AddControllers();

// swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

// persistence
    builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetSection("Repository").Get<WriteRepositoryOptions>().ConnectionString
                          ?? throw new ArgumentNullException("connectionString"))
            .UseSnakeCaseNamingConvention());
    builder.Services.AddDistributedMemoryCache();

// SimpleInjector
    var container = Container;
    container.Options.DefaultLifestyle = Lifestyle.Singleton;
    builder.Services.AddSimpleInjector(container, options => options.AddAspNetCore().AddControllerActivation());
    builder.Services.Configure<ReadRepositoryOptions>(builder.Configuration.GetSection("Repository"));
    container.Register(() =>
            builder.Configuration.GetSection("Repository")
                .Get<ReadRepositoryOptions>(),
        Lifestyle.Scoped);
    container.Register<ICustomerReadRepository, CustomerReadRepository>();
    container.Register(() =>
            builder.Configuration.GetSection("Repository")
                .Get<WriteRepositoryOptions>(),
        Lifestyle.Scoped);
    container.Register<ICustomerWriteRepository, CustomerWriteRepository>();
    container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();

// mediator
    container.Register<IContainer>(() => new ContainerServiceProviderWrapper(container));
    container.Register<IMediator, Mediator>();

// mediator handlers
    container.Register(
        typeof(ICommandHandler<,>),
        typeof(CustomerCommandHandler).Assembly);

    container.Register(
        typeof(IQueryHandler<,>),
        typeof(CustomerQueryHandler).Assembly);

// handlers decorators
    container.RegisterDecorator(
        typeof(ICommandHandler<,>),
        typeof(CommandHandlerLoggingDecorator<,>));

    container.RegisterDecorator(
        typeof(IQueryHandler<,>),
        typeof(QueryHandlerLoggingDecorator<,>));

    container.RegisterDecorator(
        typeof(IQueryHandler<,>),
        typeof(QueryHandlerCachingDecorator<,>));

    var app = builder.Build();

    app.Services.UseSimpleInjector(container);

// Apply pending EF Core migrations automatically in development mode.
// To do that in production, especially in multi-instance scenarios, you need
// to make sure that migrations are applied as a separate deploy step to prevent data corruption.
    if (app.Environment.IsDevelopment())
    {
        var dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>();
        var dbContext = await dbContextFactory.CreateDbContextAsync();
        if (dbContext.Database.IsRelational())
        {
            // It will throw if the db is not relational
            await dbContext.Database.MigrateAsync();
        }
    }

    app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthorization();
    app.MapControllers();

    container.Verify();

    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program
{
    public static readonly Container Container = new();
}