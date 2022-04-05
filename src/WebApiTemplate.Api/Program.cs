using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api;
using WebApiTemplate.Application.Customers;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;
using WebApiTemplate.Core.Mediator.DependencyInjection;
using WebApiTemplate.Infrastructure.Customers;
using WebApiTemplate.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// persistence
builder.Services.Configure<ReadRepositoryOptions>(builder.Configuration.GetSection("Repository"));
builder.Services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
builder.Services.Configure<WriteRepositoryOptions>(builder.Configuration.GetSection("Repository"));
builder.Services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("Repository").Get<WriteRepositoryOptions>().ConnectionString
                      ?? throw new ArgumentNullException("connectionString"))
        .UseSnakeCaseNamingConvention());
builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

// mediator
builder.Services.AddSingleton<IContainer, AspNetContainerWrapper>();
builder.Services.AddSingleton<IMediator, Mediator>();

// mediator handlers
var registrations = typeof(CustomerQueryHandler)
    .Assembly
    .GetExportedTypes()
    .Where(e => e.Name.EndsWith("CommandHandler") || e.Name.EndsWith("QueryHandler")).ToList()
    .SelectMany(e => e.GetInterfaces().Select(f => new { service = f, implementation = e }));

foreach (var r in registrations)
{
    builder.Services.AddSingleton(r.service, r.implementation);
}

var app = builder.Build();

// apply pending EF Core migrations automatically
await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
}

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
app.Run();