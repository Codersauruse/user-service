# Stage 1: Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set working directory
WORKDIR /app

# Only expose port 8081 (remove 8080)
EXPOSE 8081

# Stage 2: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set build configuration
ARG BUILD_CONFIGURATION=Release

# Set working directory
WORKDIR /src

# Copy the .csproj and restore dependencies
COPY ["user-service/user-service.csproj", "user-service/"]
RUN dotnet restore "user-service/user-service.csproj"

# Copy everything and build
COPY . .
WORKDIR "/src/user-service"
RUN dotnet build "user-service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
RUN dotnet publish "user-service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final image
FROM base AS final

WORKDIR /app

# Copy published files
COPY --from=publish /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "user-service.dll"]
