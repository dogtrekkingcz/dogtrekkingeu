using Amazon.Auth.AccessControlPolicy;
using Mapster;
using Storage.Entities.Migrations;
using Storage.Models;

namespace Storage.Services.Repositories.Migrations
{
    internal static class MigrationsRepositoryMapping
    {
        internal static TypeAdapterConfig AddMigrationsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateMigrationInternalStorageRequest, MigrationRecord>();
            typeAdapterConfig.NewConfig<MigrationRecord, CreateMigrationInternalStorageResponse>();

            return typeAdapterConfig;
        }
    }
}