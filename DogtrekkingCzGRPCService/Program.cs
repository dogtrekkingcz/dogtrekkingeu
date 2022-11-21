using DogtrekkingCz.Storage;
using DogtrekkingCzGRPCService.Services;
using Storage.Interfaces.Options;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();


builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "X-Grpc-Web", "User-Agent");
}));

string MongoDbConnectionString = "";
builder.Services.AddStorage(new StorageOptions() { MongoDbConnectionString = MongoDbConnectionString });

var app = builder.Build();

app.UseRouting();
app.UseGrpcWeb();
app.UseCors();

app.MapGet("/", async context => { await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"); });
app.UseEndpoints(endpoints =>
    endpoints.MapGrpcService<BeachConditionsService>().EnableGrpcWeb().RequireCors("AllowAll")
);


app.Run();