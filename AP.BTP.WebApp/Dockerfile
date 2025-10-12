# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and all dependent projects
COPY ["AP.BTP.sln", "./"]
COPY ["AP.BTP.Application/AP.BTP.Application.csproj", "AP.BTP.Application/"]
COPY ["AP.BTP.WebApp/AP.BTP.WebApp.csproj", "AP.BTP.WebApp/"]

# Restore dependencies
RUN dotnet restore "AP.BTP.WebApp/AP.BTP.WebApp.csproj"

# Copy rest and build
COPY AP.BTP.Domain/ AP.BTP.Domain/
COPY AP.BTP.Application/ AP.BTP.Application/
COPY AP.BTP.Infrastructure/ AP.BTP.Infrastructure/
COPY AP.BTP.WebApp/ AP.BTP.WebApp/
WORKDIR "/src/AP.BTP.WebApp"
RUN dotnet publish "AP.BTP.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "AP.BTP.WebApp.dll"]