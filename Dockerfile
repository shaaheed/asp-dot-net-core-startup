# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
#COPY *.csproj ./
COPY . .
COPY *.sln ./
#COPY Comment.Application/*.csproj Comment.Application/
RUN dotnet restore
COPY . ./

# publish
FROM build AS publish
WORKDIR /src
RUN dotnet publish -c Release -o /src/publish

#ENV ACCEPT_EULA=Y
#FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu as mssql

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "AccountingWebHost.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AccountingWebHost.dll
#RUN mssql 1433:1433 mssql
