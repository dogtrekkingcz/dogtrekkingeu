FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY DogsOnTrailApp/DogsOnTrailApp.csproj ./DogsOnTrailApp/

COPY . ./

RUN dotnet restore DogsOnTrailApp/DogsOnTrailApp.csproj

RUN dotnet build DogsOnTrailApp/DogsOnTrailApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DogsOnTrailApp/DogsOnTrailApp.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY DogsOnTrailApp/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443