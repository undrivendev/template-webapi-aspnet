This project can be used as a starting point to create new ASP.NET-based web APIs based on CQRS, Mediator, Clean Archtecture patterns.

## Like it? Give a star! :star:

If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Why?

I found implementations of similar projects to often be overly-complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution for the majority of use cases.

## Features

- .NET 6 goodness
- Simplified .NET 6 startup hosting model
- CQRS
- Separation between Read and Write repositories
- Simple mediatior abstraction and no-magic, in-memory implementation using the built-in DI container (~70 lines of code)
- Clean architecture
- Dapper (Raw SQL) for Read repositories
- Entity Framework for write repositories
- Automatically applied Entity Framework migrations during startup
- TODO: Ready to use template to generate new project using an [ubiquitous templating engine](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- TODO: Aspect-oriented programming using decorators on the above-mentioned mediator
- TODO: Simple logging abstraction on third-party logging providers
- TODO: Serilog
- TODO: testing

## How to use

TODO

## Known limitations

- No DDD (for now)
