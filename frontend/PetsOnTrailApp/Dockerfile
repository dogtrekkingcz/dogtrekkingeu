FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY frontend/PetsOnTrailApp/PetsOnTrailApp.csproj ./frontend/PetsOnTrailApp/
COPY frontend/PetsOnTrailApp/ ./frontend/PetsOnTrailApp/
COPY frontend/SharedLib/ ./frontend/SharedLib/

COPY . ./


RUN dotnet workload restore
RUN dotnet workload install wasm-tools maui-android

RUN dotnet restore frontend/PetsOnTrailApp/PetsOnTrailApp.csproj

RUN dotnet build frontend/PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish frontend/PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/publish

FROM jonasal/nginx-certbot:latest AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .

EXPOSE 80
EXPOSE 443
