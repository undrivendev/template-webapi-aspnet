This project can be used as a starting point to create new ASP.NET-based web APIs.

## Why?
I found implmentations of similar projects to often be overly-complicated and over-engineered (IMO). This is an effort to create a more approachable, more maintainable solution. 

## Like it? Give a star! :star:
If you like this project, you learned something from it or you are using it in your applications, please press the star button. Thanks!

## Features
- .NET 6 goodness
- CQRS
- Simple mediatior abstraction and no-magic, in-memory implementation using the built-in DI container
- Clean architecture
- Dapper (Raw SQL) for Read repositories
- TODO: Ready to use template to generate new project using an [ubiquitous templating engine](https://github.com/cookiecutter/cookiecutter) (no .NET-specific tooling)
- TODO: Aspect-oriented programming using decorators on the above-mentioned mediator
- TODO: Simple logging abstraction on third-party logging providers
- TODO: Serilog
- TODO: testing

### Known limitations
- No DDD (for now)
