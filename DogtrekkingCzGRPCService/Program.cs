using DogtrekkingCz.Actions;
using DogtrekkingCz.Entries;
using Mapster;
using DogtrekkingCzGRPCService.Extensions;
using DogtrekkingCzGRPCService.Services.Actions;
using DogtrekkingCzGRPCService.Services.Authorization;
using DogtrekkingCzGRPCService.Services.Entries;
using DogtrekkingCzGRPCService.Services.UserProfiles;
using DogtrekkingCzShared;
using DogtrekkingCzShared.Interceptors;
using Storage;
using Storage.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<JwtTokenInterceptor>();
});

string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];
Console.WriteLine(MongoDbConnectionString);

TypeAdapterConfig typeAdapterConfig = null;
var options = new DogtrekkingCzShared.Options.DogtrekkingCzOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

builder.Services
    .AddDogtrekkingCzShared(out typeAdapterConfig, options)
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig)
    .AddActions(typeAdapterConfig, options)
    .AddEntries(typeAdapterConfig, options);

typeAdapterConfig
    .AddAuthorizationServiceMapping()
    .AddActionsServiceMapping()
    .AddUserProfilesServiceMapping()
    .AddEntriesServiceMapping();

typeAdapterConfig.Compile();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "X-Grpc-Web", "User-Agent", "Access-Control-Allow-Origin");
}));

builder.Services.AddLocalization();

var app = builder.Build();

app.UseRouting();

app.UseGrpcWeb();

app.UseCors();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
});

app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<ActionsService>().EnableGrpcWeb().RequireCors("AllowAll");
        endpoints.MapGrpcService<UserProfilesService>().EnableGrpcWeb().RequireCors("AllowAll");
        endpoints.MapGrpcService<AuthorizationService>().EnableGrpcWeb().RequireCors("AllowAll");
        endpoints.MapGrpcService<EntriesService>().EnableGrpcWeb().RequireCors("AllowAll");
    }
);


app.Run();

await app.SeedDataAsync();