FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy project file
COPY ./src/MinimalWeb/MinimalWeb.csproj ./
# Restore as distinct layers
RUN dotnet restore MinimalWeb.csproj

# Copy project source files
COPY ./src/MinimalWeb ./

# Build and publish a release
RUN dotnet publish MinimalWeb.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "MinimalWeb.dll"]