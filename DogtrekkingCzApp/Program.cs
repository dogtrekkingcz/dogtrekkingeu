using Microsoft.AspNetCore.Components.Web;
using DogtrekkingCzApp;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("OIDC", options.ProviderOptions);
});

builder.Services.AddSingleton(services =>
{
    var baseUri = "https://localhost:7082"; 
    return  GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });
});

await builder.Build().RunAsync();

