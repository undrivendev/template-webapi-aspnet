FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /build

# copy csproj and restore as distinct layers for caching
COPY src/Api/Api.csproj ./src/Api/Api.csproj
COPY src/Core/Core.csproj ./src/Core/Core.csproj
COPY src/Application/Application.csproj ./src/Application/Application.csproj
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/Infrastructure.csproj
COPY Directory.Build.props .
RUN dotnet restore -r linux-x64 "./src/Api/Api.csproj"

# copy and publish app and libraries
COPY src/Api/ ./src/Api/
COPY src/Core/ ./src/Core/
COPY src/Application/ ./src/Application/
COPY src/Infrastructure/ ./src/Infrastructure/
RUN dotnet publish -c Release --no-self-contained -r linux-x64 -o /app "./src/Api/Api.csproj"

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app .
USER app
ENTRYPOINT ["dotnet", "WebApiTemplate.Api.dll"]
