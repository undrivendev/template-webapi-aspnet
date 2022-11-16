FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers for caching
COPY src/WebApiTemplate.Api/WebApiTemplate.Api.csproj WebApiTemplate.Api/WebApiTemplate.Api.csproj
COPY src/WebApiTemplate.Core/WebApiTemplate.Core.csproj WebApiTemplate.Core/WebApiTemplate.Core.csproj
COPY src/WebApiTemplate.Application/WebApiTemplate.Application.csproj WebApiTemplate.Application/WebApiTemplate.Application.csproj
COPY src/WebApiTemplate.Infrastructure/WebApiTemplate.Infrastructure.csproj WebApiTemplate.Infrastructure/WebApiTemplate.Infrastructure.csproj
RUN dotnet restore -r linux-x64 "WebApiTemplate.Api/WebApiTemplate.Api.csproj"

# copy and publish app and libraries
COPY src/WebApiTemplate.Api/ WebApiTemplate.Api/
COPY src/WebApiTemplate.Core/ WebApiTemplate.Core/
COPY src/WebApiTemplate.Application/ WebApiTemplate.Application/
COPY src/WebApiTemplate.Infrastructure/ WebApiTemplate.Infrastructure/
WORKDIR /src/WebApiTemplate.Api
RUN dotnet publish -c Release --no-self-contained -r linux-x64 -o /app "WebApiTemplate.Api.csproj"

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WebApiTemplate.Api.dll"]
