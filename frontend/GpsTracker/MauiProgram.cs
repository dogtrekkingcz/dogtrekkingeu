using System.Reflection;
using Microsoft.Extensions.Logging;
using GpsTracker.Data;
using GpsTracker.Services;
using GpsTracker.Services.Storage;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using GpsTracker.Providers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedLib.Extensions;
using SharedLib.Providers;
using AppTokenProvider = GpsTracker.Providers.AppTokenProvider;
using GpsTracker.Auth0;

namespace GpsTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });
            
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("GpsTracker.appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(config);
            

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // 8:53:58
        
        TypeAdapterConfig typeAdapterConfig = new TypeAdapterConfig
            {
                RequireDestinationMemberSource = true,
                RequireExplicitMapping = true,
                Default =
                {
                    Settings =
                    {
                        UseDestinationValues =
                        {
                        }
                    }
                }
            }
            .AddMapping();

        builder.Services
            .AddSingleton(typeAdapterConfig)
            .AddScoped<IMapper, ServiceMapper>()
            .AddSingleton<WeatherForecastService>()
            .AddSingleton<IGpsPositionService, GpsPositionService>()
            .AddSingleton<PositionHistoryService>()
            .AddScoped<ITokenProvider, AppTokenProvider>();
        
        builder.Services
            .AddAuthorizedGrpcClient<Protos.UserProfiles.UserProfiles.UserProfilesClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.Actions.Actions.ActionsClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.Entries.Entries.EntriesClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.ActionRights.ActionRights.ActionRightsClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.Pets.Pets.PetsClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.Results.Results.ResultsClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.LiveUpdatesSubscription.LiveUpdatesSubscription.LiveUpdatesSubscriptionClient>(builder.Configuration["GrpcServerUri"])
            .AddAuthorizedGrpcClient<Protos.Checkpoints.Checkpoints.CheckpointsClient>(builder.Configuration["GrpcServerUri"]);
        
        // return builder.Build();
        
        // authentication
        builder.Services.AddAuthorizationCore();
        builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
        
        builder.Services.AddSingleton<MainPage>();

        var scopes = builder.Configuration
            .GetSection("OIDC")
            .GetSection("DefaultScopes")
            .GetChildren()
            .Select(scope => scope.Value.ToString());

        var scope = String.Join(" ", scopes);
        
        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Authority = builder.Configuration.GetSection("OIDC").GetSection("Authority").Value,
            ClientId = builder.Configuration.GetSection("OIDC").GetSection("ClientId").Value,
            Scope = scope,
            RedirectUri = "myapp://callback"
        }));
        
        var host = builder.Build();

        return host;
    }
}