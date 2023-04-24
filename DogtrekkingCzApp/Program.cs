using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using DogtrekkingCzApp;
using DogtrekkingCzApp.Extensions;
using DogtrekkingCzApp.Models;
using DogtrekkingCzApp.Providers;
using DogtrekkingCzApp.Services;
using DogtrekkingCzShared.Mapping;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
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

typeAdapterConfig
    .AddSharedMapping()
    .AddActionModelMapping()
    .AddUserProfileModelMapping()
    .AddEntryModelMapping()
    .AddActionSettingsModelMapping()
    .AddDogModelMapping();

builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddSingleton<IUserProfileService, UserProfileService>()
    .AddScoped<IMapper, ServiceMapper>()
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
    .AddAuthorizedGrpcClient<Protos.Authorization.Authorization.AuthorizationClient>(builder.Configuration["GrpcServerUri"])
    .AddAuthorizedGrpcClient<Protos.Dogs.Dogs.DogsClient>(builder.Configuration["GrpcServerUri"]);

builder.Services.AddLocalization();

var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();

