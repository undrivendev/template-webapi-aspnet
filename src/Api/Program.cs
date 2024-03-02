using FluentValidation;
using HumbleMediator;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;
using Serilog.Events;
using SimpleInjector;
using WebApiTemplate.Application;
using WebApiTemplate.Application.Customers.Commands;
using WebApiTemplate.Application.Customers.Queries;
using WebApiTemplate.Application.Logging;
using WebApiTemplate.Application.Validation;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
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

    builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();

    // persistence
    var connString =
        builder.Configuration.GetConnectionString("Default")
        ?? throw new ArgumentNullException("connectionString");
    builder.Services.AddNpgsqlDataSource(connString);

    Action<IServiceProvider, DbContextOptionsBuilder> dbConfigure = (sp, options) =>
        options.UseNpgsql(sp.GetRequiredService<NpgsqlDataSource>()).UseSnakeCaseNamingConvention();
    builder.Services.AddDbContext<AppDbContext>(dbConfigure, ServiceLifetime.Singleton);
    builder.Services.AddPooledDbContextFactory<AppDbContext>(dbConfigure);
    builder.Services.AddDistributedMemoryCache();

    // SimpleInjector
    var container = Container;
    container.Options.DefaultLifestyle = Lifestyle.Singleton;
    builder.Services.AddSimpleInjector(
        container,
        options => options.AddAspNetCore().AddControllerActivation()
    );

    container.Register<ICustomerReadRepository, CustomerReadRepository>();
    container.Register<ICustomerWriteRepository, CustomerWriteRepository>();
    container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();

    // validators
    container.Collection.Register(
        typeof(IValidator<>),
        typeof(GetCustomerByIdQueryValidator).Assembly
    );

    // mediator
    container.Register<IMediator>(() => new Mediator(container.GetInstance));

    // mediator handlers
    container.Register(typeof(ICommandHandler<,>), typeof(CreateCustomerCommandHandler).Assembly);
    container.Register(typeof(IQueryHandler<,>), typeof(GetCustomerByIdQueryHandler).Assembly);

    // mediator handlers decorators - queries pipeline
    container.RegisterDecorator(
        typeof(IQueryHandler<,>),
        typeof(QueryHandlerValidationDecorator<,>)
    );
    container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(QueryHandlerCachingDecorator<,>));
    container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(QueryHandlerLoggingDecorator<,>));

    // mediator handlers decorators - commands pipeline
    container.RegisterDecorator(
        typeof(ICommandHandler<,>),
        typeof(CommandHandlerValidationDecorator<,>)
    );
    container.RegisterDecorator(
        typeof(ICommandHandler<,>),
        typeof(CommandHandlerLoggingDecorator<,>)
    );

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

    app.MapHealthChecks("/health");

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
