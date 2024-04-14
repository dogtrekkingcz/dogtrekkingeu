using API.WebApiService.Options;
using API.WebApiService.RequestHandlers;
using API.WebApiService.Validators;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;
using Storage;
using Storage.Options;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

try
{
    var certPem = File.ReadAllText("/app/fullchain.pem");
    var keyPem = File.ReadAllText("/app/privkey.pem");
    var x509 = X509Certificate2.CreateFromPem(certPem, keyPem);

    builder.WebHost.ConfigureKestrel(s => {
        s.ListenAnyIP(443, options =>
        {
            options.UseHttps(x509);
        });
    });
}
catch (Exception ex)
{
    try
    {
        var files = Directory.EnumerateFiles("/app/", "*", SearchOption.AllDirectories);

        foreach (string currentFile in files)
        {
            Console.WriteLine(currentFile);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

builder.Services.AddControllers();
builder.Services.AddMediator();
builder.Services.AddValidators();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.FullName?.Replace("+", ".")));


string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];
Console.WriteLine(MongoDbConnectionString);

TypeAdapterConfig typeAdapterConfig = null;
var options = new PetsOnTrailOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

typeAdapterConfig = new TypeAdapterConfig
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
                           member.Type.IsGenericType)
            }
        }
    }
};

builder.Services
    .AddSingleton(typeAdapterConfig)
    .AddScoped<IMapper, ServiceMapper>()
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig);

typeAdapterConfig.AddMapping();

typeAdapterConfig.Compile();

var app = builder.Build();

// migrations will be running only on gRPC.API instance...
// app.ConfigureStorageAsync(CancellationToken.None).Wait();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
