FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
COPY ./src/BeComfy.Services.Customers/bin/Release/netcoreapp3.0 .
ENV ASPNETCORE_URLS http://*:5025
ENV ASPNETCORE_ENVIRONMENT Release
EXPOSE 5015
ENTRYPOINT ["dotnet", "BeComfy.Services.Customers.dll"]