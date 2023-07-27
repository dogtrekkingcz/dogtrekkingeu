using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using DogsOnTrailApp;
using DogsOnTrailApp.Extensions;
using DogsOnTrailApp.Models;
using DogsOnTrailApp.Providers;
using DogsOnTrailApp.Services;
using Google.Protobuf.Collections;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("OIDC", options.ProviderOptions);
});
builder.Services.AddBlazoredModal();
builder.Services.AddBootstrapBlazor();

var typeAdapterConfig = new TypeAdapterConfig
{
    RequireDestinationMemberSource = true,
    RequireExplicitMapping = true,
    Default =
    {
        Settings =
        {
            UseDestinationValues =
            {
                (member => member.SetterModifier == AccessModifier.None &&
                           member.Type.IsGenericType &&
                           member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>))
            }
        }
    }
};


typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset?>()
    .Map(d => d, s => s.ToDateTimeOffset());
typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset>()
    .Map(d => d, s => s.ToDateTimeOffset());
typeAdapterConfig.NewConfig<DateTimeOffset, Google.Type.DateTime>()
    .Map(d => d, s => s.ToGoogleDateTime());
typeAdapterConfig.NewConfig<DateTimeOffset?, Google.Type.DateTime>()
    .Map(d => d, s => s.ToGoogleDateTime());

typeAdapterConfig.NewConfig<Google.Type.Interval, Google.Type.Interval>();
typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Timestamp, Google.Protobuf.WellKnownTypes.Timestamp>();
typeAdapterConfig.NewConfig<Google.Type.DateTime, Google.Type.DateTime>();
typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Duration, Google.Protobuf.WellKnownTypes.Duration>();
typeAdapterConfig.NewConfig<Google.Type.TimeZone, Google.Type.TimeZone>();
typeAdapterConfig.NewConfig<Google.Type.LatLng, Google.Type.LatLng>();

typeAdapterConfig
    .AddActionModelMapping()
    .AddUserProfileModelMapping()
    .AddEntryModelMapping()
    .AddActionSettingsModelMapping()
    .AddDogModelMapping();

builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddScoped<IMapper, ServiceMapper>()
    .AddScoped<IUserProfileService, UserProfileService>()
    .AddBlazoredLocalStorage()
    .AddScoped<TokenStorage>();

builder.Services.AddSingleton(services =>
{
    var baseUri = builder.Configuration["GrpcServerUri"];

    var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });
    
    return channel;
});

builder.Services.AddScoped<ITokenProvider, AppTokenProvider>();

builder.Services
    .AddAuthorizedGrpcClient<Protos.UserProfiles.UserProfiles.UserProfilesClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.Actions.Actions.ActionsClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.Entries.Entries.EntriesClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.ActionRights.ActionRights.ActionRightsClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.Dogs.Dogs.DogsClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.Results.Results.ResultsClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.LiveUpdatesSubscription.LiveUpdatesSubscription.LiveUpdatesSubscriptionClient>(builder.Configuration["GrpcServerUri"]);

builder.Services.AddLocalization();

var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();

