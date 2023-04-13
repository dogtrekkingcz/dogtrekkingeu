using DogtrekkingCz.Storage;
using DogtrekkingCzGRPCService.Interceptors;
using DogtrekkingCzGRPCService.Services;
using DogtrekkingCzGRPCService.Services.JwtToken;
using Google.Protobuf.Collections;
using Mapster;
using MapsterMapper;
using Storage.Interfaces.Options;
using DogtrekkingCzGRPCService.Extensions;
using DogtrekkingCzShared.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<JwtTokenInterceptor>();
});

string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];
Console.WriteLine(MongoDbConnectionString);

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

builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddScoped<IMapper, ServiceMapper>()
    .AddScoped<IJwtTokenService, JwtTokenService>()
    .AddScoped<JwtTokenInterceptor>()
    .AddStorage(new StorageOptions() { MongoDbConnectionString = MongoDbConnectionString }, typeAdapterConfig);

typeAdapterConfig
    .AddSharedMapping()
    .AddAuthorizationServiceMapping()
    .AddActionsServiceMapping()
    .AddUserProfilesServiceMapping();

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
    }
);


app.Run();

await app.SeedDataAsync();