using DogtrekkingCz.Actions;
using DogtrekkingCz.Entries;
using DogtrekkingCzShared;
using DogtrekkingCzWebApiService.RequestHandlers;
using DogtrekkingCzWebApiService.Validators;
using Mapster;

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

builder.Services.AddDogtrekkingCzShared(out typeAdapterConfig, options);
builder.Services.AddActions(typeAdapterConfig, options);
builder.Services.AddEntries(typeAdapterConfig, options);

typeAdapterConfig.AddActionsMapping();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
