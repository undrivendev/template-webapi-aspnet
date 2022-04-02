This project can be used as a starting point to create new ASP.NET-based web APIs based on CQRS, Mediator, Clean Archtecture principles.

## Why?
I found implmentations of similar projects to often be overly-complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution. 

## Like it? Give a star! :star:
If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Features
- .NET 6 goodness
- (Minimal APIs)[https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0]
- CQRS
- Simple mediatior abstraction and no-magic, in-memory implementation using the built-in DI container
- Clean architecture
- TODO: Dapper (Raw SQL) for Read repositories
- TODO: Entity Frameowork for write repositories
- TODO: Migrations?
- TODO: Ready to use template to generate new project using an [ubiquitous templating engine](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- TODO: Aspect-oriented programming using decorators on the above-mentioned mediator
- TODO: Simple logging abstraction on third-party logging providers
- TODO: Serilog
- TODO: testing

### Known limitations
- No DDD (for now)
