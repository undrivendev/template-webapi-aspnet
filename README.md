This project can be used as a starting point to create new ASP.NET-based web APIs based on CQRS, Mediator, Clean Architecture patterns.

## Like it? Give a star! :star:

If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Why?

I found implementations of similar samples/templates to often be overly complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution that can be used as a starting point for the majority of real-world projects while, at the same time, striving to reach a sensible balance between flexibility and complexity.

## Features

- Based on .NET 6 for Long Term Support
- Simplified .NET 6 startup hosting model
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) with full separation between Read and Write repositories
- Simple [Mediator](https://en.wikipedia.org/wiki/Mediator_pattern) abstraction for CQRS and no-magic, in-memory implementation relying on the standard `IServiceProvider` DI container abstraction (~50 lines of code)
- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- Read repositories based on [Dapper](https://github.com/DapperLib/Dapper) (Raw SQL) for fastest query execution times
- Write repositories based on [Entity Framework Core](https://github.com/dotnet/efcore) to take advantage on the built-in change tracking mechanism
- [PostgreSQL](https://www.postgresql.org/) open source database as data store (easily replaceable with any Entity Framework-supported data stores); Configured to use snake_case naming convention via [EFCore.NamingConventions](https://github.com/efcore/EFCore.NamingConventions)
- Migrations handled by Entity Framework and automatically applied during startup (in dev environment)
- Ready to use template to generate new project using [cookiecutter](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- [SimpleInjector](https://github.com/simpleinjector/SimpleInjector) open-source DI container integration for advanced service registration scenarios
- [Aspect-oriented programming](https://en.wikipedia.org/wiki/Aspect-oriented_programming) using [Decorators](https://en.wikipedia.org/wiki/Decorator_pattern) on the above-mentioned mediator
  - [Logging](src/WebApiTemplate.Application/CommandHandlerLoggingDecorator.cs)
  - [Caching](src/WebApiTemplate.Application/QueryHandlerCachingDecorator.cs)
  - TODO: Validation
- Structured logging using the standard [MEL](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Abstractions) interface with the open-source [Serilog](https://github.com/serilog/serilog) logging library implementation
- Testing
- TODO: Dockerfile

## How to use

You could use this project as a Github template and clone it in your personal space by using the green button on the top of the page, but then you'd have to rename everything (don't recommended). Instead you can use [cookiecutter](https://github.com/cookiecutter/cookiecutter) and bootstrap a functioning project in a few steps leveraging the template I've already prepared:

1. Install [Python](https://www.python.org/downloads/) and [cookiecutter](https://cookiecutter.readthedocs.io/en/latest/installation.html) and run the following command in the directory you want to create the new solution in:

`cookiecutter gh:undrivendev/template-webapi-aspnet --checkout cookiecutter`

2. The wizard will ask for your project's solution and sample class name, provide them
3. The new solution is created. All is left now is to create the initial migration using [dotnet-ef](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (or if you use Rider, like me, you can try [this plugin](https://plugins.jetbrains.com/plugin/18147-entity-framework-core-ui)).

`dotnet ef migrations add --project ./src/SolutionName.Infrastructure/SolutionName.Infrastructure.csproj --context AppDbContext --startup-project ./src/SolutionName.Api/SolutionName.Api.csproj InitialMigration`

4. Start the application. The above migration is applied automatically and the default API endpoints should be testable from the [Swagger UI](http://localhost:5000/swagger/index.html)
5. Enjoy!

## Known limitations

- No proper DDD (for now)
- No Authentication
