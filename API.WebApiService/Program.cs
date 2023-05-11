using DogsOnTrail.Actions;
using SharedCode;
using DogsOnTrailWebApiService.RequestHandlers;
using DogsOnTrailWebApiService.RequestHandlers.Entries;
using DogsOnTrailWebApiService.Validators;
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
var options = new SharedCode.Options.DogsOnTrailOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

builder.Services
    .AddDogsOnTrailShared(out typeAdapterConfig, options)
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig)
    .AddBaseLayer(typeAdapterConfig, options);

typeAdapterConfig.AddMapping();

typeAdapterConfig.Compile();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
