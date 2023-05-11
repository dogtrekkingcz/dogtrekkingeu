FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.GRPCService/API.GRPCService.csproj", "API.GRPCService/"]
RUN dotnet restore "API.GRPCService/API.GRPCService.csproj"
COPY . .
WORKDIR "/src/API.GRPCService"
RUN dotnet build "API.GRPCService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.GRPCService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.GRPCService.dll"]
