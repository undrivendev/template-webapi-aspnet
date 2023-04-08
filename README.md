# ASP.NET Core WebApi template

This template can be used to bootstrap a working full-fledged ASP.NET Web Api project with a single CLI command (see below).

It contains what I consider to be best practices/patterns, such as CQRS, Mediator, Clean Architecture.

## :star: Like it? Give a star
If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Motivation
I found implementations of similar samples/templates to often be overly complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution that can be used as a starting point for the majority of real-world projects while, at the same time, striving to reach a sensible balance between flexibility and complexity.

## Features
- Based on .NET 7 to have access to the latest features
- Simplified Startup.cs hosting model
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) with full separation between Read and Write repositories
- Simple [Mediator](https://en.wikipedia.org/wiki/Mediator_pattern) abstraction for CQRS and implementation relying on the chosen Dependency Injection container (see [HumbleMediator](https://en.wikipedia.org/wiki/Mediator_pattern))
- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- Read repositories based on [Dapper](https://dapperlib.github.io/Dapper/) (Raw SQL) for fastest query execution times
- Write repositories based on [Entity Framework Core](https://github.com/dotnet/efcore) to take advantage on the built-in change tracking mechanism
- [PostgreSQL](https://www.postgresql.org/) open source database as data store (easily replaceable with any Entity Framework-supported data stores)
- Database configured to use snake_case naming convention via [EFCore.NamingConventions](https://github.com/efcore/EFCore.NamingConventions)
- Migrations handled by Entity Framework and automatically applied during startup (in dev environment)
- [SimpleInjector](https://simpleinjector.org/) open-source DI container integration for advanced service registration scenarios
- [Aspect-oriented programming](https://en.wikipedia.org/wiki/Aspect-oriented_programming) using [Decorators](https://en.wikipedia.org/wiki/Decorator_pattern) on the above-mentioned mediator
  - Logging: [QueryHandlerLoggingDecorator](src/WebApiTemplate.Application/Logging/QueryHandlerLoggingDecorator.cs) and [CommandHandlerLoggingDecorator](src/WebApiTemplate.Application/Logging/CommandHandlerLoggingDecorator.cs)
  - Caching: [QueryHandlerCachingDecorator](src/WebApiTemplate.Application/QueryHandlerCachingDecorator.cs)
  - Validation: [CommandHandlerValidationDecorator](src/WebApiTemplate.Application/Validation/CommandHandlerValidationDecorator.cs) and [QueryHandlerValidationDecorator](src/WebApiTemplate.Application/Validation/QueryHandlerValidationDecorator.cs)
- Structured logging using the standard [MEL](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging.Abstractions) interface with the open-source [Serilog](https://serilog.net/) logging library implementation
- Cache-friendly [Dockerfile](src/WebApiTemplate.Api/Dockerfile)
- Expressive testing using [xUnit](https://xunit.net/) and [FluentAssertions](https://fluentassertions.com/)
- Integration testing using real database implementation with [Testcontainers](https://dotnet.testcontainers.org/)

## Usage
### 1. Bootstrap your project
Here are a couple of ways to bootstrap a new project starting from this template.
#### Cookiecutter template
Probably the best way to bootstrap this project, with just one command, but some dependencies are needed.
1. Make sure Python is installed
2. Install [cookiecutter](https://www.cookiecutter.io/).
3. Bootstrap initial project with the following command: `cookiecutter gh:undrivendev/template-webapi-aspnet --checkout cookiecutter`
#### GitHub template
You could use this project as a GitHub template and clone it in your personal account by using the `Use this template` green button on the top of the page.

Then you'd have to rename classes and namespaces.


### 2. Apply initial migration
When you have the project ready, it's time to create the initial migration using [dotnet-ef](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (or if you use Rider, like me, you can try [this plugin](https://plugins.jetbrains.com/plugin/18147-entity-framework-core-ui)).

Here's an example command using the default solution name, if you changed it you would have to adapt it accordingly:

```sh
dotnet ef migrations add --project ./src/WebApiTemplate.Infrastructure/WebApiTemplate.Infrastructure.csproj --context AppDbContext --startup-project ./src/WebApiTemplate.Api/WebApiTemplate.Api.csproj InitialMigration
```

The above migration is applied automatically during startup in the dev environment.

### 3. Start the application
The default API endpoints should be testable from the [Swagger UI](http://localhost:5000/swagger/index.html).

Enjoy!
