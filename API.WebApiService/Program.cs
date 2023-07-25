using API.WebApiService.Options;
using API.WebApiService.RequestHandlers;
using API.WebApiService.Validators;
using Mapster;
using Storage;
using Storage.Options;

var builder = WebApplication.CreateBuilder(args);

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
