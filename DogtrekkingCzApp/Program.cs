using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using DogtrekkingCzApp;
using DogtrekkingCzApp.Interfaces;
using DogtrekkingCzApp.Models;
using DogtrekkingCzShared.Mapping;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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
    .AddUserProfileModelMapping();
    
builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddScoped<IMapper, ServiceMapper>();


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
    .AddGrpcClient<Protos.UserProfiles.UserProfiles.UserProfilesClient>(o =>
    {
        o.Address = new Uri(builder.Configuration["GrpcServerUri"]);
    })
    .AddCallCredentials(async (context, metadata, serviceProvider) =>
    {
        var provider = serviceProvider.GetRequiredService<ITokenProvider>();
        var token = await provider.GetTokenAsync();
        metadata.Add("Authorization", $"Bearer {token}");
    })
    .ConfigureChannel(o =>
    {
        o.HttpHandler = new GrpcWebHandler(new HttpClientHandler());
        o.UnsafeUseInsecureChannelCallCredentials = true;
    });

builder.Services
    .AddGrpcClient<Protos.Actions.Actions.ActionsClient>(o =>
    {
        o.Address = new Uri(builder.Configuration["GrpcServerUri"]);
    })
    .AddCallCredentials(async (context, metadata, serviceProvider) =>
    {
        var provider = serviceProvider.GetRequiredService<ITokenProvider>();
        var token = await provider.GetTokenAsync();
        metadata.Add("Authorization", $"Bearer {token}");
    })
    .ConfigureChannel(o =>
    {
        o.HttpHandler = new GrpcWebHandler(new HttpClientHandler());
        o.UnsafeUseInsecureChannelCallCredentials = true;
    });

builder.Services.AddLocalization();


var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();

