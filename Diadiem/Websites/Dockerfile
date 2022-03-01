#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Websites/Websites.csproj", "Websites/"]
COPY ["Cores/Cores.csproj", "Cores/"]
COPY ["BusinessLogicLayer/BusinessLogicLayer.csproj", "BusinessLogicLayer/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Helpers/Helpers.csproj", "Helpers/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Core.Arango/Core.Arango.csproj", "Core.Arango/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "Websites/Websites.csproj"
COPY . .
WORKDIR "/src/Websites"
RUN dotnet build "Websites.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Websites.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Websites.dll"]