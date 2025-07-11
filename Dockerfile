# Base image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the csproj file first to leverage Docker layer caching
COPY ["GMP.API.csproj", "./"]
RUN dotnet restore "./GMP.API.csproj"

# Copy the rest of the source code
COPY . .

# Build the app
RUN dotnet build "./GMP.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GMP.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMP.API.dll"]