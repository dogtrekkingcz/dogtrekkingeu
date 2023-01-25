FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY dogtrekkingcz.sln ./
COPY DogtrekkingCzGRPCService/*.csproj ./DogtrekkingCzGRPCService/
COPY DogtrekkingCzApp/*.csproj ./DogtrekkingCzApp/
COPY DogtrekkingCzProtos/*.csproj ./DogtrekkingCzProtos/
COPY Storage/*.csproj ./Storage/

RUN dotnet restore
COPY . .

WORKDIR /src/DogtrekkingCzGRPCService
RUN dotnet build -c Release -o /app

WORKDIR /src/DogtrekkingCzApp
RUN dotnet build -c Release -o /app

WORKDIR /src/DogtrekkingCzProtos
RUN dotnet build -c Release -o /app

WORKDIR /src/Storage
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DogtrekkingCzApp.dll"]
