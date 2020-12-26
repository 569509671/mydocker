##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["MySmartDocker/MySmartDocker.csproj", "MySmartDocker/"]
#RUN dotnet restore "MySmartDocker/MySmartDocker.csproj"
#COPY . .
#WORKDIR "/src/MySmartDocker"
#RUN dotnet build "MySmartDocker.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MySmartDocker.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY . .
#ENTRYPOINT ["dotnet", "MySmartDocker.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

COPY . .
ENTRYPOINT ["dotnet", "MySmartDocker.dll"]