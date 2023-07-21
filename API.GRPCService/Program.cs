using API.GRPCService.Services.Actions;
using DogsOnTrail.Actions;
using Mapster;
using DogsOnTrailGRPCService.Extensions;
using DogsOnTrailGRPCService.Services.Actions;
using DogsOnTrailGRPCService.Services.Authorization;
using DogsOnTrailGRPCService.Services.Dogs;
using DogsOnTrailGRPCService.Services.Entries;
using DogsOnTrailGRPCService.Services.Results;
using DogsOnTrailGRPCService.Services.UserProfiles;
using SharedCode;
using SharedCode.Interceptors;
using Storage;
using Storage.Options;

var builder = WebApplication.CreateBuilder(args);

string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];

TypeAdapterConfig typeAdapterConfig = null;
var options = new SharedCode.Options.DogsOnTrailOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

builder.Services
    .AddDogsOnTrailShared(out typeAdapterConfig, options)
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig)
    .AddBaseLayer(typeAdapterConfig, options)
    .AddGrpc(options =>
    {
        options.Interceptors.Add<JwtTokenInterceptor>();
    });

typeAdapterConfig
    .AddAuthorizationServiceMapping()
    .AddActionsServiceMapping()
    .AddUserProfilesServiceMapping()
    .AddEntriesServiceMapping()
    .AddDogsServiceMapping()
    .AddResultsMapping();

typeAdapterConfig.NewConfig<Google.Type.Interval, Google.Type.Interval>();
typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Timestamp, Google.Protobuf.WellKnownTypes.Timestamp>();
typeAdapterConfig.NewConfig<Google.Type.DateTime, Google.Type.DateTime>();
typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Duration, Google.Protobuf.WellKnownTypes.Duration>();
typeAdapterConfig.NewConfig<Google.Type.TimeZone, Google.Type.TimeZone>();
typeAdapterConfig.NewConfig<Google.Type.LatLng, Google.Type.LatLng>();

typeAdapterConfig.NewConfig<DateTimeOffset?, Google.Type.DateTime>()
    .MapWith(s => s != null ? s.ToGoogleDateTime() : null);
            
typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset?>()
    .MapWith(s => s != null ? s.ToDateTimeOffset() : null);

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
        endpoints.MapGrpcService<DogsService>().EnableGrpcWeb().RequireCors("AllowAll");
        endpoints.MapGrpcService<ResultsService>().EnableGrpcWeb().RequireCors("AllowAll");
    }
);


app.Run();

await app.SeedDataAsync();