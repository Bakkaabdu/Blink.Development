# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Blink.Development.Api/Blink.Development.Api.csproj", "Blink.Development.Api/"]
COPY ["Blink.Development.Authentication/Blink.Development.Authentication.csproj", "Blink.Development.Authentication/"]
COPY ["Blink.Development.Repository/Blink.Development.Repository.csproj", "Blink.Development.Repository/"]
COPY ["Blink.Development.Entities/Blink.Development.Entities.csproj", "Blink.Development.Entities/"]
RUN dotnet restore "./Blink.Development.Api/Blink.Development.Api.csproj"
COPY . .
WORKDIR "/src/Blink.Development.Api"
RUN dotnet build "./Blink.Development.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Blink.Development.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blink.Development.Api.dll"]