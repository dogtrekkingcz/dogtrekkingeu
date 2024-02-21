FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

COPY frontend/PetsOnTrailApp/PetsOnTrailApp.csproj ./PetsOnTrailApp/
COPY . ./

RUN dotnet restore PetsOnTrailApp/PetsOnTrailApp.csproj

RUN dotnet build PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/publish

FROM jonasal/nginx-certbot:latest AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .

