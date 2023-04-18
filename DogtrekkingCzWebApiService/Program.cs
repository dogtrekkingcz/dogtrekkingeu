using DogtrekkingCz.Actions;
using DogtrekkingCzShared;
using DogtrekkingCzWebApiService.RequestHandlers;
using DogtrekkingCzWebApiService.RequestHandlers.Entries;
using DogtrekkingCzWebApiService.Validators;
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
var options = new DogtrekkingCzShared.Options.DogtrekkingCzOptions()
{
    MongoDbConnectionString = MongoDbConnectionString
};

builder.Services
    .AddDogtrekkingCzShared(out typeAdapterConfig, options)
    .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig)
    .AddActions(typeAdapterConfig, options);

typeAdapterConfig.AddMapping();

typeAdapterConfig.Compile();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
