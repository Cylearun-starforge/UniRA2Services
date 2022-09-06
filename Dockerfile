# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY HttpServer/*.csproj ./HttpServer/
COPY HttpServerTests/*.csproj ./HttpServerTests/

# copy everything else and build app
COPY HttpServer/. ./HttpServer/
COPY HttpServerTests/. ./HttpServerTests/
RUN dotnet restore
RUN dotnet build -c Release -o /app --no-restore HttpServer

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80 443
ENTRYPOINT ["dotnet", "HttpServer.dll"]