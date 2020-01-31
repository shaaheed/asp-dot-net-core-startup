COPY ./dist ./app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
# ENTRYPOINT ["dotnet", "AccountingWebHost.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AccountingWebHost.dll
