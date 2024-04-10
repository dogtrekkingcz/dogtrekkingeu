using Storage.Entities.Migrations;

namespace Storage.Interfaces;

public interface IMigrationsRepositoryService
{
    Task<CreateMigrationInternalStorageResponse> CreateMigrationAsync(CreateMigrationInternalStorageRequest request, CancellationToken cancellationToken);

    Task<GetMigrationInternalStorageResponse> GetAsync(string id, CancellationToken cancellationToken);

    Task DeleteMigrationAsync(string id, CancellationToken cancellationToken);
}