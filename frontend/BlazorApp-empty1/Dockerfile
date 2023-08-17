FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["frontend/BlazorApp-empty1/BlazorApp-empty1.csproj", "frontend/BlazorApp-empty1/"]
RUN dotnet restore "frontend/BlazorApp-empty1/BlazorApp-empty1.csproj"
COPY . .
WORKDIR "/src/frontend/BlazorApp-empty1"
RUN dotnet build "BlazorApp-empty1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp-empty1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp-empty1.dll"]
