# Base image for running the app (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage (SDK Image)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Install the dotnet-ef tool (Move it here, in the SDK image)
RUN dotnet tool install --global dotnet-ef

# Ensure global tools are in the PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy project files and restore dependencies
COPY ["WebApp_UserManagement/Web.csproj", "WebApp_UserManagement/"]
COPY ["UserManagement.Shared/UserManagement.Shared.csproj", "UserManagement.Shared/"]
COPY ["UserManagement.Repository.Implementation/UserManagement.Repository.csproj", "UserManagement.Repository.Implementation/"]
COPY ["UserManagement.Domain/UserManagement.Domain.csproj", "UserManagement.Domain/"]
RUN dotnet restore "./WebApp_UserManagement/Web.csproj"

# Copy the rest of the code and build the project
COPY . .
WORKDIR "/src/WebApp_UserManagement"
RUN dotnet build "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the service project
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage to run the app in production (ASP.NET Core Runtime)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]
