using Microsoft.Extensions.Logging;
using GpsTracker.Data;
using GpsTracker.Services;
using GpsTracker.Services.Storage;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace GpsTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

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
            .AddSingleton<PositionHistoryService>();
        
        return builder.Build();
    }
}