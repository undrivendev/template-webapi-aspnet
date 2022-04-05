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
- TODO: Ready to use template to generate new project using an [ubiquitous templating engine](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- TODO: Aspect-oriented programming using decorators on the above-mentioned mediator
- TODO: Simple logging abstraction on third-party logging providers
- TODO: Serilog
- TODO: testing

## How to use

TODO

## Known limitations

- No proper DDD (for now)
