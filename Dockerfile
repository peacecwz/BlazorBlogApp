FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore

RUN dotnet test ./tests/BlogApp.Tests/BlogApp.Tests.csproj

RUN dotnet publish ./src/BlogApp.API/BlogApp.API.csproj -c Release -o prod

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/src/BlogApp.API/prod .
ENTRYPOINT ["dotnet", "BlogApp.API.dll"]
