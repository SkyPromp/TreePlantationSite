# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and all dependent projects
COPY ["AP.BTP.sln", "./"]
COPY ["AP.BTP.Contracts/AP.BTP.Contracts.csproj", "AP.BTP.Contracts/"]
COPY ["AP.BTP.WebAppMaintenance/AP.BTP.WebAppMaintenance.csproj", "AP.BTP.WebAppMaintenance/"]

# Restore dependencies
RUN dotnet restore "AP.BTP.WebAppMaintenance/AP.BTP.WebAppMaintenance.csproj"

# Copy rest and build
COPY AP.BTP.Contracts/ AP.BTP.Contracts/
COPY AP.BTP.WebAppMaintenance/ AP.BTP.WebAppMaintenance/
WORKDIR "/src/AP.BTP.WebAppMaintenance"
RUN dotnet publish "AP.BTP.WebAppMaintenance.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "AP.BTP.WebAppMaintenance.dll"]