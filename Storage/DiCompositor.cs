using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;
using Storage.Options;
using Storage.Seed;
using Storage.Services;
using Storage.Services.Repositories.ActionRights;
using Storage.Services.Repositories.Actions;
using Storage.Services.Repositories.Activities;
using Storage.Services.Repositories.AuthorizationRoles;
using Storage.Services.Repositories.Checkpoints;
using Storage.Services.Repositories.Pets;
using Storage.Services.Repositories.Entries;
using Storage.Services.Repositories.Migrations;
using Storage.Services.Repositories.UserProfiles;
using Storage.Services.Repositories.VaccinationType;
using Storage.Services.Repositories.PetType;

namespace Storage;

public static class DiCompositor
{
    public static async Task<IHost> ConfigureStorageAsync(this IHost host, CancellationToken cancellationToken)
    {
        //var initializationService = serviceProvider.GetRequiredService<IInitializeService>();
        //if (initializationService != null)
        //    await initializationService.InitializeAsync(cancellationToken);

        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!! ConfigureStorageAsync");

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var migrationService = serviceProvider.GetRequiredService<IMigrationsService>();
            if (migrationService != null)
                await migrationService.RunMigrationsAsync(serviceProvider, cancellationToken);

            else
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!! MigrationsService is null");
        }

        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!! ConfigureStorageAsync done");

        return host;
    } 
    
    public static IServiceCollection AddStorage(this IServiceCollection serviceProvider, StorageOptions options, TypeAdapterConfig typeAdapterConfig)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        serviceProvider
            .AddSingleton<StorageOptions>(options)

            .AddSingleton<IInitializeService>(new InitializeService(options))
            .AddScoped<StorageSeedEngine>()

            .AddSingleton<IStorageService<ActionRecord>, StorageService<ActionRecord>>()
            .AddScoped<IActionsRepositoryService, ActionsRepositoryService>()

            .AddSingleton<IStorageService<ActionRightsRecord>, StorageService<ActionRightsRecord>>()
            .AddScoped<IActionRightsRepositoryService, ActionRightsRepositoryService>()

            .AddSingleton<IStorageService<UserProfileRecord>, StorageService<UserProfileRecord>>()
            .AddScoped<IUserProfilesRepositoryService, UserProfilesRepositoryService>()

            .AddSingleton<IStorageService<PetRecord>, StorageService<PetRecord>>()
            .AddScoped<IPetsRepositoryService, PetsRepositoryService>()

            .AddSingleton<IStorageService<AuthorizationRoleRecord>, StorageService<AuthorizationRoleRecord>>()
            .AddScoped<IAuthorizationRolesRepositoryService, AuthorizationRolesRepositoryService>()

            .AddSingleton<IStorageService<EntryRecord>, StorageService<EntryRecord>>()
            .AddScoped<IEntriesRepositoryService, EntriesRepositoryService>()

            .AddSingleton<IStorageService<CheckpointRecord>, StorageService<CheckpointRecord>>()
            .AddScoped<ICheckpointsRepositoryService, CheckpointsRepositoryService>()
            
            .AddSingleton<IStorageService<ActivityRecord>, StorageService<ActivityRecord>>()
            .AddScoped<IActivitiesRepositoryService, ActivitiesRepositoryService>()
            
            .AddSingleton<IStorageService<MigrationRecord>, StorageService<MigrationRecord>>()
            .AddScoped<IMigrationsRepositoryService, MigrationsRepositoryService>()

            .AddSingleton<IStorageService<ActivityTypeRecord>, StorageService<ActivityTypeRecord>>()
            .AddScoped<IActivityTypeRepositoryService, ActivityTypeRepositoryService>()

            .AddSingleton<IStorageService<VaccinationTypeRecord>, StorageService<VaccinationTypeRecord>>()
            .AddScoped<IVaccinationTypeRepositoryService, VaccinationTypeRepositoryService>()

            .AddSingleton<IStorageService<PetTypeRecord>, StorageService<PetTypeRecord>>()
            .AddScoped<IPetTypeRepositoryService, PetTypeRepositoryService>()
            
            .AddScoped<IMigrationsService, MigrationsService>();
        

        typeAdapterConfig.NewConfig<string, Guid>()
            .Map(d => d, s => s.ToGuid());
        typeAdapterConfig.NewConfig<Guid, string>()
            .Map(d => d, s => s.ToString());
        typeAdapterConfig.NewConfig<string?, Guid?>()
            .Map(d => d, s => s.ToGuid());
        typeAdapterConfig.NewConfig<Guid?, string?>()
            .Map(d => d, s => s.ToString());
        typeAdapterConfig.NewConfig<object, BaseRecord>()
            .Ignore(d => d.CorrelationId);

        typeAdapterConfig
            .AddActionRepositoryMapping()
            .AddActionRightsRepositoryMapping()
            .AddUserProfilesRepositoryMapping()
            .AddEntriesRepositoryMapping()
            .AddPetsRepositoryMapping()
            .AddCheckpointsRepositoryMapping()
            .AddActivitiesRepositoryMapping()
            .AddMigrationsRepositoryMapping()
            .AddAuthorizationRolesRepositoryMapping()
            .AddActivityTypeRepositoryMapping()
            .AddVaccinationTypeRepositoryMapping()
            .AddPetTypeRepositoryMapping();

        BsonClassMap.RegisterClassMap<ActionRecord>();
        BsonClassMap.RegisterClassMap<UserProfileRecord>();
        BsonClassMap.RegisterClassMap<EntryRecord>();
        BsonClassMap.RegisterClassMap<ActionRightsRecord>();
        BsonClassMap.RegisterClassMap<AuthorizationRoleRecord>();
        BsonClassMap.RegisterClassMap<PetRecord>();
        BsonClassMap.RegisterClassMap<CheckpointRecord>();
        BsonClassMap.RegisterClassMap<ActivityRecord>();
        BsonClassMap.RegisterClassMap<MigrationRecord>();
        BsonClassMap.RegisterClassMap<ActivityTypeRecord>();
        BsonClassMap.RegisterClassMap<VaccinationTypeRecord>();
        BsonClassMap.RegisterClassMap<PetTypeRecord>();

        var client = new MongoClient(options.MongoDbConnectionString);

        var db = client.GetDatabase("PetsOnTrailDb");

        var listOfCollections = db.ListCollectionNames().ToList();
        
        if (listOfCollections.Contains("Actions") == false)
        {
            db.CreateCollection("Actions");
        }
        if (listOfCollections.Contains("UserProfiles") == false)
        {
            db.CreateCollection("UserProfiles");
        }
        if (listOfCollections.Contains("Pets") == false)
        {
            db.CreateCollection("Pets");
        }
        if (listOfCollections.Contains("Checkpoints") == false)
        {
            db.CreateCollection("Checkpoints");
        }
        if (listOfCollections.Contains("ActionRights") == false)
        {
            db.CreateCollection("ActionRights");
        }
        if (listOfCollections.Contains("AuthorizationRoles") == false)
        {
            db.CreateCollection("AuthorizationRoles");
        }
        if (listOfCollections.Contains("Entries") == false)
        {
            db.CreateCollection("Entries");
        }
        if (listOfCollections.Contains("Activities") == false)
        {
            db.CreateCollection("Activities");
        }
        if (listOfCollections.Contains("Migrations") == false)
        {
            db.CreateCollection("Migrations");
        }
        if (listOfCollections.Contains("ActivityTypes") == false)
        {
            db.CreateCollection("ActivityTypes");
        }
        if (listOfCollections.Contains("VaccinationTypes") == false)
        {
            db.CreateCollection("VaccinationTypes");
        }
        if (listOfCollections.Contains("PetTypes") == false)
        {
            db.CreateCollection("PetTypes");
        }

        Console.WriteLine($"MongoDb.PetsOnTrail.Collections with initialized collections: {db.ListCollectionNames()}");
        
        serviceProvider.AddSingleton<IMongoCollection<ActionRecord>>(db.GetCollection<ActionRecord>("Actions"));
        serviceProvider.AddSingleton<IMongoCollection<UserProfileRecord>>(db.GetCollection<UserProfileRecord>("UserProfiles"));
        serviceProvider.AddSingleton<IMongoCollection<PetRecord>>(db.GetCollection<PetRecord>("Pets"));
        serviceProvider.AddSingleton<IMongoCollection<CheckpointRecord>>(db.GetCollection<CheckpointRecord>("Checkpoints"));
        serviceProvider.AddSingleton<IMongoCollection<ActionRightsRecord>>(db.GetCollection<ActionRightsRecord>("ActionRights"));
        serviceProvider.AddSingleton<IMongoCollection<AuthorizationRoleRecord>>(db.GetCollection<AuthorizationRoleRecord>("AuthorizationRoles"));
        serviceProvider.AddSingleton<IMongoCollection<EntryRecord>>(db.GetCollection<EntryRecord>("Entries"));
        serviceProvider.AddSingleton<IMongoCollection<ActivityRecord>>(db.GetCollection<ActivityRecord>("Activities"));
        serviceProvider.AddSingleton<IMongoCollection<MigrationRecord>>(db.GetCollection<MigrationRecord>("Migrations"));
        serviceProvider.AddSingleton<IMongoCollection<ActivityTypeRecord>>(db.GetCollection<ActivityTypeRecord>("ActivityTypes"));
        serviceProvider.AddSingleton<IMongoCollection<VaccinationTypeRecord>>(db.GetCollection<VaccinationTypeRecord>("VaccinationTypes"));
        serviceProvider.AddSingleton<IMongoCollection<PetTypeRecord>>(db.GetCollection<PetTypeRecord>("PetTypes"));

        return serviceProvider;
    }   
}