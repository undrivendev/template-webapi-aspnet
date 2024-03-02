FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers for caching
COPY src/Api/Api.csproj Api/Api.csproj
COPY src/Core/Core.csproj Core/Core.csproj
COPY src/Application/Application.csproj Application/Application.csproj
COPY src/Infrastructure/Infrastructure.csproj Infrastructure/Infrastructure.csproj
RUN dotnet restore -r linux-x64 "Api/Api.csproj"

# copy and publish app and libraries
COPY src/Api/ Api/
COPY src/Core/ Core/
COPY src/Application/ Application/
COPY src/Infrastructure/ Infrastructure/
WORKDIR /src/Api
RUN dotnet publish -c Release --no-self-contained -r linux-x64 -o /app "Api.csproj"

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app .
USER app
ENTRYPOINT ["dotnet", "WebApiTemplate.Api.dll"]
