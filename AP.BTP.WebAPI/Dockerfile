# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files for restore
COPY ["AP.BTP.sln", "./"]
COPY ["AP.BTP.Contracts/AP.BTP.Contracts.csproj", "AP.BTP.Contracts/"]
COPY ["AP.BTP.Domain/AP.BTP.Domain.csproj", "AP.BTP.Domain/"]
COPY ["AP.BTP.Application/AP.BTP.Application.csproj", "AP.BTP.Application/"]
COPY ["AP.BTP.Infrastructure/AP.BTP.Infrastructure.csproj", "AP.BTP.Infrastructure/"]
COPY ["AP.BTP.WebAPI/AP.BTP.WebAPI.csproj", "AP.BTP.WebAPI/"]

# Restore dependencies
RUN dotnet restore "AP.BTP.WebAPI/AP.BTP.WebAPI.csproj"

# Copy rest and build
COPY AP.BTP.Contracts/ AP.BTP.Contracts/
COPY AP.BTP.Domain/ AP.BTP.Domain/
COPY AP.BTP.Application/ AP.BTP.Application/
COPY AP.BTP.Infrastructure/ AP.BTP.Infrastructure/
COPY AP.BTP.WebAPI/ AP.BTP.WebAPI/
WORKDIR "/src/AP.BTP.WebAPI"
RUN dotnet publish "AP.BTP.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "AP.BTP.WebAPI.dll"]
