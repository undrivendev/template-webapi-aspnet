using WebApiTemplate.Api;
using WebApiTemplate.Core.Customers;
using WebApiTemplate.Core.Mediator;
using WebApiTemplate.Core.Mediator.DependencyInjection;
using WebApiTemplate.Infrastructure.Customers.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IContainer, AspNetContainerWrapper>();
builder.Services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
builder.Services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();

builder.Services.AddSingleton<IMediator, Mediator>();

// register all mediator handlers
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();