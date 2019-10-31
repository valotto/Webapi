FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app


# copy csproj and restore as distinct layers
COPY webapi/*.csproj ./dotnetapp/
COPY utils/*.csproj ./utils/
WORKDIR /app/dotnetapp
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY dotnetapp/. ./dotnetapp/
COPY utils/. ./utils/
WORKDIR /app/dotnetapp
RUN dotnet publish -c Release -o out


# test application -- see: dotnet-docker-unit-testing.md
FROM build AS testrunner
WORKDIR /app/tests
COPY tests/. .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]


FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app
COPY . ./
ENTRYPOINT ["dotnet", "webapi.dll"]