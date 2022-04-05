This project can be used as a starting point to create new ASP.NET-based web APIs based on CQRS, Mediator, Clean Archtecture patterns.

## Like it? Give a star! :star:

If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Why?

I found implementations of similar projects to often be overly-complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution that can be used as a starting point for the majority of real-world projects while, at the same time, striving to reach a sensible balance between flexibility and complexity.

## Features

- Based on .NET 6 for Long Term Support
- Simplified .NET 6 startup hosting model
- CQRS with full separation between Read and Write repositories
- Simple mediatior abstraction for CQRS and no-magic, in-memory implementation using the built-in ASP.NET DI container (~50 lines of code)
- Project structure following Clean Architecture principles
- PostgreSQL open source database as data store
- Read repositories based on Dapper (Raw SQL) for fastest query execution times
- Write repositories based on Entity Framework to take advantage on the built-in change tracking mechanism
- Migrations handled by Entity Framework and automatically applied during startup
- Ready to use template to generate new project using an [ubiquitous templating engine](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- TODO: Aspect-oriented programming using decorators on the above-mentioned mediator
- TODO: Simple logging abstraction on third-party logging providers
- TODO: Serilog
- TODO: testing

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
