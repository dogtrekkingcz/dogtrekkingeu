FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY DogtrekkingCzApp/DogtrekkingCzApp.csproj ./DogtrekkingCzApp/
COPY DogtrekkingCzProtos/DogtrekkingCzProtos.csproj ./DogtrekkingCzProtos/
COPY Storage/Storage.csproj ./Storage/

COPY . ./

RUN dotnet restore DogtrekkingCzApp/DogtrekkingCzApp.csproj

RUN dotnet build DogtrekkingCzApp/DogtrekkingCzApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DogtrekkingCzApp/DogtrekkingCzApp.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY DogtrekkingCzApp/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443