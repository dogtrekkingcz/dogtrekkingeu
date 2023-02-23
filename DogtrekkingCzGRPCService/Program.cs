using DogtrekkingCz.Storage;
using DogtrekkingCzGRPCService.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];
Console.WriteLine(MongoDbConnectionString);

var typeAdapterConfig = new TypeAdapterConfig
{
    RequireDestinationMemberSource = true,
    RequireExplicitMapping = true
};

builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddScoped<IMapper, ServiceMapper>()
    .AddStorage(new StorageOptions() { MongoDbConnectionString = MongoDbConnectionString }, typeAdapterConfig);

typeAdapterConfig
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
    }
);


app.Run();