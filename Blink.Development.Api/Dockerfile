# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk:9.0-focal AS build-env
WORKDIR /source
COPY . .
RUN dotnet restore "Blink.Development.Api/Blink.Development.Api.csproj"
RUN dotnet publish "Blink.Development.Api/Blink.Development.Api.csproj" -c Release -o /app --no-restore
# Serve Stage
FROM mcr.microsoft.com/dotnet/core/aspnet:9.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Blink.Development.Api.dll"]