FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build

WORKDIR /src

COPY frontend/PetsOnTrailApp/PetsOnTrailApp.csproj ./frontend/PetsOnTrailApp/
COPY frontend/PetsOnTrailApp/ ./frontend/PetsOnTrailApp/
COPY frontend/SharedLib/ ./frontend/SharedLib/

COPY . ./

RUN dotnet restore frontend/PetsOnTrailApp/PetsOnTrailApp.csproj

RUN dotnet build frontend/PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish frontend/PetsOnTrailApp/PetsOnTrailApp.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY frontend/PetsOnTrailApp/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443