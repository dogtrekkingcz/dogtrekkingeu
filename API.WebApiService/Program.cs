using API.WebApiService.Options;
using API.WebApiService.RequestHandlers;
using API.WebApiService.Validators;
using Mapster;
using Storage;
using Storage.Options;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

try
{
    var certPem = File.ReadAllText("/app/certs/fullchain.pem");
    var keyPem = File.ReadAllText("/app/certs/privkey.pem");
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
        var files = Directory.EnumerateFiles("/", "*", SearchOption.AllDirectories);

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
builder.Services.AddSwaggerGen();

string MongoDbConnectionString = builder.Configuration["MongoDB:ConnnectionString"];
Console.WriteLine(MongoDbConnectionString);

TypeAdapterConfig typeAdapterConfig = null;
var options = new DogsOnTrailOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

builder.Services
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig);

typeAdapterConfig.AddMapping();

typeAdapterConfig.Compile();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
