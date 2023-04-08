FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers for caching
COPY src/{{cookiecutter.solution_name}}.Api/{{cookiecutter.solution_name}}.Api.csproj {{cookiecutter.solution_name}}.Api/{{cookiecutter.solution_name}}.Api.csproj
COPY src/{{cookiecutter.solution_name}}.Core/{{cookiecutter.solution_name}}.Core.csproj {{cookiecutter.solution_name}}.Core/{{cookiecutter.solution_name}}.Core.csproj
COPY src/{{cookiecutter.solution_name}}.Application/{{cookiecutter.solution_name}}.Application.csproj {{cookiecutter.solution_name}}.Application/{{cookiecutter.solution_name}}.Application.csproj
COPY src/{{cookiecutter.solution_name}}.Infrastructure/{{cookiecutter.solution_name}}.Infrastructure.csproj {{cookiecutter.solution_name}}.Infrastructure/{{cookiecutter.solution_name}}.Infrastructure.csproj
RUN dotnet restore -r linux-x64 "{{cookiecutter.solution_name}}.Api/{{cookiecutter.solution_name}}.Api.csproj"

# copy and publish app and libraries
COPY src/{{cookiecutter.solution_name}}.Api/ {{cookiecutter.solution_name}}.Api/
COPY src/{{cookiecutter.solution_name}}.Core/ {{cookiecutter.solution_name}}.Core/
COPY src/{{cookiecutter.solution_name}}.Application/ {{cookiecutter.solution_name}}.Application/
COPY src/{{cookiecutter.solution_name}}.Infrastructure/ {{cookiecutter.solution_name}}.Infrastructure/
WORKDIR /src/{{cookiecutter.solution_name}}.Api
RUN dotnet publish -c Release --no-self-contained -r linux-x64 -o /app "{{cookiecutter.solution_name}}.Api.csproj"

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "{{cookiecutter.solution_name}}.Api.dll"]
