#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.WebApiService/API.WebApiService.csproj", "API.WebApiService/"]
RUN dotnet restore "API.WebApiService/API.WebApiService.csproj"
COPY . .
WORKDIR "/src/API.WebApiService"
RUN dotnet build "API.WebApiService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.WebApiService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.WebApiService.dll"]